namespace Mshan.Document.WinFormDatabase
{
    partial class FrmLanguageTool
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnProcedure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNav = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(12, 12);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotice.Size = new System.Drawing.Size(912, 261);
            this.txtNotice.TabIndex = 0;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(105, 293);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(679, 21);
            this.txtPath.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(427, 335);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = " 清  空 ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnProcedure
            // 
            this.btnProcedure.Location = new System.Drawing.Point(207, 335);
            this.btnProcedure.Name = "btnProcedure";
            this.btnProcedure.Size = new System.Drawing.Size(90, 30);
            this.btnProcedure.TabIndex = 8;
            this.btnProcedure.Text = " 提  取 ";
            this.btnProcedure.UseVisualStyleBackColor = true;
            this.btnProcedure.Click += new System.EventHandler(this.btnProcedure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "存储过程路径：";
            // 
            // btnNav
            // 
            this.btnNav.Location = new System.Drawing.Point(804, 293);
            this.btnNav.Name = "btnNav";
            this.btnNav.Size = new System.Drawing.Size(75, 23);
            this.btnNav.TabIndex = 10;
            this.btnNav.Text = "浏览…";
            this.btnNav.UseVisualStyleBackColor = true;
            this.btnNav.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(315, 335);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(90, 30);
            this.btnExec.TabIndex = 11;
            this.btnExec.Text = "  执  行  ";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(105, 335);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 30);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = " 备  份 ";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FrmLanguageTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 389);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.btnNav);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcedure);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtNotice);
            this.Name = "FrmLanguageTool";
            this.Text = "Oracle package 国际化工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnProcedure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNav;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Button btnCopy;
    }
}

