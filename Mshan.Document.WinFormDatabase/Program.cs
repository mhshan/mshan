using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mshan.Document.WinFormDatabase
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //string path = Application.StartupPath + "\\1.png";
            //System.IO.FileStream rw=new System.IO.FileStream(path,System.IO.FileMode.OpenOrCreate);
            //byte[] b = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAIQAAABYCAMAAAADZq/BAAAA0lBMVEUAAAD////////////////////V1dXf39/m5ubo6OjV1dXY2Njd3d3V1dXb29ve3t7W1tbY2NjZ2dnb29vb29vh4eHc3NzY2NjX19fV1dXX19fU1NTV1dXV1dXb29vT09PV1dXW1tbW1tbV1dXW1tbT09PU1NTj4+PV1dXa2trY2NjU1NTU1NTT09PV1dXT09PV1dXU1NTV1dXV1dXV1dXX19fV1dXj4+P09PT7+/v+/v7////T09PZ2dn09PT+/v7V1dX5+fnV1dXg4OCenp6RkZHfT0VfAAAAQ3RSTlMAAQIDBAUGCAoLDA0PEhUXGRobHAcRFiEmKi0vMDEOHTc+REhKTE0JGCIuO0dSXGNoa21uJDNUfsDp+f9GXsL+Q9ps2z6HvgAAAb9JREFUaN7t2stOwzAQBVCP7bxboCoCoZYV8P8fBKxohUBUBdI8m8SMQ2DBEpV4hOamUheW6iPHi1q+IIaAfcB+/30Mfoywz9fcgwAk9BFjxPTpzODoJ8W5pZQKRmJ8EkzbdcgwAwIJJ3kCrR4V0SiTxa92NSwCQMnz11mlvE8D/PmO6BH7NtiePHUtKvrdcLVewnfGQvRZLe5xLXBOOYvfbmBzOt6+HN7Iy9zcHufbDhFSeXoxCRDQiDGjkVHt1s2+7fBl6KM4OWt1LcaO36jnLH9vEKH1VM6TsBXjR5XZpkubBhfCD8JZEjYOELrMtmVVI8Lzl8U0UcJF2iyNVvUe1PVjHE0T6QTRZWmRX9yB9nyLACcIYxG4EtrvEcJNekSNiAARsSNEjoiqBs8iLitHiOBhQIRxNIkcIYpdkZcDYho6QpQpIxjBCEYw4r8iQhCmPNjILxER/mBxsJFfIuyfnvxgI4xgBCMYwQhGMIIRjGAEIxhB9PBD4hjIp3JGMIIRjGDED4T7izgCV5IkLmdpXFNTuLAnUV0gUeIgUWchUewhUXEiUfaiUXsjUQAkUYWkUQqlUY+lURQeHM4q0x8vV/G579iaCAAAAABJRU5ErkJggg==");
            ////System.IO.StringWriter rw = new System.IO.StringWriter(); System.IO.File.AppendText(path);
            //rw.Write(b,0,b.Length);
            //rw.Flush();
            //rw.Close();
            //return;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Application_UnhandledException);
            Application.Run(new FrmXmlTest());
        }
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ExceptionEvent("Application_ThreadException",e.Exception);
        }
        public static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionEvent("Application_UnhandledException",(Exception)e.ExceptionObject);
        }
        public static void ExceptionEvent(object sender,Exception ex)
        {
            WriterFile(DateTime.Now.ToString()+"  " + sender);
            WriterFile(ex.Message);
            WriterFile(ex.StackTrace);
            FrmException frmEx = new FrmException(sender, ex);
            frmEx.ShowDialog();
            if (frmEx.IsRun)
                System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);
        }
        public static void WriterFile(string text)
        {
            string path = Application.StartupPath + "\\log.txt";
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
}
