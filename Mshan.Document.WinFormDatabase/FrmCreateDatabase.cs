using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mshan.Document.Database;
using Mshan.Utilities.DbUtilities;
namespace Mshan.Document.WinFormDatabase
{
    public partial class FrmCreateDatabase : Form
    {
        public FrmCreateDatabase()
        {
            InitializeComponent();
        }
        public string UserName = "CCENSE";
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(txtPath.Text))
                System.IO.Directory.CreateDirectory(txtPath.Text);
            System.Threading.ThreadPool.SetMaxThreads(10,5);
            for (int i = 0; i < clbType.Items.Count; i++)
            {
                if (clbType.GetItemChecked(i))
                {
                    //clbType.Items[i]
                    switch (clbType.Items[i].ToString())
                    {
                        case "表":
                            System.Threading.ThreadPool.QueueUserWorkItem(CreateTables,null);
                            break;
                        case "类型":
                            System.Threading.ThreadPool.QueueUserWorkItem(CreateSource, "Type");
                            break;
                        case "视图":
                            System.Threading.ThreadPool.QueueUserWorkItem(CreateViews, null);
                            break;                        
                        case "包":
                            System.Threading.ThreadPool.QueueUserWorkItem(CreatePackages, null);
                            break;
                        case "存储过程":
                            System.Threading.ThreadPool.QueueUserWorkItem(CreateObject, "PROCEDURE");
                            break;
                        case "函数":
                            System.Threading.ThreadPool.QueueUserWorkItem(CreateObject, "FUNCTION");
                            break;
                        //case "触发器":
                        //    System.Threading.ThreadPool.QueueUserWorkItem(CreateObject, "TRIGGER");
                           // break;
                        case "序列":
                            System.Threading.ThreadPool.QueueUserWorkItem(CreateSequences, null);
                            break;
                        case "数据":
                            System.Threading.ThreadPool.QueueUserWorkItem(CreateData, null);
                            break; 
                    }
                }
            }
        }


        public void CreateTables(object obj)
        {
            string path = txtPath.Text + "\\Table.sql";
            if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);
            if (System.IO.File.Exists(txtPath.Text +"Trigger.sql"))
            System.IO.File.Delete(txtPath.Text +"Trigger.sql");
            DataTable dtTable = OracleDocument.GetTablesByUser(UserName);
            dtTable.DefaultView.Sort="table_name asc";
            foreach (DataRow dataRow in dtTable.DefaultView.ToTable().Rows)
            {
                WriteControl(string.Format("正在生成{0}表结构……………………\r\n", dataRow["table_name"].ToString().ToLower()));
                DataTable dtDdl = OracleDocument.GetDdlByObject("Table".ToUpper(), dataRow["table_name"].ToString(), UserName);
                WriterFile(dtDdl.Rows[0][0].ToString()+"\r\n/", path);
                //WriterFile("/", path);
                //CreateIndexes(dataRow["table_name"].ToString());
                CreateComments(dataRow["table_name"].ToString());
                CreateTrigger(dataRow["table_name"].ToString());
                WriteControl(string.Format("{0}表结构生成完成……………………\r\n", dataRow["table_name"].ToString().ToLower()));
            }
            WriteControl("表结构生成完成……………………………………\r\n");

        }
         
        public void CreateIndexes(object obj)
        {
            string path = txtPath.Text + "\\Table.sql";
            DataTable dtTable = OracleDocument.GetIndexesByTableName(obj.ToString());
            foreach (DataRow dataRow in dtTable.Rows)
            {
                DataTable dtDdl = OracleDocument.GetDdlByObject("Index".ToUpper(), dataRow["index_name"].ToString(), UserName);
                WriterFile(dtDdl.Rows[0][0].ToString().ToLower(), path);
                WriterFile("/", path);
            }
        }
        public void CreateComments(object obj)
        {
            string path = txtPath.Text + "\\Table.sql";
            DataTable dtTable = OracleDocument.GetUserTableByTableName(obj.ToString());
            WriterFile(string.Format("COMMENT ON TABLE {0} IS '{1}'", obj.ToString(), dtTable.Rows[0]["comments"].ToString()).ToLower(), path);
            WriterFile("/",path);
            DataTable dtColumns = OracleDocument.GetColumnsByTableName(obj.ToString());
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dataRow in dtColumns.Rows)
            {
                sb.AppendFormat("comment on column {0}.{1} is '{2}'\r\n", obj.ToString().ToLower(), dataRow["column_name"].ToString().ToLower(), dataRow["comments"].ToString().ToLower());
                sb.Append("/\r\n");
            }
            WriterFile(sb.ToString(),path);
        }
        public void CreateViews(object obj)
        {
            string path = txtPath.Text + "\\View.sql";
            if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);
            DataTable dtView = OracleDocument.GetViewBySchema(UserName);
            foreach (DataRow dataRow in dtView.Rows)
            {
                DataTable dtDdl = OracleDocument.GetDdlByObject("View".ToUpper(), dataRow["view_name"].ToString(), UserName);
                WriterFile(dtDdl.Rows[0][0].ToString(), path);
                WriterFile("/\n", path);
            }
        }
        public void CreateTrigger(object obj)
        {
            string path = txtPath.Text + "\\Trigger.sql";

            DataTable dtTrigger = OracleDocument.GetTriggerByTableName(obj.ToString());
            foreach (DataRow dataRow in dtTrigger.Rows)
            {
                DataTable dtTriggerBody = OracleDocument.GetProcedureByName(dataRow["trigger_name"].ToString(), "Trigger");
                if (dtTriggerBody.Rows.Count == 0)
                {
                    WriteControl(dataRow["trigger_name"].ToString() + "触发器不存在");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("CREATE OR REPLACE \r\n");

                    foreach (DataRow dr in dtTriggerBody.Rows)
                    {
                        sb.Append(dr["text"].ToString());
                    }
                    sb.Append("/\r\n");
                    WriterFile(sb.ToString(), path);
                }
            }
        }
        public void CreateSource(object obj)
        {
            string path = txtPath.Text + string.Format("\\{0}.sql",obj);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            DataTable dtSource = OracleDocument.GetAllTypeBySchema(obj.ToString(), UserName);
            foreach (DataRow dataRow in dtSource.Rows)
            {
                DataTable dtTriggerBody = OracleDocument.GetProcedureByName(dataRow["name"].ToString(), "Type");
                StringBuilder sb = new StringBuilder();
                sb.Append("CREATE OR REPLACE ");
                foreach (DataRow dr in dtTriggerBody.Rows)
                {
                    sb.Append(dr["text"].ToString());
                    
                }
                sb.Append("/\r\n");
                WriterFile(sb.ToString(), path);
            }
        }

        public void CreateObject(object obj)
        {
            string path = txtPath.Text + string.Format("\\{0}.sql", obj.ToString());
            if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);
            DataTable dtView = OracleDocument.GetAllTypeBySchema(obj.ToString().ToUpper(), UserName);
            foreach (DataRow dataRow in dtView.Rows)
            {
                DataTable dtDdl = OracleDocument.GetDdlByObject(obj.ToString().ToUpper(), dataRow["name"].ToString(), UserName);
                WriterFile(dtDdl.Rows[0][0].ToString(), path);
                WriterFile("/\n", path);
            }
        }
        public void CreatePackages(object obj)
        {
            string path = txtPath.Text + "\\Packages.sql";
            if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);

            System.Data.DataTable procedureList = OracleDocument.GetAllProcedure();
            foreach (System.Data.DataRow dr in procedureList.Rows)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("CREATE OR REPLACE ".ToLower());
                System.Data.DataTable procedure = OracleDocument.GetProcedureByName(dr["name"].ToString(), "PACKAGE");
                WriteControl(string.Format("正在生成{0}包体……………………\r\n", dr["name"].ToString().ToLower()));
                foreach (System.Data.DataRow dataRow in procedure.Rows)
                    sb.Append(dataRow["text"].ToString().ToLower());
                sb.Append("/\r\n");
                sb.Append("CREATE OR REPLACE ".ToLower());
                System.Data.DataTable procedureBODY = OracleDocument.GetProcedureByName(dr["name"].ToString(), "PACKAGE BODY");
                WriteControl(string.Format("正在生成{0}包体……………………\r\n", dr["name"].ToString().ToLower()));
                foreach (System.Data.DataRow dataRow in procedureBODY.Rows)
                    sb.Append(dataRow["text"].ToString().ToLower());
                sb.Append("/");
                WriterFile(sb.ToString(),path);
            }
        }
        public void CreateSequences(object obj)
        {
            string path = txtPath.Text + "\\Sequences.sql";
            if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);
            DataTable seqTable = OracleDocument.GetSequenceBySchema("CCENSE");
            WriteControl(string.Format("正在生产序列，共{0}-------------------------------------------", seqTable.Rows.Count));
            foreach (DataRow dataRow in seqTable.Rows)
            {
                WriterFile(string.Format(@"CREATE SEQUENCE {0}
    INCREMENT BY {1}
    START WITH {2}
    MINVALUE {3}
    MAXVALUE {4}
    NOCYCLE
    NOORDER
    NOCACHE
/".ToLower(), dataRow["sequence_name"].ToString().ToLower(), dataRow["increment_by"].ToString(), dataRow["last_number"].ToString(), dataRow["min_value"].ToString(), dataRow["max_value"].ToString())
                                      , path);
                WriteControl(string.Format("{0}生成完成", dataRow["sequence_name"].ToString().ToLower()));//sequence_name,min_value,max_value,increment_by,last_number
            }
        }
        public void CreateData(object obj)
        {
            if (System.IO.File.Exists(txtPath.Text + "\\Data.sql"))
                System.IO.File.Delete(txtPath.Text + "\\Data.sql");
            DataTable dtTable = OracleDocument.GetTablesByUser(UserName);
            if (cbTable.Checked)
                dtTable.DefaultView.RowFilter = string.Format("table_name not in({0}) and num_rows>0", txtExcludeTable.Text.ToLower());
            foreach (DataRow dataRow in dtTable.DefaultView.ToTable().Rows)
            {
                WriteControl(string.Format("正在生成{0}表数据……………………\r\n", dataRow["table_name"].ToString().ToLower()));

                DataTable dtData = DbHelper.Fill(string.Format("select * from {0}",dataRow["table_name"].ToString()));
                if (dtData.Rows.Count>0)
                {
                    ContactInsert(dtData, dataRow["table_name"].ToString());
                }
                WriteControl(string.Format("{0}表数据生成完成……………………\r\n", dataRow["table_name"].ToString().ToLower()));
            }
            WriteControl("表数据全部生成完成");
            
        }
        public void ContactInsert(DataTable dtData,string tableName)
        {
            string key=string.Empty;
            string path = txtPath.Text + "\\Data.sql";
            foreach (DataColumn column in dtData.Columns)
            {
                key += column.ColumnName + ",";
            }
            key = key.TrimEnd(',');
            StringBuilder sb = new StringBuilder();
            Int32 i=0;
            foreach (DataRow dataRow in dtData.Rows)
            {
                string value = ContactValues(dataRow);
                sb.AppendFormat("Insert into {0}({1}) values({2})\r\n", tableName.ToLower(), key.ToLower(), value);
                sb.AppendFormat("/\r\n");
                i++;
                if (i > 10000)//减少读写速度
                {
                    WriterFile(sb.ToString(), path);
                    sb = new StringBuilder();
                    i = 0;
                }
            }
            if (!string.IsNullOrWhiteSpace(sb.ToString()))
                WriterFile(sb.ToString(), path);

        }

        public string ContactValues(DataRow dataRow)
        {
            string value = string.Empty;
            foreach (DataColumn c in dataRow.Table.Columns)
            {
                if (dataRow[c.ColumnName] == DBNull.Value)
                {
                    value += "null,";
                }
                else
                {
                    if (c.DataType == System.Type.GetType("System.DateTime"))
                    {
                        value += string.Format("to_date('{0}','yyyyMMddHH24miss'),", Convert.ToDateTime(dataRow[c.ColumnName]).ToString("yyyyMMddHHmmss"));
                    }
                    else
                    {
                        value += string.Format("'{0}',", dataRow[c.ColumnName].ToString().Replace("'", "''"));
                    }
                }
            }
            return value.TrimEnd(',');
        }
        public static void WriterFile(string text, string path)
        {
            System.IO.StreamWriter rw = System.IO.File.AppendText(path);
            rw.WriteLine(text);
            rw.Flush();
            rw.Close();
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

        private void FrmCreateDatabase_Load(object sender, EventArgs e)
        {
            txtPath.Text = Application.StartupPath + "\\Log";
            if (!System.IO.Directory.Exists(txtPath.Text))
                System.IO.Directory.CreateDirectory(txtPath.Text);
        }

        private void btnSearchData_Click(object sender, EventArgs e)
        {
            DataTable dtTable = OracleDocument.GetTablesByUser(UserName);

            dtTable.DefaultView.Sort = "num_rows Desc";

            foreach (DataRow dataRow in dtTable.DefaultView.ToTable().Rows)
            {
                txtNotice.AppendText("'"+dataRow["table_name"].ToString() +"':"+ dataRow["num_rows"].ToString()+"\n");
            }
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            FrmLanguageTool tool = new FrmLanguageTool();
            tool.ShowDialog(this);
        }
        
    }
}
