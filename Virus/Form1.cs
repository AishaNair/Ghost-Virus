using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Thread;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Timer;
namespace Virus
{
    
    public partial class Ghost : Form
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
        protected static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);
        
        public Ghost()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //method
        public bool ProcessCDTray(bool open) 
        {
            int ret = 0;
            //do a switch of the value passed
            switch (open)
            {
                case true: //true = open the cd 
                ret = mciSendString("set cdaudio door open", null, 0, IntPtr.Zero);
                return true;
                break;
                case false: //false = close the tray 
                ret = mciSendString("set cdaudio door closed", null, 0, IntPtr.Zero);
                return true; 
                break;
                default: ret = mciSendString("set cdaudio door open", null, 0, IntPtr.Zero); return true; break; 
            }
           }

       

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <5; i++)
            {
                ProcessCDTray(true);
                ProcessCDTray(false);
                //System.Threading.Thread.Sleep(5000);
                
             }
        }
      }
}
