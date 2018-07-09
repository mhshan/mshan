using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ServiceStack.Redis;
using System.Web.Script.Serialization;
using ServiceStack.Redis;
namespace TextImportUser163
{
    public partial class FrmRedis : Form
    {
        public FrmRedis()
        {
            InitializeComponent();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            PooledRedisClientManager pool = new ServiceStack.Redis.PooledRedisClientManager();
            //string d = RedisOperation.Client.GetValue("12");
            string[] str = new string[] { "1","2"};
            string json=JsonSerializer(str);
           //bool result= RedisOperation.Client.Set<string>(txtData.Text,
           //  json );

           
            
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

        private void btnGet_Click(object sender, EventArgs e)
        {
           redisLock.EnterReadLock();
           //txtNotice.Text= RedisOperation.Client.GetValue(txtData.Text);
           redisLock.ExitReadLock();

        }

        public readonly System.Threading.ReaderWriterLockSlim redisLock = new System.Threading.ReaderWriterLockSlim();
    }



}
