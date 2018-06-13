using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace TextImportUser163
{
    public class CardInterface
    {
        [DllImport("Traffic_Application.dll", EntryPoint = "M21D_ICC_Reader_Open", CharSet = CharSet.Ansi)]
        public extern static Int32 OpenComm(string devName);

        [DllImport("Traffic_Application.dll", EntryPoint = "SelectBalance", CharSet = CharSet.Ansi)]
        public extern static Int32 SelectBalance(bool isContact, StringBuilder balance);
        [DllImport("Traffic_Application.dll", EntryPoint = "SelectBalance", CharSet = CharSet.Ansi)]
        public extern static Int32 SelectBalance(bool isContact, out Int32 balance);
        [DllImport("Traffic_Application.dll", EntryPoint = "M21D_ICC_Reader_Close", CharSet = CharSet.Ansi)]
        public extern static Int32 CloseComm(string devName);

        [DllImport("Traffic_Application.dll", EntryPoint = "ReadData", CharSet = CharSet.Ansi)]
        public extern static Int32 ReadData(bool isContact,Int32 handler,StringBuilder cityOutId,StringBuilder outId,StringBuilder balance);  
    }
}
