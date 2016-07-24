using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace Plannig_BackgroundWorker.Data
{
    public static class DataAccess
    {
        private static string GetSqlConnection()
        {
            const string connectionString = "Data Source=RadkoDesktop;Initial Catalog=Planning;Persist Security Info=True;User ID=sa;Password=extra";

            return connectionString;
        }

        public static DataTable GetDoctors()
        {
            const string sqlStr = "SELECT Id, FirstName, MiddleName, LastName, Title, IsDoctor, Title + ' ' + FirstName + ' ' + MiddleName + ' ' + LastName As FullName" +
                "  FROM Staff WHERE IsDoctor = 1 ORDER BY FirstName, MiddleName, LastName";
            var dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(GetSqlConnection()))
            {
                conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public static DataTable GetExaminationsRooms()
        {
            const string sqlStr = "SELECT * FROM ExaminationRooms ORDER BY Name";
            var dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(GetSqlConnection()))
            {
                conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public static DataTable GetTimeIntervals()
        {
            const string sqlStr = "select * from TimeIntervals ti " +
                " inner join doctorsschedules ds on ti.DoctorScheduleId = ds.Id " +
                " inner join Staff s on s.Id = ds.staffid " +
                " inner join ExaminationRooms er  on ds.ExaminationRoomId = er.Id ";
            var dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(GetSqlConnection()))
            {
                conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public static DataTable GetResrvationsByDate(DateTime reservationDate)
        {
            var sqlStr = $"SELECT * FROM Reservations WHERE YEAR('{reservationDate}') = YEAR(ReservationDate) AND MONTH('{reservationDate}') = MONTH(ReservationDate) AND DAY('{reservationDate}') = DAY(ReservationDate)";

            var dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(GetSqlConnection()))
            {
                conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

    }
}