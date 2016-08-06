using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_to_HL7_Parser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            dgvPatient.DataSource = await GetPatientFromDb();
        }

        private async Task<DataTable> GetPatientFromDb()
        {
            var tempTable = new DataTable();

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HospitalConnectionString"].ToString());

            try
            {
                await connection.OpenAsync();
                var dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.PatientsView", connection);
                dataAdapter.Fill(tempTable);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if ((connection.State & ConnectionState.Open) != 0)
                {
                    connection.Close();
                }
            }
            
            return tempTable;
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            var dt = dgvPatient.DataSource as DataTable;

            if (dt == null) return;

            foreach (DataRow row in dt.Rows)
            {
                var result = ParseRowToHl7(row);

                SendMessage(result);
            }
        }

        private string ParseRowToHl7(DataRow row)
        {

            NHapi.Base.Parser.PipeParser parser = new NHapi.Base.Parser.PipeParser();
            NHapi.Model.V26.Message.ADT_A01 qry = new NHapi.Model.V26.Message.ADT_A01();
            qry.MSH.MessageType.TriggerEvent.Value = "R02";
            qry.MSH.MessageType.MessageStructure.Value = "QRY_R02";
            qry.MSH.FieldSeparator.Value = "|";
            qry.MSH.SendingApplication.NamespaceID.Value = "CohieCentral";
            qry.MSH.SendingFacility.NamespaceID.Value = "COHIE";
            qry.MSH.ReceivingApplication.NamespaceID.Value = "Clinical Data Provider";
            qry.MSH.ReceivingFacility.NamespaceID.Value = "facility";
            qry.MSH.EncodingCharacters.Value = @"^~\&";
            qry.MSH.VersionID.VersionID.Value = "2.3.1";
            qry.MSH.MessageControlID.Value = "messageControlId";
            qry.MSH.ProcessingID.ProcessingID.Value = "P";


            qry.PID.PatientID.IDNumber.Value = row["PID_2_1"].ToString();
            qry.PID.GetPatientName(0).GivenName.Value = row["PID_5_2"].ToString();
            qry.PID.GetPatientName(0).SecondAndFurtherGivenNamesOrInitialsThereof.Value = row["PID_5_3"].ToString();
            qry.PID.GetPatientName(0).FamilyName.OwnSurname.Value = row["PID_5_1"].ToString();

            return parser.Encode(qry);


            //return parser.Encode(qry);




        }

        private void SendMessage(string msg)
        {
            resultRichTextBox.AppendText(msg);
            resultRichTextBox.AppendText(Environment.NewLine);
        }
    }
}
