using System.Reflection;
using System.Windows.Forms.VisualStyles;

namespace DLL_Interpreter
{
    public partial class BaseForm : Form
    {
        string CurrentDllFile = "";
        List<TypeInfo> CurrentDllTypeInfo = new List<TypeInfo>();
        TreeNodeInfo CurrentTreeNodeInfo;

        string TestFile = @"C:\Users\magma\OneDrive\Documents\DLL-Interpreter-TestLib\TestDll\bin\Debug\net6.0\TestDll.dll";

        public BaseForm()
        {
            InitializeComponent();
            DllOutputTreeView.AfterSelect += OnTreeviewNodeSelected;
        }
        private void SelectDllBtn_Click(object sender, EventArgs e)
        {
            //Open A OpenFileDialog window
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Filter = "dll | *.dll";
            ofd.InitialDirectory = @"C:\";

            ofd.Title = "Select a .dll File:";

            //PRODUCTION
            //Return if cancelled
            //if (ofd.ShowDialog() != DialogResult.OK) return;

            ////Save the info of the file selected
            //CurrentDllFile = ofd.FileName;
            //DllPathLbl.Text = CurrentDllFile;

            //TESTING
            CurrentDllFile = TestFile;
            DllPathLbl.Text = CurrentDllFile;

            //Shows output to the screen
            DisplayAssemblyInfo();
        }
        private void OnTreeviewNodeSelected(object? sender, TreeViewEventArgs e)
        {
            AssemblyInterpreter ai = new();
            CurrentTreeNodeInfo = ai.GetSelectedNodeInfo(DllOutputTreeView.SelectedNode);

            SelectedTypeNameLbl.Text = CurrentTreeNodeInfo.TypeName;
            SelectedMethodLbl.Text = CurrentTreeNodeInfo.MethodName;
            SelectedParametersLbl.Text = CurrentTreeNodeInfo.Parameters;
        }
        void DisplayAssemblyInfo()
        {
            DllOutputTreeView.Nodes.Clear();
            
            AssemblyInterpreter ai = new AssemblyInterpreter();

            CurrentDllTypeInfo = ai.GetDllInfo(CurrentDllFile).ToList();

            //Looping through and displaying the types in the .dll
            for (int TypeIndex = 0; TypeIndex < CurrentDllTypeInfo.Count(); TypeIndex++)
            {
                var dllType = CurrentDllTypeInfo.ElementAt(TypeIndex);
                DllOutputTreeView
                    .Nodes
                    .Add(AssemblyInterpreter.TypeIdentifier + dllType.GetType().Name);

                //Looping through and displaying the method names and return types in each Type
                for (int MethodIndex = 0; MethodIndex < dllType.GetMethodInfo().Count(); MethodIndex++)
                {
                    var method = dllType.GetMethodInfo().ElementAt(MethodIndex);
                    DllOutputTreeView
                        .Nodes[TypeIndex]
                        .Nodes
                        .Add($"{AssemblyInterpreter.MethodIdentifier}{method.Name}:{method.ReturnType}");

                    //Looping through and displaying all the parameters for each method
                    for (int ParameterIndex = 0; ParameterIndex < method.ParameterInfo.Length; ParameterIndex++)
                    {
                        var parameter = method.ParameterInfo.ElementAt(ParameterIndex);
                        DllOutputTreeView.Nodes[TypeIndex]
                            .Nodes[MethodIndex]
                            .Nodes
                            .Add($"{AssemblyInterpreter.ParameterIdentifier}{parameter.Name}:{parameter.ParameterType.Name}" +
                            //NOTE: if parameter.IsOptional it means the parameter is REQUIRED -- Not Sure Why, Bug?
                            $" {(!parameter.IsOptional? "" : $"={parameter.DefaultValue}")}");
                    }
                }
            }

            DllOutputTreeView.Refresh();
        }
        private void TestInputOutputBtn_Click(object sender, EventArgs e)
        {
            if (CurrentTreeNodeInfo.Category != TypeCategory.METHOD)
            {
                //Show output?
                OutputFieldLbl.Text = "Please select a Method before testing! " + CurrentTreeNodeInfo.Category;
                return;
            }

            AssemblyInterpreter ai = new();
            (TypeInfo type, DllMethodInfo mi) = ai.FindSelectedMethod(DllOutputTreeView.SelectedNode, CurrentDllTypeInfo);
            object[] parameters = ai.GetParameterValues(mi, ParametersInputTxt.Text);

            //Parameters will be null if the user entered invalid parameters as input
            if(parameters == null)
            {
                //Show Output?
                OutputFieldLbl.Text = "Please Enter the Correct Parameter types - space seperated";
                return;
            }

            //Create an instance of the Type, then invoke the method on that instance of the Type
            var instanceOfType = type.GetType().Assembly.CreateInstance(type.GetType().FullName);

            object result = mi.GetMethodInfo().Invoke(instanceOfType, parameters);
            OutputTxt.Text = result?.ToString();
        }
    }

