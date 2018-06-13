using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mshan.Utilities.DbUtilities;
using Mshan.Document.Database;
using Mshan.Document.Database.TableEntity;
using Mshan.Utilities;
namespace Mshan.Document.WinFormDatabase
{
    public partial class FrmLanguageTool : Form
    {
        public FrmLanguageTool()
        {
            InitializeComponent();
        }
        public static string ProcdurePath
        {
            get;
            set;
        }
        public bool IsStop
        {
            get;
            set;
        }
        System.Threading.Thread thread = null;
        
        public void WriteControl(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action( () =>
                       {
                           txtNotice.AppendText(text + "\r\n");
                           txtNotice.ScrollToCaret();
                       }));
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPath.Text = Application.StartupPath;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            IsStop = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNotice.Text = string.Empty;
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            thread = new System.Threading.Thread(new System.Threading.ThreadStart(()=>{
            WriteControl("生成开始——————————————————————————————"); 
            string language="zh-CN";
            System.Data.DataTable procedureList=OracleDocument.GetAllProcedure();
            foreach (System.Data.DataRow dr in procedureList.Rows)
            {
                //txtNotice.Text = string.Empty;
               
                string path = string.Format("{0}\\{1}.sql",txtPath.Text,dr["name"].ToString());
                WriterFile("CREATE OR REPLACE \r\n", path);
                int index = OracleDocument.LanguageMaxIndex(dr["name"].ToString().ToLower(),language);
                System.Data.DataTable procedure = OracleDocument.GetProcedureByName(dr["name"].ToString(), "PACKAGE BODY");
                string textCn = string.Empty;
                WriteControl(string.Format("正在生成{0}.sql……………………\n\r", dr["name"].ToString().ToLower()));
                foreach (System.Data.DataRow dataRow in procedure.Rows)
                { 
                    string text = dataRow["text"].ToString();
                    System.Text.RegularExpressions.MatchCollection collection = System.Text.RegularExpressions.Regex.Matches(text, "'([^'%]*[\u4e00-\u9fa5]+[^']*)'");
                    foreach (System.Text.RegularExpressions.Match match in collection)
                    {
                        text = text.Replace(match.Groups[0].Value, string.Format("LANGUAGE('{0}',{1},'%{2}')", dr["name"].ToString().ToLower(), index, match.Groups[1].Value));
                        //text = text.Replace(match.Groups[0].Value, string.Format("LANGUAGE('{0}',{1})", dr["name"].ToString().ToLower(), index));//System.Text.RegularExpressions.Regex.Replace(text, "'([^']*[\u4e00-\u9fa5]+[^']*)'",@"'\1'");
                        textCn = match.Groups[1].Value;
                        OracleDocument.InsertLanguageItem(dr["name"].ToString().ToLower(), textCn, index, language);
                        index++;
                    }

                    WriterFile(text.Replace("\n","\r\n"),path);
                }
            }
            WriteControl("生成结束——————————————————————————————");
            ProcdurePath = txtPath.Text;
            }
            ));
            thread.Start();
        }
        public static void WriterFile(string text,string path)
        { 
            System.IO.StreamWriter rw = System.IO.File.AppendText(path);
            rw.Write(text);
            rw.Flush();
            rw.Close();
        }
        public static string WriterFile(string path)
        {
            System.IO.StreamReader stringReader = new System.IO.StreamReader(path);
            string text = stringReader.ReadToEnd();
            stringReader.Dispose();
            stringReader.Close();
            return text;
        }
        private void btnNav_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (string.IsNullOrEmpty(ProcdurePath))
                folderDialog.SelectedPath = Application.StartupPath;
            else
                folderDialog.SelectedPath = ProcdurePath;
            if (folderDialog.ShowDialog(this) == DialogResult.OK)
            {
                txtPath.Text = folderDialog.SelectedPath;
                ProcdurePath= folderDialog.SelectedPath;
                txtNotice.Text = string.Empty;
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(folderDialog.SelectedPath);
                System.IO.FileInfo[] file = dirInfo.GetFiles();
                for (int i = 0; i < file.Length; i++)
                {
                    if (IsExtension(file[i].FullName))
                    {
                        txtNotice.Text += file[i].FullName+"\r\n";
                    }
                }
            }
        }
        public string[] Extension
        {
            get { return new string[]{".sql",".txt"}; }
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
            string[] sqlPathList = txtNotice.Text.Split('\r','\n');
            txtNotice.Text = string.Empty;
            thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {

                WriteControl("执行开始——————————————————————————————");
                foreach (string sqlPath in sqlPathList)
                {
                    if (!string.IsNullOrEmpty(sqlPath) && System.IO.File.Exists(sqlPath))
                    {
                        string sql = WriterFile(sqlPath);
                        string[] sqlArrary = System.Text.RegularExpressions.Regex.Split(sql,"\r\n[ ]*/\r\n");
                        for (int i = 0; i < sqlArrary.Length; i++)
                        {
                            sqlArrary[i] = sqlArrary[i].Replace("\r\n", "\n");
                            if (!string.IsNullOrWhiteSpace(sqlArrary[i]))
                                OracleDocument.ExecSql(sqlArrary[i]);
                        }
                        WriteControl(string.Format("正在执行{0}……………………………………",sqlPath));
                    }
                }
                WriteControl("执行结束——————————————————————————————");
                ProcdurePath = txtPath.Text;
            }
            ));
            thread.Start();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                WriteControl("生成开始——————————————————————————————");
                System.Data.DataTable procedureList = OracleDocument.GetAllProcedure();
               
                foreach (System.Data.DataRow dr in procedureList.Rows)
                {
                     
                    //txtNotice.Text = string.Empty;
                    string path = string.Format("{0}\\{1}.sql", txtPath.Text, dr["name"].ToString());
                    System.IO.File.Delete(path);
                    WriterFile("CREATE OR REPLACE\r\n", path);
                    System.Data.DataTable procedureBody = OracleDocument.GetProcedureByName(dr["name"].ToString(), "PACKAGE");
                    WriteControl(string.Format("正在生成{0}.sql……………………\r\n", dr["name"].ToString().ToLower()));
                    foreach (System.Data.DataRow dataRow in procedureBody.Rows)
                    { 
                        string text = dataRow["text"].ToString();
                        WriterFile(text.Replace("\n","\r\n"), path);
                    }
                    WriterFile("/\r\n",path);
                    WriterFile("CREATE OR REPLACE\r\n", path);
                    System.Data.DataTable procedure = OracleDocument.GetProcedureByName(dr["name"].ToString(), "PACKAGE BODY");
                    //WriteControl(string.Format("正在生成{0}.sql……………………\r\n", dr["name"].ToString().ToLower()));
                    foreach (System.Data.DataRow dataRow in procedure.Rows)
                    {
                        string text = dataRow["text"].ToString();
                        WriterFile(text.Replace("\n", "\r\n"), path);
                    }
                }
                WriteControl("生成结束——————————————————————————————");
                ProcdurePath = txtPath.Text;
            }
            ));
            thread.Start();
        }

         
       

    }
}
