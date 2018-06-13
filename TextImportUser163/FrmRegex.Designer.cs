namespace TextImportUser163
{
    partial class FrmRegex
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
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.txtRegexText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(12, 12);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotice.Size = new System.Drawing.Size(800, 300);
            this.txtNotice.TabIndex = 0;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 339);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(601, 21);
            this.txtPath.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "路径选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(12, 410);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(90, 30);
            this.btnExec.TabIndex = 3;
            this.btnExec.Text = "执  行";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // txtRegexText
            // 
            this.txtRegexText.Location = new System.Drawing.Point(12, 375);
            this.txtRegexText.Name = "txtRegexText";
            this.txtRegexText.Size = new System.Drawing.Size(379, 21);
            this.txtRegexText.TabIndex = 4;
            // 
            // FrmRegex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 497);
            this.Controls.Add(this.txtRegexText);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtNotice);
            this.Name = "FrmRegex";
            this.Text = "FrmRegex";
            this.Load += new System.EventHandler(this.FrmRegex_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.TextBox txtRegexText;
    }
}