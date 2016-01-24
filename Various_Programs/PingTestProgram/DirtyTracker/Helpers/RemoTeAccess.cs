namespace DirtyTracker.Helpers
{
    using System.Management;
    using System.Windows.Forms;

    public static class RemoteAccess
    {
        public static void GetWmiStats(TextBox textBox)
        {
            ConnectionOptions oConn = new ConnectionOptions();
            //oConn.Username = "rnikolov";
            //oConn.Password = "Mykontrax1";
            string remoteMachineName = "localhost";

            ManagementScope oMs = new ManagementScope("\\\\" + remoteMachineName, oConn);
            ObjectQuery oQuery = new ObjectQuery("SELECT * FROM Win32_Service");
            //RelatedObjectQuery oQuery = new RelatedObjectQuery("Win32_Service.Name='MSSQLSERVER'");
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs,oQuery);
            ManagementObjectCollection oReturnCollection = oSearcher.Get();

            foreach (ManagementBaseObject o in oReturnCollection)
            {
                textBox.AppendText(string.Format("Name: {0}\n", o["Name"].ToString()));
                textBox.AppendText(string.Format("Status: {0}\n", o["Status"].ToString()));

                //textBox.AppendText(string.Format("Name: {0}\n", o["csname"].ToString()));
                //textBox.AppendText(string.Format("Name: {0}\n", o["Version"].ToString()));
                //textBox.AppendText(string.Format("Name: {0}\n", o["Caption"].ToString()));
                //textBox.AppendText(string.Format("Name: {0}\n", o["WindowsDirectory"].ToString()));
                //textBox.AppendText(string.Format("Name: {0}\n", o["Name"].ToString()));
            }
            
        }
    }
}