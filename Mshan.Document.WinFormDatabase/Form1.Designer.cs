namespace Mshan.Document.WinFormDatabase
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTableSpace = new System.Windows.Forms.Button();
            this.btnPartition = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTablePartition = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSearchTable = new System.Windows.Forms.Button();
            this.cbIsAllTable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(12, 12);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotice.Size = new System.Drawing.Size(949, 261);
            this.txtNotice.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(114, 335);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(90, 30);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "  生  成 ";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 295);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(949, 21);
            this.txtPath.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(224, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = " 停  止 ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTableSpace
            // 
            this.btnTableSpace.Location = new System.Drawing.Point(336, 335);
            this.btnTableSpace.Name = "btnTableSpace";
            this.btnTableSpace.Size = new System.Drawing.Size(90, 30);
            this.btnTableSpace.TabIndex = 4;
            this.btnTableSpace.Text = "空间使用情况";
            this.btnTableSpace.UseVisualStyleBackColor = true;
            this.btnTableSpace.Click += new System.EventHandler(this.btnTableSpace_Click);
            // 
            // btnPartition
            // 
            this.btnPartition.Location = new System.Drawing.Point(556, 335);
            this.btnPartition.Name = "btnPartition";
            this.btnPartition.Size = new System.Drawing.Size(90, 30);
            this.btnPartition.TabIndex = 5;
            this.btnPartition.Text = "表和索引空间";
            this.btnPartition.UseVisualStyleBackColor = true;
            this.btnPartition.Click += new System.EventHandler(this.btnPartition_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(782, 335);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = " 清  空 ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTablePartition
            // 
            this.btnTablePartition.Location = new System.Drawing.Point(449, 335);
            this.btnTablePartition.Name = "btnTablePartition";
            this.btnTablePartition.Size = new System.Drawing.Size(90, 30);
            this.btnTablePartition.TabIndex = 7;
            this.btnTablePartition.Text = "分区情况";
            this.btnTablePartition.UseVisualStyleBackColor = true;
            this.btnTablePartition.Click += new System.EventHandler(this.btnTablePartition_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(668, 335);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 30);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "备份数据库";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSearchTable
            // 
            this.btnSearchTable.Location = new System.Drawing.Point(12, 335);
            this.btnSearchTable.Name = "btnSearchTable";
            this.btnSearchTable.Size = new System.Drawing.Size(90, 30);
            this.btnSearchTable.TabIndex = 9;
            this.btnSearchTable.Text = " 查 询 表";
            this.btnSearchTable.UseVisualStyleBackColor = true;
            this.btnSearchTable.Click += new System.EventHandler(this.btnSearchTable_Click);
            // 
            // cbIsAllTable
            // 
            this.cbIsAllTable.AutoSize = true;
            this.cbIsAllTable.Checked = true;
            this.cbIsAllTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsAllTable.Location = new System.Drawing.Point(980, 257);
            this.cbIsAllTable.Name = "cbIsAllTable";
            this.cbIsAllTable.Size = new System.Drawing.Size(84, 16);
            this.cbIsAllTable.TabIndex = 10;
            this.cbIsAllTable.Text = "生成全部表";
            this.cbIsAllTable.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 450);
            this.Controls.Add(this.cbIsAllTable);
            this.Controls.Add(this.btnSearchTable);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnTablePartition);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPartition);
            this.Controls.Add(this.btnTableSpace);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtNotice);
            this.Name = "Form1";
            this.Text = "Oracle文档导出";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTableSpace;
        private System.Windows.Forms.Button btnPartition;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTablePartition;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSearchTable;
        private System.Windows.Forms.CheckBox cbIsAllTable;
    }
}