    class AssemblyInterpreter
    {
        public static readonly string TypeIdentifier = "Type: ";
        public static readonly string MethodIdentifier = "Method: ";
        public static readonly string ParameterIdentifier = "Parameter: ";

        public IEnumerable<TypeInfo> GetDllInfo(string DllPath)
        {
            //Input Validation
            if(string.IsNullOrWhiteSpace(DllPath) || !File.Exists(DllPath)) yield break;

            Assembly LoadedAssembly = Assembly.LoadFrom(DllPath);
            
            //Loop Through all types in this assembly
            foreach(var t in LoadedAssembly.GetTypes())
            {
                TypeInfo typeInfo = new TypeInfo(t);

                //Loop through all the methods in this Type
                foreach (var m in t.GetMethods())
                    typeInfo.AddMethodInfo(m);

                yield return typeInfo;
            }
        }
        public TreeNodeInfo GetSelectedNodeInfo(TreeNode node)
        {
            TreeNodeInfo nodeInfo = new();

            string nodeText = node.Text;
            if(nodeText.Contains(TypeIdentifier))
            {
                nodeInfo.Category = TypeCategory.TYPE;

                string typeName = GetTypeName(nodeText);
                nodeInfo.TypeName = typeName;

                //Can't do anything about a method because no method was selected
                return nodeInfo;
            }
            else if(nodeText.Contains(MethodIdentifier))
            {
                nodeInfo.Category = TypeCategory.METHOD;

                //Method Name Node
                string methodName = GetMethodName(nodeText);

                //Loop through the parameter nodes
                string parameters = "";

                //Only look for parameters if there are actually parameters shown in the TreeView
                //Otherwise indexOutOfBounds Exceptions will occur
                if (node.Nodes.Count > 0)
                {
                    for (int i = 0; i < node.Nodes.Count - 1; i++)
                        parameters += GetParameterType(node.Nodes[i].Text) + " ";

                    //Add the last parameter without a '#'
                    parameters += GetParameterType(node.Nodes[node.Nodes.Count - 1].Text);
                }

                nodeInfo.TypeName = GetTypeName(node.Parent.Text);
                nodeInfo.MethodName = methodName;
                nodeInfo.Parameters = parameters;

                return nodeInfo;
            }
            else if (nodeText.Contains(ParameterIdentifier))
            {
                nodeInfo.Category = TypeCategory.PARAMETER;
                nodeInfo.Parameters = GetParameterType(nodeText);
                return nodeInfo;
            }
            else throw new Exception("Invalid Text Inside Tree Node!");

            return nodeInfo;
        }
        public (TypeInfo, DllMethodInfo) FindSelectedMethod(TreeNode methodNode, List<TypeInfo> typeInfoArr)
        {
            //'type' variable refers to the type that contains the method we are searching for
            string typeName = GetTypeName(methodNode.Parent.Text);
            TypeInfo type = typeInfoArr.Find(ti => ti.GetType().Name == typeName);

            string methodName = GetMethodName(methodNode.Text);
            DllMethodInfo method = type.GetMethodInfo().Find(mi => mi.Name == methodName);

            return (type, method);
        }
        public object[] GetParameterValues(DllMethodInfo mi, string input)
        {
            //Input Validation
            string[] inputs = input.Split(" ");
            int paramCount = mi.ParameterInfo.Length;

