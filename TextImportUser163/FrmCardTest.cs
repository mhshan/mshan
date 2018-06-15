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

        private void btnCash_Click(object sender, EventArgs e)
        {

            CardInterface.CardInfo cardInfo=new CardInterface.CardInfo();
            StringBuilder opFare = new StringBuilder("1.00");
            cardInfo.opFare =       new char[16];//   string.Empty.PadLeft(16, '0');
            cardInfo.outIdT =       new char[48];//   string.Empty.PadLeft(48, '0');
            cardInfo.outIdC =       new char[48];//   string.Empty.PadLeft(48, '0');
            cardInfo.beforeOddFare =new char[16];//   string.Empty.PadLeft(16, '0');
            cardInfo.afterOddFare = new char[16];//   string.Empty.PadLeft(16, '0');
            cardInfo.dateTime =     new char[32];//   string.Empty.PadLeft(32, '0');
            cardInfo.termId =       new char[16];//   string.Empty.PadLeft(16, '0');
            cardInfo.tac =          new char[24];//   string.Empty.PadLeft(24, '0');
            cardInfo.opCount =      new char[8];//   string.Empty.PadLeft(8, '0');
            cardInfo.status=0;
            ;
            StringBuilder outIdT = new StringBuilder(48);
            StringBuilder outIdC = new StringBuilder(48);
            StringBuilder beforeOddFare = new StringBuilder(16);
            StringBuilder afterOddFare = new StringBuilder(16);
            StringBuilder dateTime = new StringBuilder(32);
            StringBuilder termId = new StringBuilder(16);
            StringBuilder tac = new StringBuilder(24);
            StringBuilder opCount = new StringBuilder(8);
            Int32 result = CardInterface.OnInitLoadS(false, handler,opFare, ref cardInfo);
            //Int32 result = CardInterface.OnInitLoad(false, handler, opFare, outIdT, outIdC, beforeOddFare, afterOddFare, dateTime, termId, tac, opCount);
            WriteControl(string.Format("读卡数据,返回值：{0}", result.ToString("X")));

        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            Int32 result = CardInterface.SetHLHT(true,false);
            WriteControl(string.Format("返回值：{0}", result.ToString("X")));
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            StringBuilder data=new StringBuilder(500);
            Int32 result = CardInterface.ReadFiles(false, data);
            WriteControl(string.Format("返回值：{0},{1}", result.ToString("X"),data));
        }

        private void btnConsume_Click(object sender, EventArgs e)
        {
            StringBuilder opFare = new StringBuilder("1.00");
            StringBuilder opCountT = new StringBuilder("00000000");
            //opCountT.Append("0");
            StringBuilder outIdT            =new StringBuilder(48);
            StringBuilder outIdC            =new StringBuilder(48);
            StringBuilder beforOddFare      =new StringBuilder(16);
            StringBuilder afterOddFare      =new StringBuilder(16);
            StringBuilder operationTime = new StringBuilder(32);
            StringBuilder termId            =new StringBuilder(16);
            StringBuilder tac               =new StringBuilder(24);
            StringBuilder opCountC          =new StringBuilder(8);
            Int32 result = CardInterface.OnInitCircle(false, handler, opFare, opCountT, outIdT, outIdC, beforOddFare, afterOddFare, operationTime, termId, tac, opCountC);
            //Int32 result = CardInterface.OnCircle(false,  opFare,   opCountT,  afterOddFare,  tac);
            WriteControl(string.Format("返回值：{0}", result.ToString("X")));
    }
    }
}
