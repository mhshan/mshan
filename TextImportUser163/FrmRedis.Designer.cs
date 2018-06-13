namespace TextImportUser163
{
    partial class FrmRedis
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
            this.btnConnection = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(46, 231);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(90, 32);
            this.btnConnection.TabIndex = 0;
            this.btnConnection.Text = "连接";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(36, 34);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(379, 21);
            this.txtData.TabIndex = 1;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(164, 231);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(90, 32);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "获取key";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(36, 92);
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(460, 21);
            this.txtNotice.TabIndex = 3;
            // 
            // FrmRedis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 420);
            this.Controls.Add(this.txtNotice);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnConnection);
            this.Name = "FrmRedis";
            this.Text = "Redis测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtNotice;
    }
}