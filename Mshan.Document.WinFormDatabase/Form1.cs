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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool IsStop
        {
            get;
            set;
        }
        public string UserName = "CCENSE";
        System.Threading.Thread thread = null;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            IsStop = false;
            thread = new System.Threading.Thread(new System.Threading.ThreadStart(Process));
            thread.Start();
        }

        public void Process()
        {
            string fullFileName = txtPath.Text;
            string table = string.Format("'{0}'", txtNotice.Text.Replace("\r\n", "','"));
            CreateWord(fullFileName);
            WriteControl(string.Format("创建{0}成功！", fullFileName));
            System.Data.DataTable userDataTable = OracleDocument.GetAllUserTable();
            if (!cbIsAllTable.Checked)
            {
                userDataTable.DefaultView.RowFilter = string.Format(" table_name in({0})", table);
                userDataTable = userDataTable.DefaultView.ToTable();
            }
            WordHelper wordHelper = new WordHelper();
            wordHelper.OpenDocument(fullFileName);
            WriteControl(string.Format("{1}开始生成表,共{0}个………………", userDataTable.Rows.Count, DateTime.Now.ToString("HH:mm:ss")));

            for (int i = 1; i <= userDataTable.Rows.Count; i++)
            {
                Table userTable = DocumentLoad.GetTableEntityByDataRow(userDataTable.Rows[i - 1]);
                WriteControl(string.Format("{2} 第{0}个,{1}表………………", i, userTable.TableName, DateTime.Now.ToString("HH:mm:ss")));
                wordHelper.SetFont(14f);
                wordHelper.InsertText(string.Format("{0}、{1}({2})", i, userTable.TableName, userTable.Comments));
                CreateWordTables(userTable, wordHelper);
                WriteControl(string.Format("{1} {0}表生成成功！", userTable.TableName, DateTime.Now.ToString("HH:mm:ss")));
                if (IsStop)
                    break;
            }
            wordHelper.SaveDocument(fullFileName);
            MessageBox.Show(string.Format("文档生成成功！", fullFileName));
        }
        public void CreateWordTables(Table userTable, WordHelper wordHelper)
        {
            wordHelper.SetFont(11f);
            Microsoft.Office.Interop.Word.Table wordTable = wordHelper.InsertTable(3, 4, 500);
            SetColumnWidth(wordTable);
            int pointer = 1;
            pointer = TableHeader(userTable, pointer, wordTable);
            pointer = TableColumnName(pointer, wordTable);
            pointer = TableColumns(userTable.Columns, pointer, wordTable);
            pointer = TableIndexes(userTable.Indexes, pointer, wordTable);
            pointer = TableTrigger(userTable.Triggeres, pointer, wordTable);
        }
        public void CreateWord(string fullFileName)
        {
            WordHelper wordHelper = new WordHelper();
            wordHelper.killWinWordProcess();
            if (System.IO.File.Exists(fullFileName))
                System.IO.File.Delete(fullFileName);
            wordHelper.CreateNewDocument();
            wordHelper.SetFont(20f, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
            wordHelper.InsertText("公交表结构文档");

            wordHelper.SaveDocument(fullFileName);
        }
        public void SetColumnWidth(Microsoft.Office.Interop.Word.Table wordTable)
        {
            wordTable.Columns[1].Width = 110;
            wordTable.Columns[2].Width = 100;
            wordTable.Columns[3].Width = 55;
            wordTable.Columns[4].Width = 190;

        }
        public int TableHeader(Table userTable, int pointer, Microsoft.Office.Interop.Word.Table wordTable)
        {
            
            wordTable.Cell( pointer, 1).Merge(wordTable.Cell(pointer, 4));
            wordTable.Rows[1].Cells[1].Range.Text = string.Format("{0}({1}){2}", userTable.TableName, userTable.TableSpace, userTable.Comments);
            return pointer + 1;
        }
        public int TableColumnName(int pointer, Microsoft.Office.Interop.Word.Table wordTable)
        {
            wordTable.Rows[2].Cells[1].Range.Text = "列名";
            //wordTable.Rows[2].Cells[1].Range.wi = "列名";
            wordTable.Rows[2].Cells[2].Range.Text = "类型";
            wordTable.Rows[2].Cells[3].Range.Text = "是否为空";
            wordTable.Rows[2].Cells[4].Range.Text = "描述";
            return pointer + 1;
        }
        public int TableColumns(Dictionary<string,Column> columnDictionary,int pointer, Microsoft.Office.Interop.Word.Table wordTable)
        {
            foreach (KeyValuePair<string, Column> column in columnDictionary)
            {
                object miss = System.Reflection.Missing.Value;
                wordTable.Rows.Add(ref miss);
                wordTable.Rows[pointer].Cells[1].Range.Text = column.Value.ColumnName;
                wordTable.Rows[pointer].Cells[2].Range.Text = string.Format("{0}({1})", column.Value.ColumnType, column.Value.ColumnLength);
                wordTable.Rows[pointer].Cells[3].Range.Text = column.Value.NullAble;
                string defaultValue = string.IsNullOrWhiteSpace(column.Value.DefaultValue) ? string.Empty : string.Format("\n默认值：{0}", column.Value.DefaultValue);
                wordTable.Rows[pointer].Cells[4].Range.Text = string.Format("{0}{1}", column.Value.Comments,defaultValue);
                pointer++;
            }
            return pointer;
        }

        public int TableIndexes(Dictionary<string, Index> indexDictionary, int pointer, Microsoft.Office.Interop.Word.Table wordTable)
        {
            if (indexDictionary.Count == 0)
                return pointer; 
            foreach (KeyValuePair<string,Index> index in  indexDictionary)
            {
                object miss = System.Reflection.Missing.Value;
                wordTable.Rows.Add(ref miss); 
                wordTable.Cell(pointer, 2).Merge(wordTable.Cell(pointer, 4));
                string columns = string.Empty;
                foreach (System.Collections.Generic.KeyValuePair<string, string> indexColumn in index.Value.Columns)
                    columns += string.Format("{0} {1},", indexColumn.Key, indexColumn.Value);
                columns=columns.TrimEnd(',');
                wordTable.Cell(pointer, 2).Range.Text = string.Format("{0}索引{1}({2}):({3})", index.Value.Uniqueness, index.Value.IndexName, index.Value.TableSpace, columns); 
                pointer++;
            }
            if (indexDictionary.Count > 1)
                wordTable.Cell(pointer - indexDictionary.Count, 1).Merge(wordTable.Cell(pointer-1, 1));
            wordTable.Cell(pointer - indexDictionary.Count,1).Range.Text = "索引";
            return pointer;
        }

        public int TableTrigger(Dictionary<string, Trigger> triggerDictionary, int pointer, Microsoft.Office.Interop.Word.Table wordTable)
        {
            if (triggerDictionary.Count == 0)
                return pointer;
            foreach (KeyValuePair<string, Trigger> trigger in triggerDictionary)
            {
                object miss = System.Reflection.Missing.Value;
                wordTable.Rows.Add(ref miss);
                wordTable.Cell(pointer, 2).Merge(wordTable.Cell(pointer, 4));
                wordTable.Cell(pointer, 2).Range.Text = string.Format("{0}({1}):\n({2})", trigger.Value.TriggerName, trigger.Value.TriggeringEvent, trigger.Value.TriggerBody);
                pointer++;
            }
            if (triggerDictionary.Count > 1)
                wordTable.Cell(pointer - triggerDictionary.Count, 1).Merge(wordTable.Cell(pointer-1, 1));
            wordTable.Cell(pointer - triggerDictionary.Count,1).Range.Text = "触发器";
            return pointer;
        }


        public void CreateTable(Table userTable, WordHelper wordHelper,int pointer)
        {

        }
        public void WriteControl(string text)
        {
            //if (this.InvokeRequired)
            //{
                this.Invoke(new Action( () =>
                       {
                           txtNotice.AppendText(text + "\r\n");
                           txtNotice.ScrollToCaret();
                       }));
            //}
            //else
            
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            txtPath.Text = Application.StartupPath + "\\oracle.docx";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            IsStop = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNotice.Text = string.Empty;
            for (int i = 0; i < 100000; i++)
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection("Server=shan\\shan;UID=sa;Pwd=sasasa;Database=master");
                conn.Open();
            }
        }

        private void btnTablePartition_Click(object sender, EventArgs e)
        {
            System.Data.DataTable partition = OracleDocument.GetTablePartition();
            txtNotice.AppendText(string.Format("\r\n表名, 分区名,表记录数,最大值\r\n"));
            foreach (System.Data.DataRow dataRow in partition.Rows)
            {
                // table_name,partition_name,num_rows,high_value
                txtNotice.AppendText((dataRow["table_name"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText((dataRow["partition_name"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText((dataRow["num_rows"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText(dataRow["high_value"].ToString().PadLeft(20, ' '));
                txtNotice.AppendText("\r\n");
                System.Data.DataTable subPartition = OracleDocument.GetSubPartitionByTableAndPartition(dataRow["table_name"].ToString(),dataRow["partition_name"].ToString());
                foreach (System.Data.DataRow subDataRow in subPartition.Rows)
                {
                    txtNotice.AppendText( "子分区,".PadLeft(20, ' '));
                    txtNotice.AppendText((subDataRow["subpartition_name"].ToString() + ",").PadLeft(20, ' '));
                    txtNotice.AppendText((subDataRow["subpartition_position"].ToString() + ",").PadLeft(20, ' '));
                    txtNotice.AppendText(subDataRow["high_value"].ToString().PadLeft(20, ' '));
                    txtNotice.AppendText("\r\n");
                }

            }
            txtNotice.ScrollToCaret();
        }

        private void btnTableSpace_Click(object sender, EventArgs e)
        {
            System.Data.DataTable partition = OracleDocument.GetTableSpaceDetail();
            txtNotice.AppendText(string.Format("\r\n表空间, 最大,当前,空闲,使用率,区块,文件\r\n"));
            foreach (System.Data.DataRow dataRow in partition.Rows)
            {
                //tablespace_name, max_bytes,current_bytes,freespace,userate,spaceblock,file_id,file_name
                txtNotice.AppendText((dataRow["tablespace_name"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText((dataRow["max_bytes"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText((dataRow["current_bytes"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText((dataRow["freespace"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText((dataRow["userate"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText((dataRow["spaceblock"].ToString() + ",").PadLeft(20, ' '));
                txtNotice.AppendText((dataRow["file_name"].ToString()));
                txtNotice.AppendText("\r\n");

            }
            txtNotice.ScrollToCaret();
        }

        private void btnPartition_Click(object sender, EventArgs e)
        {
            System.Data.DataTable partition = OracleDocument.GetTableAndUseDetail();
            txtNotice.AppendText(string.Format("\r\n表名, 大小\r\n"));
            foreach (System.Data.DataRow dataRow in partition.Rows)
            {
                // table_name,partition_name,num_rows,high_value
                txtNotice.AppendText((dataRow["segment_name"].ToString() + ",").PadLeft(50, ' '));
                txtNotice.AppendText(dataRow["mbytese"].ToString().PadLeft(20, ' '));
                txtNotice.AppendText("\r\n");

            }
            txtNotice.ScrollToCaret();
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            thread = new System.Threading.Thread(new System.Threading.ThreadStart(()=>{
                OracleDocument.InsertLanguageItem(string.Empty, string.Empty, 0);
            // PKG_ALERT
            WriteControl("生成开始——————————————————————————————");
            System.Data.DataTable procedureList=OracleDocument.GetAllProcedure();
            foreach (System.Data.DataRow dr in procedureList.Rows)
            {
                //txtNotice.Text = string.Empty;
                string path = string.Format("{0}\\{1}.sql",txtPath.Text,dr["name"].ToString());
                WriterFile("CREATE OR REPLACE ", path);
                int index = OracleDocument.LanguageMaxIndex(dr["name"].ToString());
                System.Data.DataTable procedure = OracleDocument.GetProcedureByName(dr["name"].ToString(), "PACKAGE BODY");
                string textCn = string.Empty;
                WriteControl(string.Format("正在生成{0}.sql……………………\n\r", dr["name"].ToString().ToLower()));
                foreach (System.Data.DataRow dataRow in procedure.Rows)
                { 
                   
                    // table_name,partition_name,num_rows,high_value
                    string text = dataRow["text"].ToString();
                    System.Text.RegularExpressions.MatchCollection collection = System.Text.RegularExpressions.Regex.Matches(text, "'([^'-]*[\u4e00-\u9fa5]+[^']*)'");
                    foreach (System.Text.RegularExpressions.Match match in collection)
                    {
                        text = text.Replace(match.Groups[0].Value, string.Format("LANGUAGE('{0}','--{2}',{1})", dr["name"].ToString().ToLower(), index, match.Groups[1].Value));//System.Text.RegularExpressions.Regex.Replace(text, "'([^']*[\u4e00-\u9fa5]+[^']*)'",@"'\1'");
                        textCn = match.Groups[1].Value;
                        OracleDocument.InsertLanguageItem(dr["name"].ToString().ToLower(),textCn,index);
                        index++;
                        //OracleDocument.UpdateProcedureLine(txtPath.Text,"PACKAGE BODY",Convert.ToInt32(dataRow["line"]),text.Replace("'","''"));
                    }

                    WriterFile(text,path);
                    //txtNotice.AppendText("\r\n");

                }
                WriterFile("/", path);
                //txtNotice.ScrollToCaret();
            }
            WriteControl("生成结束——————————————————————————————");
            }
            ));
            thread.Start();
        }
        public static void WriterFile(string text,string path)
        { 
            System.IO.StreamWriter rw = System.IO.File.AppendText(path);
            rw.WriteLine(text);
            rw.Flush();
            rw.Close();
        }

        

        private void btnCopy_Click(object sender, EventArgs e)
        {
            FrmCreateDatabase database = new FrmCreateDatabase();
            database.ShowDialog(this);
        }

        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            DataTable dtTable = OracleDocument.GetTablesByUser(UserName);

            dtTable.DefaultView.Sort = "table_name asc";

            foreach (DataRow dataRow in dtTable.DefaultView.ToTable().Rows)
            {
                WriteControl(dataRow["table_name"].ToString());
            }
        }
    }
}