            //INVALID -- RETURN
            if (paramCount != inputs.Length) return null;

            //Compiling the parameters
            List<object> parameters = new();
            for (int i = 0; i < mi.ParameterInfo.Length; i++)
            {
                var paramInfo = mi.ParameterInfo[i];

                //Finding out which type it is
                if(Object.ReferenceEquals(paramInfo.ParameterType, typeof(string)))
                {
                    //Add a direct string to the parameter list
                    parameters.Add(inputs[i]);
                }
                else if(Object.ReferenceEquals(paramInfo.ParameterType, typeof(int)))
                {
                    //Parse to int, then add to parameter list
                    if (!int.TryParse(inputs[i], out var parsed)) return null;
                    parameters.Add(parsed);
                }
                else if(Object.ReferenceEquals(paramInfo.ParameterType, typeof(bool)))
                {
                    //Parse to bool, then add to parameter list
                    if (!bool.TryParse(inputs[i], out var parsed)) return null;
                    parameters.Add(parsed);
                }
                else if (Object.ReferenceEquals(paramInfo.ParameterType, typeof(float)))
                {
                    //Parse to bool, then add to parameter list
                    if (!float.TryParse(inputs[i], out var parsed)) return null;
                    parameters.Add(parsed);
                }
                else if (Object.ReferenceEquals(paramInfo.ParameterType, typeof(double)))
                {
                    //Parse to bool, then add to parameter list
                    if (!float.TryParse(inputs[i], out var parsed)) return null;
                    parameters.Add(parsed);
                }
                else if (Object.ReferenceEquals(paramInfo.ParameterType, typeof(char)))
                {
                    //Parse to bool, then add to parameter list
                    if (!char.TryParse(inputs[i], out var parsed)) return null;
                    parameters.Add(parsed);
                }
            }
            
            return parameters.ToArray();
        }

        //String Manipulation Methods - Takes Text Directly from the TreeView
        string GetTypeName(string _nodeText)
                => _nodeText
                .Split(TypeIdentifier)[1];
        string GetMethodName(string _nodeText)
            => _nodeText
            .Split(MethodIdentifier)[1]
            .Split(":")[0];
        string GetParameterType(string _nodeText)
            => _nodeText
            .Split(ParameterIdentifier)[1]
            .Split(":")[1]
            .Split("=")[0];
    }
    struct TypeInfo
    {
        public TypeInfo(Type _t)
        {
            _type = _t;
        }

        private Type _type { get; set; }

        //Stores Info on All the methods of the Set Type
        private List<DllMethodInfo> _methodInfo { get; set; }
            = new List<DllMethodInfo>();

        public void AddMethodInfo(MethodInfo m)
            => _methodInfo.Add(new DllMethodInfo(m));

        //GETTERS
        public Type GetType() => _type;
        public List<DllMethodInfo> GetMethodInfo() => _methodInfo;
    }
    struct DllMethodInfo
    {
        string _name, _methodType;
        MethodInfo _methodInfo;
        ParameterInfo[] _parameterInfo;

        public DllMethodInfo(MethodInfo m)
        {
            _name = m.Name;
            _methodType = m.ReturnType.Name;
            _methodInfo = m;
            _parameterInfo = m.GetParameters();
        }

        public string Name => _name;
        public string ReturnType => _methodType;
        public MethodInfo GetMethodInfo() => _methodInfo;
        public ParameterInfo[] ParameterInfo => _parameterInfo;
    }
    //Handles ALL infotmation that needs to be shown on the GUI when 
    //the user selects a node on the Tree View
    struct TreeNodeInfo
    {
        public TreeNodeInfo()
        {
            //Default it to TYPE
            Category = TypeCategory.TYPE;
        }

        public TypeCategory Category;
        public string TypeName = "", MethodName = "";
        public string Parameters = "";
    }
    enum TypeCategory
    {
        TYPE = 0, METHOD = 1, PARAMETER = 2
    }
}