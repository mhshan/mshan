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
    public partial class FrmXmlTest : Form
    {
        public FrmXmlTest()
        {
            InitializeComponent();
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
