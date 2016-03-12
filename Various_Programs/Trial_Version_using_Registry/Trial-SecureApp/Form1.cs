using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trial_SecureApp
{
    using System.Security.AccessControl;
    using Microsoft.Win32;

    public partial class Form1 : Form
    {
        private readonly string appPassword;
        private readonly string regPath;

        public Form1()
        {
            this.InitializeComponent();
        }

        public Form1(string password, string regPath)
            : this()
        {
            this.appPassword = password;
            this.regPath = regPath;
        }

        private bool EnterPassword(string password, string enteredPassword)
        {
            bool validPassword = Helpers.PasswordHelper.VerifyPassword(enteredPassword, password);
            if (validPassword)
            {

                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.CreateSubKey(this.regPath);

                if (regKey != null)
                {                   
                    var passHash = Helpers.PasswordHelper.GenerateHash(enteredPassword);
                    regKey.SetValue("Password", passHash);
                }

                return true;
            }

            return false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bool isPasswordEntered = this.EnterPassword(this.appPassword, this.passwordTextBox.Text);

            if (isPasswordEntered)
            {
                MessageBox.Show("Thank you for activation!", "Activate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.buttonOk.DialogResult = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Product Key is not valid! Please Enter a valid Product Key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
