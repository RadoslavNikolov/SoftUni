using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Plannig_BackgroundWorker.Data;

namespace Plannig_BackgroundWorker
{
    public partial class Form1 : Form
    {
        private event EventHandler ReservationsAdded;

        private DataView _dvDoctors;
        private DataView _dvExaminationRooms;
        private readonly Dictionary<DateTime, Dictionary<int, DataView>> _timeIntervalsDictionary;
        private readonly Dictionary<DateTime, DataTable> _reservationsByDate;
        private DataTable _timeIntervals;

        private readonly object _thisLock;
        private bool _formLoaded;

        public Form1()
        {
            InitializeComponent();

            _thisLock = new object();
            _timeIntervalsDictionary = new Dictionary<DateTime, Dictionary<int, DataView>>();
            _reservationsByDate = new Dictionary<DateTime, DataTable>();

            InitializeFormMemebers();

        }

        private void InitializeFormMemebers()
        {
            comboBoxDoctors.ValueMember = "Id";
            comboBoxDoctors.DisplayMember = "FullName";

            FillDoctorsAsync();
            FillExaminationsRoomsAsync();
            FillReservationsAsync();
            FillTimeIntervals();
            CalculateTimeIntervalsAsync(dateTimePicker1.Value);
        }



        private void FillReservationsAsync()
        {
            var bgw = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };

            bgw.DoWork += (s, args) =>
            {
                args.Result = DataAccess.GetResrvationsByDate(dateTimePicker1.Value);
            };

            bgw.RunWorkerCompleted += (s, args) =>
            {
                if (args.Error != null)
                {
                    textBoxHistory.AppendText(args.Error.Message);
                }
                else
                {
                    var dt = (DataTable)args.Result;

                    _reservationsByDate[dateTimePicker1.Value.Date] = dt;


                    textBoxHistory.AppendText($"Reservations for {dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} was filled from dataabase. \n {dt.Rows.Count} items fillead. \n");
                }
            };

            lock (_thisLock)
            {
                if (dateTimePicker1.Value.Date >= DateTime.Now.Date)
                {
                    if (!bgw.IsBusy)
                    {
                        bgw.RunWorkerAsync();
                    }
                }
                else
                {
                    if (!_reservationsByDate.ContainsKey(dateTimePicker1.Value.Date))
                    {
                        bgw.RunWorkerAsync();
                    }
                }
            }          
        }

        private void CalculateTimeIntervalsAsync(DateTime date)
        {
            var bgw = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true

            };

            bgw.DoWork += (s, args) =>
            {
                DoCalculation(date);
            };

            bgw.RunWorkerCompleted += (s, args) =>
            {
                if (args.Error != null)
                {
                    textBoxHistory.AppendText(args.Error.Message);
                }
                else
                {
                    var examinationRoomId = 0;
                    if (dgExaminationRooms.SelectedRows.Count > 0)
                    {
                        examinationRoomId = (int)dgExaminationRooms.SelectedRows[0].Cells["Id"].Value;
                    }

                    lock (_thisLock)
                    {
                        if (_timeIntervalsDictionary.ContainsKey(date.Date) && _timeIntervalsDictionary[date.Date].ContainsKey(examinationRoomId))
                        {
                            dgTimeIntervals.DataSource = _timeIntervalsDictionary[date.Date][examinationRoomId];
                        }
                    }

                    textBoxHistory.AppendText($"Calculation was made for date: {date.Date.ToString("yyyy-MM-dd")} \n");
                }
            };


