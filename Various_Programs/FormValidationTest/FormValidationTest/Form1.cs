using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormValidationTest
{
    public partial class Form1 : Form
    {
        private readonly List<Control> CtrlsToValidate; 
        public Form1()
        {
            InitializeComponent();

            this.CtrlsToValidate = new List<Control>
            {
                this.textBox4
            };
        }


        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textBox4, string.Empty);
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Name required!");
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm())
            {
                SaveSettings();
                Close();
                DialogResult = DialogResult.OK;
            }

        }

        private void SaveSettings()
        {
            MessageBox.Show("Form saved", "Caption", MessageBoxButtons.OK);
        }

        private bool ValidateForm()
        {
            foreach (Control control in this.CtrlsToValidate)
            {
                control.Focus();

                if (!Validate())
                {
                    DialogResult = DialogResult.None;
                    return false;
                }
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form.
            Form newForm = new Form();

            // Create two buttons to use as the accept and cancel buttons.
            var btn1 = new Button();
            var btn2 = new Button();

            // Set the text of button1 to "OK".
            btn1.Text = "OK";

            // Set the position of the button on the form.
            btn1.Location = new Point(10, 10);

            // Set the text of button2 to "Cancel".
            btn2.Text = "Cancel";
            // Set the position of the button based on the location of button1.
            btn2.Location = new Point(btn1.Left, btn1.Height + btn1.Top + 10);

            // Make button1's dialog result OK.
            btn1.DialogResult = DialogResult.OK;

            // Make button2's dialog result Cancel.
            btn2.DialogResult = DialogResult.Cancel;

            // Set the caption bar text of the form.   
            newForm.Text = "My Dialog Box";

            // Define the border style of the form to a dialog box.
            newForm.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the accept button of the form to button1.
            newForm.AcceptButton = btn1;

            // Set the cancel button of the form to button2.
            newForm.CancelButton = btn2;

            // Set the start position of the form to the center of the screen.
            newForm.StartPosition = FormStartPosition.CenterScreen;

            // Add button1 to the form.
            newForm.Controls.Add(btn1);
            // Add button2 to the form.
            newForm.Controls.Add(btn2);

            // Display the form as a modal dialog box.
            newForm.ShowDialog();


            // Determine if the OK button was clicked on the dialog box.
            if (newForm.DialogResult == DialogResult.OK)
            {
                // Display a message box indicating that the OK button was clicked.
                MessageBox.Show("The OK button on the form was clicked.");
                // Optional: Call the Dispose method when you are finished with the dialog box.
                newForm.Dispose();
            }
            else
            {
                // Display a message box indicating that the Cancel button was clicked.
                MessageBox.Show("The Cancel button on the form was clicked.");
                // Optional: Call the Dispose method when you are finished with the dialog box.
                newForm.Dispose();
            }
        }
    }
}
