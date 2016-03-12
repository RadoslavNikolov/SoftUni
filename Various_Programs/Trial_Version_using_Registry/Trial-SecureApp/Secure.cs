using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trial_SecureApp
{
    using System.Security.AccessControl;
    using Microsoft.Win32;

    public class Secure
    {
        private readonly string globalRegistryPath;
        private readonly string appPassword;
        private readonly RegistryKey regKey;

        public Secure(string appPassword, string globalRegistryPath)
        {
            this.appPassword = appPassword;
            this.globalRegistryPath = globalRegistryPath;
            this.regKey = this.GetRegKey(this.globalRegistryPath);
        }

        private RegistryKey GetRegKey(string regPath)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey(regPath);

            return regKey;
        }

        private void StartForFirstTime()
        {

            DateTime currDateTime = DateTime.Now;
            string onlyDate = currDateTime.ToShortDateString(); //get only date

            this.regKey.SetValue("Install", onlyDate);
            this.regKey.SetValue("Use", onlyDate);

        }

        private string CheckFirstDate()
        {
            string regValue = (string) this.regKey.GetValue("Install");

            if (regValue == null)
            {
                return "First use";
            }

            return regValue;
        }

        private bool CheckPassword(string pass)
        {
            string regValue = (string) this.regKey.GetValue("Password");

            if (Helpers.PasswordHelper.VerifyPassword(regValue, pass))
            {
                return true;
            }

            return false;
        }


        private string DayDiffPutPresent()
        {
            //get present date from system
            DateTime currDateTime = DateTime.Now;
            DateTime presentDate = currDateTime.Date;

            //get instalation date
            string installRegValue = (string) this.regKey.GetValue("Install");
            DateTime installationDate = Convert.ToDateTime(installRegValue);

            TimeSpan diff = presentDate.Subtract(installationDate);
            int totalDaysDiff = (int) diff.TotalDays;

            //check if user change the date in the system
            string lastUseRegValue = (string) this.regKey.GetValue("Use");
            diff = presentDate.Subtract(Convert.ToDateTime(lastUseRegValue));
            int useBetween = (int) diff.TotalDays;

            //put next use day in registry
            this.regKey.SetValue("Use", currDateTime.ToShortDateString());

            if (useBetween >= 0)
            {
                if (totalDaysDiff < 0)
                {
                    return "Error"; // if user change the date of the system ( date was set before installation)
                }

                if (totalDaysDiff >= 0 && totalDaysDiff <= 15)
                {
                    return (15 - totalDaysDiff).ToString(); //return count of remaining days
                }

                return "Expired";
            }

            return "Error"; // user have changed the system date
        }

        private void SetBlackList()
        {
            this.regKey.SetValue("Black", true);
        }

        private bool BlackListCheck()
        {
            var regKeyValue = (string) regKey.GetValue("Black");

            if (regKeyValue == null)
            {
                return false;
            }

            return true;
        }

        public bool CheckCredentials()
        {
            bool validPassword = this.CheckPassword(this.appPassword);

            if (validPassword)
            {
                return true;
            }

            var isBlackListed = this.BlackListCheck();

            if (isBlackListed)
            {
                return this.ShowErrorMsgBox(this.appPassword);
            }

            string installationDate = this.CheckFirstDate();

            if (installationDate.Equals("First use"))
            {
                this.StartForFirstTime();
                return this.ShowActivationMsgBox(this.appPassword);
            }


            string status = this.DayDiffPutPresent();
            if (status.Equals("Error"))
            {
                this.SetBlackList();

                return this.ShowErrorMsgBox(this.appPassword);
            }

            if (status.Equals("Expired"))
            {
                return this.ShowActivationMsgBox(this.appPassword);
            }



            return this.ShowRemainingDaysMsgBox(this.appPassword, status);
        }

        private bool ShowRemainingDaysMsgBox(string password, string status)
        {
            DialogResult ds =
                MessageBox.Show(
                    "You are using trial Pack, you have " + status +
                    " days left to Activate! Would you Like to Activate it now!", "Product key", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
            if (ds == DialogResult.Yes)
            {
                return this.ShowRegistrationForm(password, this.globalRegistryPath);
            }

            return true;
        }

        private bool ShowErrorMsgBox(string password)
        {
            DialogResult ds =
                MessageBox.Show(
                    "Application Can't be loaded, Unauthorized Date Interrupt Occurred! Without activation it can't run! Would you like to activate it?",
                    "Terminate Error-02", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (ds == DialogResult.Yes)
            {
                return this.ShowRegistrationForm(password, this.globalRegistryPath);
            }

            return false;
        }

        private bool ShowActivationMsgBox(string password)
        {
            DialogResult ds = MessageBox.Show("You are using trial Pack! Would you Like to Activate it Now!", "Product key", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (ds == DialogResult.Yes)
            {
                return this.ShowRegistrationForm(password, this.globalRegistryPath);
            }

            return true;
        }

        private bool ShowRegistrationForm(string password, string globalRegPath)
        {
            Form1 regForm = new Form1(password, globalRegPath);
            DialogResult ds1 = regForm.ShowDialog();
            if (ds1 == DialogResult.OK)
            {
                return true;
            }

            return false;
        }
    }
}
