using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expandable_DGV_Rows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Parent Table
            DataTable dtStudent = new DataTable();
            dtStudent.Columns.Add("StudentID", typeof(int));
            dtStudent.Columns.Add("StudentName", typeof(string));
            dtStudent.Columns.Add("StudentRollNo", typeof(string));

            //Child Tabel
            DataTable dtStudentMarks = new DataTable();
            dtStudentMarks.Columns.Add("StudentId", typeof(int));
            dtStudentMarks.Columns.Add("SubkectId", typeof(int));
            dtStudentMarks.Columns.Add("SubjectName", typeof(string));
            dtStudentMarks.Columns.Add("Marks", typeof(int));

            //Adding Rows

            dtStudent.Rows.Add(111, "Devesh", "03021013014");
            dtStudent.Rows.Add(222, "ROLI", "0302101444");
            dtStudent.Rows.Add(333, "ROLI Ji", "030212222");
            dtStudent.Rows.Add(444, "NIKHIL", "KANPUR");

            // data for devesh ID=111
            dtStudentMarks.Rows.Add(111, "01", "Physics", 99);
            dtStudentMarks.Rows.Add(111, "02", "Maths", 77);
            dtStudentMarks.Rows.Add(111, "03", "C#", 100);
            dtStudentMarks.Rows.Add(111, "01", "Physics", 99);


            //data for ROLI ID=222
            dtStudentMarks.Rows.Add(222, "01", "Physics", 80);
            dtStudentMarks.Rows.Add(222, "02", "English", 95);
            dtStudentMarks.Rows.Add(222, "03", "Commerce", 95);
            dtStudentMarks.Rows.Add(222, "01", "BankPO", 99);

            DataSet dsDataSet = new DataSet();
            dsDataSet.Tables.Add(dtStudent);
            dsDataSet.Tables.Add(dtStudentMarks);

            //Add relation

            DataRelation datatableRelation = new DataRelation("DetailsMarks", dsDataSet.Tables[0].Columns[0], dsDataSet.Tables[1].Columns[0],true);
            dsDataSet.Relations.Add(datatableRelation);
            dataGrid1.DataSource = dsDataSet.Tables[0];
            dataGridView1.DataSource = dsDataSet.Tables[0];
        }
    }
}
