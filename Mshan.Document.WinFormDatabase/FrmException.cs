using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mshan.Document.WinFormDatabase
{
    public partial class FrmException : Form
    {
        public FrmException(object sender, Exception e)
        {
           
            InitializeComponent();
            textBox1.Text = e.Message+"\r\n";
            textBox1.Text += e.StackTrace;
        }
        public bool IsRun
        {
            get;
            private set;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            IsRun = false;
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsRun = true;
            this.Close();
        }

    }
}
