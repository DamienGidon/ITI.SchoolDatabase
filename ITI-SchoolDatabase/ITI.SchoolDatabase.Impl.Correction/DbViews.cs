using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public static class DbViews
    {
        public static string Views()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\Views\View.sql");
        }

        public static IEnumerable<View> GetViewValues(SqlConnection connection)
        {
            using(SqlCommand command = new SqlCommand("SELECT * FROM StudentsView", connection))
            using (SqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    yield return new View(rdr["StudentName"].ToString(), Convert.ToInt32(rdr["Semestre"]), rdr["Orientation"].ToString(), rdr["TeacherName"].ToString(), rdr["RoomName"].ToString());
                }
            }
        }
    }
}
