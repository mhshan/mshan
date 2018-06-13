using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextImportUser163
{
    public partial class FrmRegex : Form
    {
        public FrmRegex()
        {
            InitializeComponent();
        }
        public static string FilePath;
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (string.IsNullOrEmpty(FilePath))
                folderDialog.SelectedPath = Application.StartupPath;
            else
                folderDialog.SelectedPath = FilePath;
            if (folderDialog.ShowDialog(this) == DialogResult.OK)
            {

                    txtPath.Text = folderDialog.SelectedPath;
                    FilePath = folderDialog.SelectedPath;
                    txtNotice.Text = string.Empty;
                    System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(folderDialog.SelectedPath);
                    System.IO.FileInfo[] file = dirInfo.GetFiles();
                    for (int i = 0; i < file.Length; i++)
                    {
                        if (IsExtension(file[i].FullName))
                        {
                            txtNotice.Text += file[i].FullName + "\r\n";
                        }
                    }
                
            }
        }

        public string[] Extension
        {
            get { return new string[] { ".sql", ".txt" }; }
        }

        public bool IsExtension(string fileName)
        {
            for (int i = 0; i < Extension.Length; i++)
            {
                if (fileName.EndsWith(Extension[i]))
                    return true;
            }
            return false;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
             string[] sqlPathList = txtNotice.Text.Replace("\r\n","\n").Split('\n');
            txtNotice.Text = string.Empty;
             
                WriteControl("执行开始——————————————————————————————");
                foreach (string sqlPath in sqlPathList)
                {  
                    WriteControl(string.Format("正在执行{0}……………………………………",sqlPath));
                    if (!string.IsNullOrEmpty(sqlPath) && System.IO.File.Exists(sqlPath))
                    {
                        string sql = ReaderFile(sqlPath);
                        string[] sqlArrary = System.Text.RegularExpressions.Regex.Split(sql,"\r\n");
                        for (int i = 0; i < sqlArrary.Length; i++)
                        {
                            if ((!string.IsNullOrWhiteSpace(sqlArrary[i])) && System.Text.RegularExpressions.Regex.IsMatch(sql, txtRegexText.Text))
                                WriteControl(sqlArrary[i]);
                        }
                      
                    }
                }
                WriteControl("执行结束——————————————————————————————");
                FilePath = txtPath.Text;
             
        }
        public static string ReaderFile(string path)
        {
            System.IO.StreamReader stringReader = new System.IO.StreamReader(path);
            string text = stringReader.ReadToEnd();
            stringReader.Dispose();
            stringReader.Close();
            return text;
        }
        public void WriteControl(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtNotice.AppendText(text + "\r\n");
                    txtNotice.ScrollToCaret();
                }));
            }

        }

        private void FrmRegex_Load(object sender, EventArgs e)
        {
            txtPath.Text = Application.StartupPath;
        }
    }
}
