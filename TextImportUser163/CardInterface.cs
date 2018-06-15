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

        [DllImport("Traffic_Application.dll", EntryPoint = "OnInitLoadS", CharSet = CharSet.Ansi)]
        public extern static Int32 OnInitLoadS(bool isContact, Int32 handler,StringBuilder opFare,ref CardInfo cardInfo);

        [DllImport("Traffic_Application.dll", EntryPoint = "OnInitLoad", CharSet = CharSet.Ansi)]
        public extern static Int32 OnInitLoad(bool isContact, Int32 handler, StringBuilder opFare, StringBuilder outIdT,StringBuilder outIdC,StringBuilder beforeOddfare,StringBuilder afterOddFare,StringBuilder dataTime,StringBuilder termId, StringBuilder tac,StringBuilder opCount);
        [DllImport("Traffic_Application.dll", EntryPoint = "SetHLHT", CharSet = CharSet.Ansi)]
        public extern static Int32 SetHLHT(bool enabledInteroperability,bool isContact);
        [DllImport("Traffic_Application.dll", EntryPoint = "ReadFiles", CharSet = CharSet.Ansi)]
        public extern static Int32 ReadFiles(bool isContact, StringBuilder data);
        [DllImport("Traffic_Application.dll", EntryPoint = "OnInitCircle", CharSet = CharSet.Ansi)]
        public extern static Int32 OnInitCircle(bool isContact,Int32 handler,StringBuilder opFare,StringBuilder opCountT,StringBuilder outIdT,StringBuilder outIdC,StringBuilder beforOddFare,StringBuilder afterOddFare,StringBuilder operationTime,StringBuilder termId,StringBuilder tac,StringBuilder opCountC);
        [DllImport("Traffic_Application.dll", EntryPoint = "OnCircle", CharSet = CharSet.Ansi)]
        public extern static Int32 OnCircle(bool isContact, StringBuilder opFare, StringBuilder opCountT, StringBuilder afterOddFare, StringBuilder tac);
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct CardInfo
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] opFare;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
            public char[] outIdT;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
            public char[] outIdC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] beforeOddFare;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] afterOddFare;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] dateTime;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] termId;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
            public char[] tac;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public char[] opCount;
            public Int32 status;
        }
    }
}
