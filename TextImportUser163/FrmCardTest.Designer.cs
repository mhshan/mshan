namespace TextImportUser163
{
    partial class FrmCardTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReadBalance = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开端口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(12, 12);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotice.Size = new System.Drawing.Size(750, 264);
            this.txtNotice.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(373, 303);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭端口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReadBalance
            // 
            this.btnReadBalance.Location = new System.Drawing.Point(132, 303);
            this.btnReadBalance.Name = "btnReadBalance";
            this.btnReadBalance.Size = new System.Drawing.Size(90, 32);
            this.btnReadBalance.TabIndex = 3;
            this.btnReadBalance.Text = "读卡余额";
            this.btnReadBalance.UseVisualStyleBackColor = true;
            this.btnReadBalance.Click += new System.EventHandler(this.btnReadBalance_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(252, 303);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(90, 32);
            this.btnReadData.TabIndex = 4;
            this.btnReadData.Text = "读卡数据";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // FrmCardTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 347);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.btnReadBalance);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNotice);
            this.Controls.Add(this.button1);
            this.Name = "FrmCardTest";
            this.Text = "FrmCardTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReadBalance;
        private System.Windows.Forms.Button btnReadData;
    }
}