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
    public partial class FrmCardTest : Form
    {
        public FrmCardTest()
        {
            InitializeComponent();
        }
        public Int32 handler = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Int32 result = CardInterface.OpenComm("AUTO");
            if (result > 0)
                handler = result;
            WriteControl("读卡端口："+result);
        }

        public void WriteControl(string text)
        {
            this.Invoke(new Action(() =>
            {
                txtNotice.AppendText(text + "\r\n");
                txtNotice.ScrollToCaret();
            }));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Int32 result = CardInterface.CloseComm("AUTO");
            WriteControl("关闭读卡器：" + result);
        }

        private void btnReadBalance_Click(object sender, EventArgs e)
        {
            StringBuilder balance=new StringBuilder(50);
            Int32 result = CardInterface.SelectBalance(false,balance);
            WriteControl(string.Format("读卡余额,结果：{0}，卡余额：{1}",result.ToString("X"),balance));
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            StringBuilder balance = new StringBuilder(50);
            StringBuilder cityOutId = new StringBuilder(50);
            StringBuilder outId = new StringBuilder(50);
            Int32 result = CardInterface.ReadData(false,handler,cityOutId,outId,balance);
            WriteControl(string.Format("读卡数据,返回值：{3},城市通卡号:{0},交通部卡号:{1},卡余额：{2}",cityOutId,outId,balance,result));
        }
    }
}
