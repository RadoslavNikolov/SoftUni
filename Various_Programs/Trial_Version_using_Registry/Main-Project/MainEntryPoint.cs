using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Project
{
    using System.Security.AccessControl;
    using Microsoft.Win32;
    using Trial_SecureApp;
    using Trial_SecureApp.Helpers;

    static class MainEntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var appPass = GetPass();

            string regGlobalPath = @"Software\Rako\Protection";

            Secure secure = new Secure(appPass, regGlobalPath);

            if (secure.CheckCredentials())
            {
                Application.Run(new Form1());
            }           
        }

        private static string GetPass()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default["PasswordHash"].ToString()))
            {
                var passHash = PasswordHelper.GenerateHash("radko");
                Properties.Settings.Default["PasswordHash"] = passHash;
                Properties.Settings.Default.Save();
            }

            return Properties.Settings.Default["PasswordHash"].ToString();
        }
    }
}
