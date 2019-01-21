using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Xml;
namespace Mshan.Document.WinFormDatabase
{
    public partial class FrmXmlTest : Form
    {
        private static PrintDocument fPrintDocument = new PrintDocument();

        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String Name); //调用win api将指定名称的打印机设置为默认打印机
        public FrmXmlTest()
        {
            InitializeComponent();
            InitprinterComboBox();
        }

        private void InitprinterComboBox()
        {
            cmbNeedlePrinter.Items.Clear();
            cmbThermalPrinter.Items.Clear();
            List<String> list = GetLocalPrinters(); //获得系统中的打印机列表
            foreach (String s in list)
            {
                cmbNeedlePrinter.Items.Add(s); //将打印机名称添加到下拉框中
            }
            foreach (String s in list)
            {
                cmbThermalPrinter.Items.Add(s); //将打印机名称添加到下拉框中
            }
            
        }

        //获取本机默认打印机名称
        public static String DefaultPrinter()
        {
            return fPrintDocument.PrinterSettings.PrinterName;
        }

        public static List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<String>();
            fPrinters.Add(DefaultPrinter()); //默认打印机始终出现在列表的第一项
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                {
                    fPrinters.Add(fPrinterName);
                }
            }
            return fPrinters;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            //System.Xml.XmlElement element = xmlDoc.CreateElement("xml",);
            //xmlDoc.Name = "xml";
             //xmlDoc.CreateElement();
            System.Xml.XmlNode node = xmlDoc.CreateNode(System.Xml.XmlNodeType.CDATA, "plan_id","xml");
            node.Value = "456";
            //xmlDoc.AppendChild(node);
            System.Xml.XmlCDataSection cData = xmlDoc.CreateCDataSection("test");
            label1.Text = cData.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetDefaultPrinter(cmbNeedlePrinter.SelectedItem.ToString());
            PrintDocument fPrintDocument = new PrintDocument();　　　　//获取默认打印机的方法

            label3.Text = fPrintDocument.PrinterSettings.PrinterName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument fPrintDocument = new PrintDocument();　　　　//获取默认打印机的方法
            label3.Text = fPrintDocument.PrinterSettings.PrinterName;
        }
        public string fileName;
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog(this);
            fileName=openFile.FileName;
            pbPicture.Width = Convert.ToInt32(txtWidth.Text);
            pbPicture.Height = Convert.ToInt32(txtHeight.Text);
            pbPicture.Image = Image.FromStream(openFile.OpenFile());
            
        }
        void Printer_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            try
            {
                SolidBrush ColorBrush = new SolidBrush(label1.BackColor);
                ColorBrush = new SolidBrush(label1.ForeColor);
                Int32 width = Convert.ToInt32(txtWidth1.Text);
                Int32 height = Convert.ToInt32(txtHeight1.Text);
                ev.Graphics.DrawImage(pbPicture.Image,5,5,width,height);
            }
            catch (Exception ex)
            {
               
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
            Printer.DefaultPageSettings.Landscape = false;
            //设置默认纸张页边距，和不设置似乎没有任何区别
            Printer.DefaultPageSettings.Margins.Left = 0;
            Printer.DefaultPageSettings.Margins.Top = 0;
            Printer.DefaultPageSettings.Margins.Right = 0;
            Printer.DefaultPageSettings.Margins.Bottom = 0;
            Printer.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(Printer_PrintPage);
            Printer.Print();
            Printer.Dispose();
            Printer = null;
        }
    }

    [System.Xml.Serialization.XmlRoot("xml")]
    public class XmlSerializer
    {
        [System.Xml.Serialization.XmlElement]
        public string OpenId
        {
            get;
            set;
        }
    }
}
