<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.masterDataGridView = New System.Windows.Forms.DataGridView()
        Me.detailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.masterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.detailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.masterDataGridView,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.detailsDataGridView,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.masterBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.detailsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'masterDataGridView
        '
        Me.masterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.masterDataGridView.Dock = System.Windows.Forms.DockStyle.Top
        Me.masterDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.masterDataGridView.Name = "masterDataGridView"
        Me.masterDataGridView.Size = New System.Drawing.Size(771, 186)
        Me.masterDataGridView.TabIndex = 0
        '
        'detailsDataGridView
        '
        Me.detailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.detailsDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.detailsDataGridView.Location = New System.Drawing.Point(0, 253)
        Me.detailsDataGridView.Name = "detailsDataGridView"
        Me.detailsDataGridView.Size = New System.Drawing.Size(771, 194)
        Me.detailsDataGridView.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 447)
        Me.Controls.Add(Me.detailsDataGridView)
        Me.Controls.Add(Me.masterDataGridView)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.masterDataGridView,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.detailsDataGridView,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.masterBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.detailsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents masterDataGridView As DataGridView
    Friend WithEvents detailsDataGridView As DataGridView
    Friend WithEvents masterBindingSource As BindingSource
    Friend WithEvents detailsBindingSource As BindingSource
End Class
