namespace Mshan.Document.WinFormDatabase
{
    partial class FrmCreateDatabase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateDatabase));
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.clbType = new System.Windows.Forms.CheckedListBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtExcludeTable = new System.Windows.Forms.TextBox();
            this.btnSearchData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(22, 12);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotice.Size = new System.Drawing.Size(900, 360);
            this.txtNotice.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(169, 463);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(90, 32);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = " 生  成 ";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // clbType
            // 
            this.clbType.FormattingEnabled = true;
            this.clbType.Items.AddRange(new object[] {
            "表",
            "类型",
            "视图",
            "包",
            "存储过程",
            "函数",
            "序列",
            "数据"});
            this.clbType.Location = new System.Drawing.Point(22, 378);
            this.clbType.Name = "clbType";
            this.clbType.Size = new System.Drawing.Size(120, 164);
            this.clbType.TabIndex = 2;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(236, 396);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(686, 21);
            this.txtPath.TabIndex = 3;
            // 
            // txtExcludeTable
            // 
            this.txtExcludeTable.Location = new System.Drawing.Point(236, 430);
            this.txtExcludeTable.Name = "txtExcludeTable";
            this.txtExcludeTable.Size = new System.Drawing.Size(686, 21);
            this.txtExcludeTable.TabIndex = 4;
            this.txtExcludeTable.Text = resources.GetString("txtExcludeTable.Text");
            // 
            // btnSearchData
            // 
            this.btnSearchData.Location = new System.Drawing.Point(280, 463);
            this.btnSearchData.Name = "btnSearchData";
            this.btnSearchData.Size = new System.Drawing.Size(120, 32);
            this.btnSearchData.TabIndex = 5;
            this.btnSearchData.Text = "查询表数据数量";
            this.btnSearchData.UseVisualStyleBackColor = true;
            this.btnSearchData.Click += new System.EventHandler(this.btnSearchData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = " 路  径：";
            // 
            // cbTable
            // 
            this.cbTable.AutoSize = true;
            this.cbTable.Checked = true;
            this.cbTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTable.Location = new System.Drawing.Point(175, 434);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(60, 16);
            this.cbTable.TabIndex = 8;
            this.cbTable.Text = "排除表";
            this.cbTable.UseVisualStyleBackColor = true;
            // 
            // FrmCreateDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 555);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchData);
            this.Controls.Add(this.txtExcludeTable);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.clbType);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtNotice);
            this.Name = "FrmCreateDatabase";
            this.Load += new System.EventHandler(this.FrmCreateDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckedListBox clbType;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtExcludeTable;
        private System.Windows.Forms.Button btnSearchData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbTable;
    }
}