namespace DLL_Interpreter
{
    partial class BaseForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node2");
            this.SelectDllBtn = new System.Windows.Forms.Button();
            this.DllPathLbl = new System.Windows.Forms.Label();
            this.DllOutputTreeView = new System.Windows.Forms.TreeView();
            this.Label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.ParametersInputTxt = new System.Windows.Forms.TextBox();
            this.TestInputOutputBtn = new System.Windows.Forms.Button();
            this.OutputTxt = new System.Windows.Forms.RichTextBox();
            this.OutputHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectedMethodLbl = new System.Windows.Forms.Label();
            this.SelectedTypeNameLbl = new System.Windows.Forms.Label();
            this.SelectedParametersLbl = new System.Windows.Forms.Label();
            this.OutputFieldLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectDllBtn
            // 
            this.SelectDllBtn.Location = new System.Drawing.Point(498, 5);
            this.SelectDllBtn.Name = "SelectDllBtn";
            this.SelectDllBtn.Size = new System.Drawing.Size(100, 23);
            this.SelectDllBtn.TabIndex = 0;
            this.SelectDllBtn.Text = "SELECT DLL";
            this.SelectDllBtn.UseVisualStyleBackColor = true;
            this.SelectDllBtn.Click += new System.EventHandler(this.SelectDllBtn_Click);
            // 
            // DllPathLbl
            // 
            this.DllPathLbl.AutoEllipsis = true;
            this.DllPathLbl.Location = new System.Drawing.Point(67, 11);
            this.DllPathLbl.Name = "DllPathLbl";
            this.DllPathLbl.Size = new System.Drawing.Size(425, 15);
            this.DllPathLbl.TabIndex = 1;
            this.DllPathLbl.Text = "label1";
            // 
            // DllOutputTreeView
            // 
            this.DllOutputTreeView.Location = new System.Drawing.Point(12, 34);
            this.DllOutputTreeView.Name = "DllOutputTreeView";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Node4";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Node3";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Node1";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Node2";
            this.DllOutputTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5});
            this.DllOutputTreeView.Size = new System.Drawing.Size(586, 387);
            this.DllOutputTreeView.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label3.Location = new System.Drawing.Point(12, 435);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(91, 21);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Type Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Method Name:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label4.Location = new System.Drawing.Point(279, 435);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(91, 21);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Parameters:";
            // 
            // ParametersInputTxt
            // 
            this.ParametersInputTxt.Location = new System.Drawing.Point(364, 462);
            this.ParametersInputTxt.Name = "ParametersInputTxt";
            this.ParametersInputTxt.Size = new System.Drawing.Size(234, 23);
            this.ParametersInputTxt.TabIndex = 6;
            // 
            // TestInputOutputBtn
            // 
            this.TestInputOutputBtn.Location = new System.Drawing.Point(12, 491);
            this.TestInputOutputBtn.Name = "TestInputOutputBtn";
            this.TestInputOutputBtn.Size = new System.Drawing.Size(586, 23);
            this.TestInputOutputBtn.TabIndex = 7;
            this.TestInputOutputBtn.Text = "Test";
            this.TestInputOutputBtn.UseVisualStyleBackColor = true;
            this.TestInputOutputBtn.Click += new System.EventHandler(this.TestInputOutputBtn_Click);
            // 
            // OutputTxt
            // 
            this.OutputTxt.Location = new System.Drawing.Point(628, 34);
            this.OutputTxt.Name = "OutputTxt";
            this.OutputTxt.Size = new System.Drawing.Size(348, 502);
            this.OutputTxt.TabIndex = 8;
            this.OutputTxt.Text = "";
            // 
            // OutputHeader
            // 
            this.OutputHeader.AutoSize = true;
            this.OutputHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputHeader.Location = new System.Drawing.Point(628, 5);
            this.OutputHeader.Name = "OutputHeader";
            this.OutputHeader.Size = new System.Drawing.Size(62, 21);
            this.OutputHeader.TabIndex = 9;
            this.OutputHeader.Text = "Output:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Input:";
            // 
            // SelectedMethodLbl
            // 
            this.SelectedMethodLbl.AutoEllipsis = true;
            this.SelectedMethodLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectedMethodLbl.Location = new System.Drawing.Point(123, 464);
            this.SelectedMethodLbl.Name = "SelectedMethodLbl";
            this.SelectedMethodLbl.Size = new System.Drawing.Size(235, 21);
            this.SelectedMethodLbl.TabIndex = 11;
            // 
            // SelectedTypeNameLbl
            // 
            this.SelectedTypeNameLbl.AutoEllipsis = true;
            this.SelectedTypeNameLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectedTypeNameLbl.Location = new System.Drawing.Point(98, 435);
            this.SelectedTypeNameLbl.Name = "SelectedTypeNameLbl";
            this.SelectedTypeNameLbl.Size = new System.Drawing.Size(184, 21);
            this.SelectedTypeNameLbl.TabIndex = 12;
            // 
            // SelectedParametersLbl
            // 
            this.SelectedParametersLbl.AutoEllipsis = true;
            this.SelectedParametersLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectedParametersLbl.Location = new System.Drawing.Point(364, 438);
            this.SelectedParametersLbl.Name = "SelectedParametersLbl";
            this.SelectedParametersLbl.Size = new System.Drawing.Size(234, 21);
            this.SelectedParametersLbl.TabIndex = 13;
            // 
            // OutputFieldLbl
            // 
            this.OutputFieldLbl.AutoEllipsis = true;
            this.OutputFieldLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OutputFieldLbl.ForeColor = System.Drawing.Color.IndianRed;
            this.OutputFieldLbl.Location = new System.Drawing.Point(12, 518);
            this.OutputFieldLbl.Name = "OutputFieldLbl";
            this.OutputFieldLbl.Size = new System.Drawing.Size(586, 21);
            this.OutputFieldLbl.TabIndex = 14;
            this.OutputFieldLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 548);
            this.Controls.Add(this.OutputFieldLbl);
            this.Controls.Add(this.SelectedParametersLbl);
            this.Controls.Add(this.SelectedTypeNameLbl);
            this.Controls.Add(this.SelectedMethodLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputHeader);
            this.Controls.Add(this.OutputTxt);
            this.Controls.Add(this.TestInputOutputBtn);
            this.Controls.Add(this.ParametersInputTxt);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.DllOutputTreeView);
            this.Controls.Add(this.DllPathLbl);
            this.Controls.Add(this.SelectDllBtn);
            this.Name = "BaseForm";
            this.Text = ".dll Interpreter v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SelectDllBtn;
        private Label DllPathLbl;
        private TreeView DllOutputTreeView;
        private Label Label3;
        private Label label2;
        private Label Label4;
        private TextBox ParametersInputTxt;
        private Button TestInputOutputBtn;
        private RichTextBox OutputTxt;
        private Label OutputHeader;
        private Label label1;
        private Label SelectedMethodLbl;
        private Label SelectedTypeNameLbl;
        private Label SelectedParametersLbl;
        private Label OutputFieldLbl;
    }
}