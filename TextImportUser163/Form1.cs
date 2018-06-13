using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Script.Serialization;
namespace TextImportUser163
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static object obj
        {
            get;
            set;
        }
        public static object VersionLock
        {
            get;
            set;
        }
        ServiceStack.Redis.IRedisClient[] redisClient;
        public Dictionary<string, string[]> tempDic = new Dictionary<string, string[]>();
        public readonly System.Threading.ReaderWriterLockSlim tempLock = new System.Threading.ReaderWriterLockSlim();
        public readonly System.Threading.ReaderWriterLockSlim redisLock = new System.Threading.ReaderWriterLockSlim();
        public readonly System.Threading.ReaderWriterLockSlim dataLock = new System.Threading.ReaderWriterLockSlim();
        public readonly System.Threading.ReaderWriterLockSlim redisQueue = new System.Threading.ReaderWriterLockSlim();
        public Queue<DataTable> redisDataTable = new Queue<DataTable>();
        public Queue<DataTable> listDataTable = new Queue<DataTable>();
        int thread=0;
        private void txtStart_Click(object sender, EventArgs e)
        {
            thread = Convert.ToInt32(txtThread.Text);
            SqlDB.SqlConnString = txtDataBase.Text;
            SqlDB.ExecSql("update baseversion set Finish=0 where Finish=1");
            obj = new object();
            VersionLock = new object();
            redisClient = new ServiceStack.Redis.IRedisClient[thread+1];
            for (int i = 1; i <= thread; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(FileToDatabase1, i);
            }
            System.Threading.ThreadPool.QueueUserWorkItem(WriteData, "写进程");
            System.Threading.ThreadPool.QueueUserWorkItem(WriteRedis, "Redis保存");

        }

        public DataTable CreateTable(string tableName,params string[] columnNames)
        {
            DataTable dt = new DataTable(tableName);
            for (int i = 0; i < columnNames.Length; i++)
            {
                dt.Columns.Add(columnNames[i]);
            }
            return dt;
        }

        public void FileToDatabase1(object obj)
        {
            SqlDB.SqlConnString = txtDataBase.Text;
            //int i=26;
            Int32 redisIndex=(Int32)obj-1;
            redisClient[redisIndex] = new ServiceStack.Redis.RedisClient("127.0.0.1", 6379);
            WriterFile(obj.ToString() + "线程开始同步");
            Version version = GetVerion("{0}_登录成功(1)_.txt");
            string fileFullPath = txtFilePath.Text + "\\" + version.VersionName;
            for (; File.Exists(fileFullPath); )
            {
                
                fileFullPath = txtFilePath.Text + "\\" + version.VersionName;
                WriterFile(obj.ToString() + "线程开始同步" + version.VersionName);
                StreamReader sr = new StreamReader(fileFullPath, Encoding.Default);
                String line;
                
                int successNumber = 0;
                int repeatNumber = 0;
                int totaleNumber = 0;
                int indexes = 0;
                DateTime currentTime = DateTime.Now;
                line = sr.ReadToEnd();
                sr.Close();

                DataTable dataTable = CreateTable("User163","username", "password", "datatype");;
                string[] lineArray = Regex.Split(line, "\r\n");
                for (int i = version.Row; i < lineArray.Length; i++)
                {
                   SleepTempThread();
                   if(successNumber==0)
                       dataTable = CreateTable("User163","username", "password", "datatype");
                    MatchCollection collection = Regex.Matches(lineArray[i], "^(.*)----(.*)$");
             
                    if (collection.Count > 0)
                    {
                        totaleNumber++;
                        if (!ExistTempKey(redisIndex,collection[0].Groups[1].Value.ToLower(), collection[0].Groups[2].Value) )
                        {
                            successNumber++;
                            DataRow dr = dataTable.NewRow();
                            dr["username"] = collection[0].Groups[1].Value;
                            dr["password"] = collection[0].Groups[2].Value;
                            dr["datatype"] = "163";
                            dataTable.Rows.Add(dr);
                        }
                        else
                            repeatNumber++;
                        if (totaleNumber % 10000 == 0)
                        {
                            WriterFile(string.Format(obj.ToString() + "线程：共{0}，成功{1}，失败{2}，用时{3},当前时间：{4}",
                                totaleNumber, successNumber, repeatNumber, DateTime.Now - currentTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            currentTime = DateTime.Now;

                        }
                        if (successNumber >= 10000)
                        {
                            WriteDataQueue(dataTable);
                            
                            SqlDB.ExecSql(string.Format("update baseversion set row={0} where versionname='{1}'", lineArray.Length, version.VersionName));
                            successNumber = 0;
                        }
                    }
                    
                }
                if (dataTable.Rows.Count> 0)
                {
                    WriteDataQueue(dataTable);
                    SqlDB.ExecSql(string.Format("update baseversion set row={0} where versionname='{1}'", lineArray.Length, version.VersionName));
                }
                lineArray = null;
                GC.Collect();
             
                SqlDB.ExecSql(string.Format("update baseversion set row={0},Finish=2,endtime=getdate() where versionname='{1}'", totaleNumber, version.VersionName));
                version = GetVerion("{0}_登录成功(1)_.txt");
            }
            WriterFile(obj+"线程结束同步");
        }

        public Version GetVerion(string nameFormat)
        {
            lock (VersionLock)
            {
                Version version = new Version();
                DataTable dt = SqlDB.GetDataSetText("select * from baseversion where finish=0").Tables[0];
                foreach (DataRow dataRow in dt.Rows)
                {
                    if (SqlDB.ExecSql(string.Format("update baseversion set finish=1 where versionname='{0}' and finish=0", dataRow["versionname"].ToString().Replace("'", "''"))))
                    {
                        version.VersionName = dataRow["versionname"].ToString();
                        version.VersionId = Convert.ToInt32(dataRow["version"]);
                        version.Row = Convert.ToInt32(dataRow["row"]);
                        return version;
                    }
                }
                while (true)
                {
                    int max = 0;
                    DataTable dtMax = SqlDB.GetDataSetText("select Max(version) from baseversion").Tables[0];
                    if (dtMax.Rows.Count > 0)
                    {
                        if (dtMax.Rows[0][0] == DBNull.Value)
                            max = 1;
                        else
                            max = Convert.ToInt32(dtMax.Rows[0][0]) + 1;

                    }
                    version.VersionName = string.Format(nameFormat, max.ToString("D3"));
                    if (SqlDB.ExecSql(string.Format("Insert into baseversion(versionname,version,row,finish) values('{0}',{1},{2},{3})", version.VersionName, max, 0, 1)))
                    {
                        version.VersionId = max;
                        version.Row = 0;
                        version.Finish = 1;
                        return version;
                    }
                }
            }
        }

        public void WriterFile(string text)
        {
            this.Invoke(new Action(() =>
            {
                txtNotice.AppendText(text + "\r\n");
                txtNotice.ScrollToCaret();
            }));
            lock (obj)
            {
                string path = Application.StartupPath + "\\log_sell.txt";
                System.IO.StreamWriter rw = System.IO.File.AppendText(path);
                string[] textLine = text.Split('\n');
                for (int i = 0; i < textLine.Length; i++)
                {
                    rw.WriteLine(textLine[i]);
                }
                rw.Flush();
                rw.Close();
            }

        }

        public Int32 SleepTempThread()
        {
             dataLock.EnterWriteLock();
            Int32 count = listDataTable.Count;
            dataLock.ExitWriteLock();
            while (count >3)
            {
                System.Threading.Thread.Sleep(100);
                dataLock.EnterWriteLock();
                count = listDataTable.Count;
                dataLock.ExitWriteLock();
            }
            return count;
        }

        public bool ExistTempKey(Int32 redisIndex, string key, string value)
        {
            bool exist = ExistRedisKey(redisIndex,key, value);
             tempLock.EnterWriteLock();
            if (!exist)
                exist = WriteTempKey(key, value);
            tempLock.ExitWriteLock();
            return exist;
        }


        public bool WriteTempKey(string key, string value)
        {
            bool exist = false;
           

            if (tempDic.ContainsKey(key))
            {
                string[] json = tempDic[key];
                foreach (string s in json)
                {
                    if (s == value)
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    string[] temp = new string[json.Length + 1];
                    json.CopyTo(temp, 0);
                    temp[json.Length] = value;
                    tempDic[key] = temp;
                }
            }
            else
            {
                tempDic.Add(key, new string[] { value });
            }

            
            return exist;
        }
        public void RemoveTempKey(string key,string value)
        {
            //tempLock.EnterWriteLock();
            string[] temp=tempDic[key];
            if (temp.Length <= 1)
                tempDic.Remove(key);
            else
            {
                string[] json=new string[temp.Length-1];
                int j = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == value)
                        continue;
                    else
                    {
                        json[j++] = temp[i];
                    }
                }
                tempDic[key] = json;
            }
            //tempLock.ExitWriteLock();
        }

        public void RemoveTempKey(DataTable dataTable)
        {
            tempLock.EnterWriteLock();
            foreach (DataRow dataRow in dataTable.Rows)
                RemoveTempKey(dataRow["username"].ToString().ToLower(), dataRow["password"].ToString());
            tempLock.ExitWriteLock();
        }
        public bool ExistRedisKey(Int32 redisIndex, string key,string value)
        {
            //redisLock.EnterWriteLock();
            //redisLock.EnterReadLock();
            string valueArray =  redisClient[redisIndex].GetValue(key);
            //redisLock.ExitReadLock();
            //redisLock.ExitWriteLock();
            return valueArray != null;
        }
        public void WriteRedisKey(Int32 redisIndex,string key, string value)
        {
            //redisLock.EnterWriteLock();
            string valueArray = redisClient[redisIndex].Get<string>(key);
            string[] json =null;
            if (string.IsNullOrEmpty(valueArray))
            {
                json =new string[]{value};
            }
            else
            {
                string[] temp = JsonDeSerializer<string[]>(valueArray);
                json = new string[temp.Length + 1];
                temp.CopyTo(json, 0);
                json[temp.Length] = value;
            }

            redisClient[redisIndex].Set<string>(key, JsonSerializer(json));
            //redisLock.ExitWriteLock();
        }
        public void WriteRedisKey(Int32 redisIndex,DataTable dataTable)
        {
            redisLock.EnterReadLock();
            foreach (DataRow dataRow in dataTable.Rows)
                WriteRedisKey(redisIndex, dataRow["username"].ToString().ToLower(), dataRow["password"].ToString());
            redisLock.ExitReadLock();
        }
        public void WriteDataQueue(DataTable dataTable)
        {
            dataLock.EnterWriteLock();
            listDataTable.Enqueue(dataTable);
            dataTable = null;
            dataLock.ExitWriteLock();
            
        }

        public void WriteData(object obj)
        {
            Int32 count = 0;
            while (true)
            {
                DataTable dt = null;
                try
                {
                    dataLock.EnterWriteLock();
                    count = listDataTable.Count;
                    if (count > 0)
                        dt = listDataTable.Dequeue();
                }
                finally
                {
                    dataLock.ExitWriteLock();
                }
                if (count == 0)
                {
                    System.Threading.Thread.Sleep(100);
                    continue;
                }
                while (GetRedisQueueCount() >3)
                {
                    System.Threading.Thread.Sleep(300);
                }
                System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(txtDataBase.Text);
                sqlConn.Open();
                System.Data.SqlClient.SqlBulkCopy sbc = new System.Data.SqlClient.SqlBulkCopy(sqlConn);
                DateTime currentTime = DateTime.Now;
                WriterFile(string.Format("排队个数：{0}---------------------------------------------------------------------------------------------------------------------",  count));
                WriterFile(string.Format(obj.ToString() + "数据库插入开始，数量{1},当前时间：{0}",  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dt.Rows.Count));
                sbc.DestinationTableName = dt.TableName;
                sbc.BulkCopyTimeout = 60000;
                sbc.WriteToServer(dt);
                WriterFile(string.Format(obj.ToString() + "数据库插入结束，数量{2},用时{0},当前时间：{1}", DateTime.Now - currentTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dt.Rows.Count));
                sbc.Close();
                sqlConn.Close();
                AddRedisQueue(dt);
            }
        } 
        public void WriteRedis(object obj)
        {
            redisClient[thread] = new ServiceStack.Redis.RedisClient("127.0.0.1", 6379); 
            while(true)
            {
                DateTime currentTime = DateTime.Now;
                WriterFile(string.Format(obj.ToString() + "数据库插入开始，数量:{1}，当前时间：{0}", currentTime.ToString("yyyy-MM-dd HH:mm:ss"), GetRedisQueueCount()));
                DataTable dataTable= GetRedisQueue();
                if (dataTable == null)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    //foreach (DataRow dataRow in dataTable.Rows)
                    //{
                    //    WriteRedisKey(dataRow["username"].ToString().ToLower(), dataRow["password"].ToString());
                    //    RemoveTempKey(dataRow["username"].ToString().ToLower(),dataRow["password"].ToString());
                    //}

                    WriteRedisKey(thread, dataTable);
                    RemoveTempKey(dataTable);
                    redisLock.EnterWriteLock();
                    redisClient[thread].Save();
                    redisLock.ExitWriteLock();
                    dataTable.Dispose();
                    GC.Collect(2, GCCollectionMode.Forced);
                }
                WriterFile(string.Format(obj.ToString() + "数据库插入结束，用时{0},当前时间：{1}", DateTime.Now - currentTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

            }
        }
        public void AddRedisQueue(DataTable dataTable)
        {
            redisQueue.EnterWriteLock();
            redisDataTable.Enqueue(dataTable);
            redisQueue.ExitWriteLock();
        }
        public DataTable GetRedisQueue()
        {
            redisQueue.EnterWriteLock();
            DataTable dataTable=null;
            if(redisDataTable.Count>0)
                dataTable=redisDataTable.Dequeue();
            redisQueue.ExitWriteLock();
            return dataTable;
        }
        public int GetRedisQueueCount()
        {
            redisQueue.EnterReadLock();
            Int32 count = redisDataTable.Count;
            redisQueue.ExitReadLock();
            return count;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //RedisOperation.Client.ShutdownNoSave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            ObjectTest(sb);
            txtNotice.Text = sb.ToString();
        
        }

        public string JsonSerializer<T>(T t)
        {
            JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
            return jsonSerialize.Serialize(t);
        }

        public T JsonDeSerializer<T>(string jsonString)
        {
            JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
            return jsonSerialize.Deserialize<T>(jsonString);
        }
        public void ObjectTest(StringBuilder sb)
        {
            //sb = new StringBuilder();
            sb.Append("ObjectTest");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            redisLock.EnterWriteLock();
            //RedisOperation.Client.SaveAsync();
            redisLock.ExitWriteLock();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                txtNotice.Clear();
            }));
        }

        
    }

    public class Version
    {
        public string VersionName
        {
            get;
            set;
        }
        public Int32 VersionId
        {
            get;
            set;
        }

        public Int32 Row
        {
            get;
            set;
        }

        public Int32 Finish
        {
            get;
            set;
        }
    }
}