            if (!bgw.IsBusy)
            {
                bgw.RunWorkerAsync();
            }

        }

        private void DoCalculation(DateTime date)
        {
            lock (_thisLock)
            {
                if (_timeIntervalsDictionary.ContainsKey(date.Date))
                {
                    return;
                }
            }

            var dayOfWeekInt = (int)date.DayOfWeek;

            if (dayOfWeekInt == 0)
            {
                dayOfWeekInt = 7;
            }


            lock (_thisLock)
            {
                var query = _timeIntervals.AsEnumerable()
                    .Where(x => x.Field<int>("DayOfWeek") == dayOfWeekInt)
                    .OrderBy(x => x.Field<TimeSpan>("StartTime"))
                    .GroupBy(x => x.Field<int>("ExaminationRoomId"));

                var groupings = query as IGrouping<int, DataRow>[] ?? query.ToArray();

                if (!groupings.Any())
                {
                    return;
                }

                foreach (var group in groupings)
                {
                    var tempTable = new DataTable();
                    tempTable.Columns.Add("StartTime", typeof(TimeSpan));
                    tempTable.Columns.Add("EndTime", typeof(TimeSpan));
                    tempTable.Columns.Add("PatientName", typeof(string));
                    tempTable.Columns.Add("DayOfWeek", typeof(int));
                    tempTable.Columns.Add("StaffId", typeof(int));
                    tempTable.Columns.Add("ExaminationRoomId", typeof(int));
                    tempTable.Columns.Add("isFree", typeof(bool));

                    var examinationRoomId = group.Key;
                    var examinationDuration = group.First().Field<int>("ExaminationDuration");
                    var dayOfWeek = group.First().Field<int>("DayOfWeek");

                    foreach (var dataRow in group)
                    {
                        TimeSpan originalStartTime = dataRow.Field<TimeSpan>("StartTime");
                        TimeSpan originalEndTime = dataRow.Field<TimeSpan>("EndTime");
                        var staffId = dataRow.Field<int>("StaffId");
                        var tempStart = originalStartTime;
                        var tempEnd = originalStartTime;

                        // Fill valid rows
                        tempStart = originalStartTime;
                        tempEnd = originalEndTime;
                        while (tempStart < tempEnd)
                        {
                            tempTable.Rows.Add(tempStart, tempStart.Add(new TimeSpan(0, examinationDuration, 0)), string.Empty, dayOfWeek, staffId, examinationRoomId, true);
                            tempStart = tempStart.Add(new TimeSpan(0, examinationDuration, 0));
                        }

                    }

                    if (!_timeIntervalsDictionary.ContainsKey(date.Date))
                    {
                        _timeIntervalsDictionary[date.Date] = new Dictionary<int, DataView>();
                    }

                    _timeIntervalsDictionary[date.Date][examinationRoomId] = new DataView(tempTable);
                }
            }
        }

        private void FillTimeIntervals()
        {
            _timeIntervals = DataAccess.GetTimeIntervals();
            textBoxHistory.AppendText($"Intervals was filled from dataabase. \n {_timeIntervals.Rows.Count} items fillead. \n");
        }


        private void FillExaminationsRoomsAsync()
        {
            var bgw = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };

            var dt = new DataTable();

            bgw.DoWork += delegate
            {
                dt = DataAccess.GetExaminationsRooms();
            };

            bgw.RunWorkerCompleted += (s, args) =>
            {
                if (args.Error != null)
                {
                    textBoxHistory.AppendText(args.Error.Message);
                }
                else
                {
                    _dvExaminationRooms = new DataView(dt);
                    dgExaminationRooms.DataSource = _dvExaminationRooms;
                    textBoxHistory.AppendText($"Examination rooms was filled from dataabase. \n {dt.Rows.Count} items fillead. \n");
                }
            };

            if (!bgw.IsBusy)
            {
                bgw.RunWorkerAsync();
            }
        }

        private void FillDoctorsAsync()
        {
            var bgw = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            var dt = new DataTable();

            bgw.DoWork += delegate
            {
                dt = DataAccess.GetDoctors();
            };

            bgw.RunWorkerCompleted += (s, args) =>
            {
                if (args.Error != null)
                {
                    textBoxHistory.AppendText(args.Error.Message);
                }
                else
                {
                    var newRow = dt.NewRow();
                    newRow["Id"] = 0;
                    newRow["FirstName"] = string.Empty;
                    newRow["MiddleName"] = string.Empty;
                    newRow["LastName"] = string.Empty;
                    newRow["Title"] = string.Empty;
                    newRow["isDoctor"] = true;
                    newRow["FullName"] = " без препочитания";
                    dt.Rows.InsertAt(newRow, 0);

                    _dvDoctors = new DataView(dt);
                    comboBoxDoctors.DataSource = _dvDoctors;
                    textBoxHistory.AppendText($"Doctors was filled from dataabase. \n {dt.Rows.Count} items fillead. \n");
                }

            };

            if (!bgw.IsBusy)
            {
                bgw.RunWorkerAsync();
            }

        }

        private void dgExaminationRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (!_formLoaded || dgExaminationRooms.SelectedRows.Count <= 0)
            {
                return;
            }

            var examinationRoomId = 0;
            if (dgExaminationRooms.SelectedRows.Count > 0)
            {
                examinationRoomId = (int)dgExaminationRooms.SelectedRows[0].Cells["Id"].Value;
            }

            ReloadTimeIntervals(examinationRoomId);
        }

        private void ReloadTimeIntervals(int examinationRoomId)
        {
            if (examinationRoomId == 0)
            {
                dgTimeIntervals.DataSource = new DataView();
            }
            else
            {
                lock (_thisLock)
                {
                    if (_timeIntervalsDictionary.ContainsKey(dateTimePicker1.Value.Date) && _timeIntervalsDictionary[dateTimePicker1.Value.Date].ContainsKey(examinationRoomId))
                    {
                        dgTimeIntervals.DataSource = _timeIntervalsDictionary[dateTimePicker1.Value.Date][examinationRoomId];
                    }
                    else
                    {
                        dgTimeIntervals.DataSource = new DataView();
                    }
                }
            }
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            _formLoaded = true;
        }

        private void comboBoxDoctors_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterTimeIntervalsByDoctorId((int)comboBoxDoctors.SelectedValue);
        }

        private void FilterTimeIntervalsByDoctorId(int selectedValue)
        {
            if (selectedValue == 0)
            {
                ((DataView)dgTimeIntervals.DataSource).RowFilter = string.Empty;

                return;
            }

            ((DataView)dgTimeIntervals.DataSource).RowFilter = $" StaffId = {selectedValue}";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!_formLoaded)
            {
                return;
            }

            CalculateTimeIntervalsAsync(dateTimePicker1.Value);
            FillReservationsAsync();
        }

        private void UnionTimeIntervalWithReservations()
        {          
            lock (_thisLock)
            {
                if (!_reservationsByDate.ContainsKey(dateTimePicker1.Value.Date))
                {
                    return;
                }
            }

            var examinationRoomId = 0;
            if (dgExaminationRooms.SelectedRows.Count > 0)
            {
                examinationRoomId = (int)dgExaminationRooms.SelectedRows[0].Cells["Id"].Value;
            }

            if (!_timeIntervalsDictionary.ContainsKey(dateTimePicker1.Value.Date) || !_timeIntervalsDictionary[dateTimePicker1.Value.Date].ContainsKey(examinationRoomId))
            {
                return;
            }

            var dv = _timeIntervalsDictionary[dateTimePicker1.Value.Date][examinationRoomId];

            if (dv.Count <= 0)
            {
                return;
            }

            var rowsIdsToGray = new List<int>();
            var reservations = _reservationsByDate[dateTimePicker1.Value.Date].AsEnumerable()
                .Where(x => x.Field<int>("ExaminationRoomId") == examinationRoomId);

            dv.Sort = " StartTime ASC";
            foreach (DataRow reservationRow in reservations)
            {

                var dvRows = dv.FindRows(new object[] {reservationRow.Field<DateTime>("ReservationDate").TimeOfDay});

                foreach (DataRowView dataRowView in dvRows)
                {
                    var id = dv.Find(dataRowView["StartTime"]);
                    rowsIdsToGray.Add(id);

                    dataRowView["isFree"] = false;
                    dataRowView["PatientName"]= reservationRow["PersonName"];
                }
            }

            foreach (var index in rowsIdsToGray)
            {
                dgTimeIntervals.Rows[index].DefaultCellStyle.BackColor = Color.LightSlateGray;
            }
        }

        private void dgTimeIntervals_DataSourceChanged(object sender, EventArgs e)
        {
            UnionTimeIntervalWithReservations();
        }
    }
}
