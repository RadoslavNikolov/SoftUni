namespace Plannig_BackgroundWorker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgExaminationRooms = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgTimeIntervals = new System.Windows.Forms.DataGridView();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationRoomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isFree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxHistory = new System.Windows.Forms.TextBox();
            this.comboBoxDoctors = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExaminationRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimeIntervals)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxHistory);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxDoctors);
            this.splitContainer1.Size = new System.Drawing.Size(903, 542);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgTimeIntervals);
            this.splitContainer2.Size = new System.Drawing.Size(903, 368);
            this.splitContainer2.SplitterDistance = 441;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgExaminationRooms);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dateTimePicker1);
            this.splitContainer3.Size = new System.Drawing.Size(441, 368);
            this.splitContainer3.SplitterDistance = 203;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgExaminationRooms
            // 
            this.dgExaminationRooms.AllowUserToAddRows = false;
            this.dgExaminationRooms.AllowUserToDeleteRows = false;
            this.dgExaminationRooms.AllowUserToResizeColumns = false;
            this.dgExaminationRooms.AllowUserToResizeRows = false;
            this.dgExaminationRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExaminationRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name1,
            this.ExaminationDuration});
            this.dgExaminationRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExaminationRooms.Location = new System.Drawing.Point(0, 0);
            this.dgExaminationRooms.MultiSelect = false;
            this.dgExaminationRooms.Name = "dgExaminationRooms";
            this.dgExaminationRooms.ReadOnly = true;
            this.dgExaminationRooms.RowHeadersVisible = false;
            this.dgExaminationRooms.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgExaminationRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgExaminationRooms.Size = new System.Drawing.Size(203, 368);
            this.dgExaminationRooms.TabIndex = 0;
            this.dgExaminationRooms.SelectionChanged += new System.EventHandler(this.dgExaminationRooms_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Name1
            // 
            this.Name1.DataPropertyName = "Name";
            this.Name1.HeaderText = "Name";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            this.Name1.Width = 200;
            // 
            // ExaminationDuration
            // 
            this.ExaminationDuration.DataPropertyName = "ExaminationDuration";
            this.ExaminationDuration.HeaderText = "ExaminationDuration";
            this.ExaminationDuration.Name = "ExaminationDuration";
            this.ExaminationDuration.ReadOnly = true;
            this.ExaminationDuration.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AllowDrop = true;
            this.dateTimePicker1.CustomFormat = "yyyy-MMM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePicker1.Location = new System.Drawing.Point(17, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dgTimeIntervals
            // 
            this.dgTimeIntervals.AllowUserToAddRows = false;
            this.dgTimeIntervals.AllowUserToDeleteRows = false;
            this.dgTimeIntervals.AllowUserToResizeColumns = false;
            this.dgTimeIntervals.AllowUserToResizeRows = false;
            this.dgTimeIntervals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimeIntervals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartTime,
            this.EndTime,
            this.PatientName,
            this.DayOfWeek,
            this.StaffId,
            this.ExaminationRoomId,
            this.isFree});
            this.dgTimeIntervals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTimeIntervals.Location = new System.Drawing.Point(0, 0);
            this.dgTimeIntervals.MultiSelect = false;
            this.dgTimeIntervals.Name = "dgTimeIntervals";
            this.dgTimeIntervals.ReadOnly = true;
            this.dgTimeIntervals.RowHeadersVisible = false;
            this.dgTimeIntervals.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgTimeIntervals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTimeIntervals.Size = new System.Drawing.Size(458, 368);
            this.dgTimeIntervals.TabIndex = 0;
            this.dgTimeIntervals.DataSourceChanged += new System.EventHandler(this.dgTimeIntervals_DataSourceChanged);
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            this.StartTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.StartTime.HeaderText = "Начало";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 70;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "EndTime";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Visible = false;
            // 
            // PatientName
            // 
            this.PatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "Име на пациент";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // DayOfWeek
            // 
            this.DayOfWeek.DataPropertyName = "DayOfWeek";
            this.DayOfWeek.HeaderText = "DayOfWeek";
            this.DayOfWeek.Name = "DayOfWeek";
            this.DayOfWeek.ReadOnly = true;
            this.DayOfWeek.Width = 50;
            // 
            // StaffId
            // 
            this.StaffId.DataPropertyName = "StaffId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StaffId.DefaultCellStyle = dataGridViewCellStyle2;
            this.StaffId.HeaderText = "StaffId";
            this.StaffId.Name = "StaffId";
            this.StaffId.ReadOnly = true;
            this.StaffId.Width = 50;
            // 
            // ExaminationRoomId
            // 
            this.ExaminationRoomId.DataPropertyName = "ExaminationRoomId";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExaminationRoomId.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExaminationRoomId.HeaderText = "ExaminationRoomId";
            this.ExaminationRoomId.Name = "ExaminationRoomId";
            this.ExaminationRoomId.ReadOnly = true;
            this.ExaminationRoomId.Width = 50;
            // 
            // isFree
            // 
            this.isFree.DataPropertyName = "isFree";
            this.isFree.HeaderText = "isFree";
            this.isFree.Name = "isFree";
            this.isFree.ReadOnly = true;
            this.isFree.Visible = false;
            // 
            // textBoxHistory
            // 
            this.textBoxHistory.Location = new System.Drawing.Point(556, 18);
            this.textBoxHistory.Multiline = true;
            this.textBoxHistory.Name = "textBoxHistory";
            this.textBoxHistory.ReadOnly = true;
            this.textBoxHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHistory.Size = new System.Drawing.Size(335, 140);
            this.textBoxHistory.TabIndex = 1;
            // 
            // comboBoxDoctors
            // 
            this.comboBoxDoctors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDoctors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDoctors.FormattingEnabled = true;
            this.comboBoxDoctors.Location = new System.Drawing.Point(12, 18);
            this.comboBoxDoctors.Name = "comboBoxDoctors";
            this.comboBoxDoctors.Size = new System.Drawing.Size(278, 24);
            this.comboBoxDoctors.TabIndex = 0;
            this.comboBoxDoctors.SelectionChangeCommitted += new System.EventHandler(this.comboBoxDoctors_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 542);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgExaminationRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimeIntervals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgExaminationRooms;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dgTimeIntervals;
        private System.Windows.Forms.ComboBox comboBoxDoctors;
        private System.Windows.Forms.TextBox textBoxHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayOfWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationRoomId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isFree;
    }
}

