using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_UI.My_Forms;
using DVLD_UI.Users;
using DVLD_UI.Users.My_Controls;
using DVLD_UI.Tests;
using DVLD_Buisness;

namespace DVLD_UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmSchedualTest(36,clsTestType.enTestType.VisionTest));
            Application.Run(new frmLogin());
        }
    }
}
