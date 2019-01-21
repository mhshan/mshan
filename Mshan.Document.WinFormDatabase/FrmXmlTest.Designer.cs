namespace Mshan.Document.WinFormDatabase
{
    partial class FrmXmlTest
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
            this.plButtons = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gboxPrinter = new System.Windows.Forms.GroupBox();
            this.cmbThermalPrinter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNeedlePrinter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtHeight1 = new System.Windows.Forms.TextBox();
            this.txtWidth1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.plButtons.SuspendLayout();
            this.gboxPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.button3);
            this.plButtons.Controls.Add(this.button2);
            this.plButtons.Location = new System.Drawing.Point(6, 44);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(536, 58);
            this.plButtons.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(181, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 38);
            this.button3.TabIndex = 1;
            this.button3.Text = "获取";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 38);
            this.button2.TabIndex = 0;
            this.button2.Text = "设置打印";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gboxPrinter
            // 
            this.gboxPrinter.Controls.Add(this.cmbThermalPrinter);
            this.gboxPrinter.Controls.Add(this.label2);
            this.gboxPrinter.Controls.Add(this.cmbNeedlePrinter);
            this.gboxPrinter.Controls.Add(this.label6);
            this.gboxPrinter.Controls.Add(this.plButtons);
            this.gboxPrinter.Location = new System.Drawing.Point(369, 411);
            this.gboxPrinter.Name = "gboxPrinter";
            this.gboxPrinter.Size = new System.Drawing.Size(536, 127);
            this.gboxPrinter.TabIndex = 12;
            this.gboxPrinter.TabStop = false;
            this.gboxPrinter.Text = "设置打印机";
            // 
            // cmbThermalPrinter
            // 
            this.cmbThermalPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThermalPrinter.FormattingEnabled = true;
            this.cmbThermalPrinter.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cmbThermalPrinter.Location = new System.Drawing.Point(148, 82);
            this.cmbThermalPrinter.Name = "cmbThermalPrinter";
            this.cmbThermalPrinter.Size = new System.Drawing.Size(348, 20);
            this.cmbThermalPrinter.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "热敏打印机：";
            // 
            // cmbNeedlePrinter
            // 
            this.cmbNeedlePrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNeedlePrinter.FormattingEnabled = true;
            this.cmbNeedlePrinter.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cmbNeedlePrinter.Location = new System.Drawing.Point(148, 32);
            this.cmbNeedlePrinter.Name = "cmbNeedlePrinter";
            this.cmbNeedlePrinter.Size = new System.Drawing.Size(348, 20);
            this.cmbNeedlePrinter.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "针式打印机：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 14;
            // 
            // pbPicture
            // 
            this.pbPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbPicture.Location = new System.Drawing.Point(60, 36);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(562, 336);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPicture.TabIndex = 15;
            this.pbPicture.TabStop = false;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(713, 40);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(170, 21);
            this.txtWidth.TabIndex = 16;
            this.txtWidth.Text = "500";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(716, 74);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(170, 21);
            this.txtHeight.TabIndex = 17;
            this.txtHeight.Text = "500";
            // 
            // txtHeight1
            // 
            this.txtHeight1.Location = new System.Drawing.Point(718, 149);
            this.txtHeight1.Name = "txtHeight1";
            this.txtHeight1.Size = new System.Drawing.Size(170, 21);
            this.txtHeight1.TabIndex = 19;
            // 
            // txtWidth1
            // 
            this.txtWidth1.Location = new System.Drawing.Point(717, 113);
            this.txtWidth1.Name = "txtWidth1";
            this.txtWidth1.Size = new System.Drawing.Size(170, 21);
            this.txtWidth1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "纸Width：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "纸Height：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(635, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "图片Width：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(635, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "图片Height：";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(779, 189);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 28);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "打  印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(683, 189);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(90, 28);
            this.btnUpload.TabIndex = 25;
            this.btnUpload.Text = "加载图片";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // FrmXmlTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 513);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeight1);
            this.Controls.Add(this.txtWidth1);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.pbPicture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gboxPrinter);
            this.Name = "FrmXmlTest";
            this.Text = "FrmXmlTest";
            this.plButtons.ResumeLayout(false);
            this.gboxPrinter.ResumeLayout(false);
            this.gboxPrinter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.GroupBox gboxPrinter;
        private System.Windows.Forms.ComboBox cmbThermalPrinter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNeedlePrinter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtHeight1;
        private System.Windows.Forms.TextBox txtWidth1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnUpload;
    }
}