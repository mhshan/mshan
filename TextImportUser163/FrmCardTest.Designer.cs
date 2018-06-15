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
            this.btnCash = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnFiles = new System.Windows.Forms.Button();
            this.btnConsume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 329);
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
            this.btnClose.Location = new System.Drawing.Point(263, 402);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭端口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReadBalance
            // 
            this.btnReadBalance.Location = new System.Drawing.Point(130, 329);
            this.btnReadBalance.Name = "btnReadBalance";
            this.btnReadBalance.Size = new System.Drawing.Size(90, 32);
            this.btnReadBalance.TabIndex = 3;
            this.btnReadBalance.Text = "读卡余额";
            this.btnReadBalance.UseVisualStyleBackColor = true;
            this.btnReadBalance.Click += new System.EventHandler(this.btnReadBalance_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(263, 329);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(90, 32);
            this.btnReadData.TabIndex = 4;
            this.btnReadData.Text = "读卡数据";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // btnCash
            // 
            this.btnCash.Location = new System.Drawing.Point(410, 329);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(90, 32);
            this.btnCash.TabIndex = 5;
            this.btnCash.Text = " 充  值 ";
            this.btnCash.UseVisualStyleBackColor = true;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(544, 329);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(90, 32);
            this.btnEnable.TabIndex = 6;
            this.btnEnable.Text = "设置互联互通";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnFiles
            // 
            this.btnFiles.Location = new System.Drawing.Point(12, 402);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(90, 32);
            this.btnFiles.TabIndex = 7;
            this.btnFiles.Text = "读文件";
            this.btnFiles.UseVisualStyleBackColor = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnConsume
            // 
            this.btnConsume.Location = new System.Drawing.Point(130, 402);
            this.btnConsume.Name = "btnConsume";
            this.btnConsume.Size = new System.Drawing.Size(90, 32);
            this.btnConsume.TabIndex = 8;
            this.btnConsume.Text = " 消  费 ";
            this.btnConsume.UseVisualStyleBackColor = true;
            this.btnConsume.Click += new System.EventHandler(this.btnConsume_Click);
            // 
            // FrmCardTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 475);
            this.Controls.Add(this.btnConsume);
            this.Controls.Add(this.btnFiles);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.btnCash);
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
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.Button btnConsume;
    }
}