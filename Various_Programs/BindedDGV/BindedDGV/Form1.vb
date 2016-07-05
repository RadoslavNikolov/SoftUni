Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Bind the DataGridView controls to the BindingSource
        ' components and load the data from the database.
        masterDataGridView.DataSource = masterBindingSource
        detailsDataGridView.DataSource = detailsBindingSource
        GetData()

        ' Resize the master DataGridView columns to fit the newly loaded data.
        masterDataGridView.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        detailsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub GetData()
        'Parent Table
        Dim dtStudent As New DataTable()
        dtStudent.TableName = "Students"
        dtStudent.Columns.Add("StudentId", GetType(Integer))
        dtStudent.Columns.Add("StudentName", GetType(String))
        dtStudent.Columns.Add("StudentRollNo", GetType(String))

        'Child Table
        Dim dtStudentMarks As New DataTable()
        dtStudentMarks.TableName = "StudentsMarks"
        dtStudentMarks.Columns.Add("StudentId", GetType(Integer))
        dtStudentMarks.Columns.Add("SubkectId", GetType(Integer))
        dtStudentMarks.Columns.Add("SubjectName", GetType(String))
        dtStudentMarks.Columns.Add("Marks", GetType(Integer))

        'Adding Rows

        dtStudent.Rows.Add(111, "Devesh", "03021013014")
        dtStudent.Rows.Add(222, "ROLI", "0302101444")
        dtStudent.Rows.Add(333, "ROLI Ji", "030212222")
        dtStudent.Rows.Add(444, "NIKHIL", "KANPUR")

        ' data for devesh ID=111
        dtStudentMarks.Rows.Add(111, "01", "Physics", 99)
        dtStudentMarks.Rows.Add(111, "02", "Maths", 77)
        dtStudentMarks.Rows.Add(111, "03", "C#", 100)
        dtStudentMarks.Rows.Add(111, "01", "Physics", 99)


        'data for ROLI ID=222
        dtStudentMarks.Rows.Add(222, "01", "Physics", 80)
        dtStudentMarks.Rows.Add(222, "02", "English", 95)
        dtStudentMarks.Rows.Add(222, "03", "Commerce", 95)
        dtStudentMarks.Rows.Add(222, "01", "BankPO", 99)

        Dim dsDataSet As New DataSet()
        dsDataSet.Tables.Add(dtStudent)
        dsDataSet.Tables.Add(dtStudentMarks)

        ' Establish a relationship between the two tables.
        Dim relation As New DataRelation("StudentsMarks", _
            dsDataSet.Tables("Students").Columns("StudentId"), _
            dsDataSet.Tables("StudentsMarks").Columns("StudentId"))

        dsDataSet.Relations.Add(relation)


        ' Bind the master data connector to the Customers table.
        masterBindingSource.DataSource = dsDataSet
        masterBindingSource.DataMember = "Students"

        detailsBindingSource.DataSource = masterBindingSource
        detailsBindingSource.DataMember = "StudentsMarks"
      
    End Sub
End Class
