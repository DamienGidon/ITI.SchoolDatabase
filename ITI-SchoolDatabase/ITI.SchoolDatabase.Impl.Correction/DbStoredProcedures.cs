using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public static class DbStoredProcedures
    {
        public static string StoredProceduresFindStudent()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\StoredProcedures\FindStudent.sql");
        }

        public static string StoredProceduresUpStudent()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\StoredProcedures\UpStudent.sql");
        }

        public static IEnumerable<string> FindStudent(string param, SqlConnection connection)
        {
            using (SqlCommand cmd = new SqlCommand("FindStudent", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ParamString", param));
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    yield return rdr["Name"].ToString();
                }
            }
        }

        public static IEnumerable<string> UpStudent(string[] param, SqlConnection connection)
        {
            var names = new DataTable();
            names.Columns.Add("Name", typeof(string));

            foreach (string item in param)
            {
               names.Rows.Add(item);
            }
            using (var command = new SqlCommand("UpStudent", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var pNames = command.Parameters.AddWithValue("@Students", names);
                pNames.SqlDbType = SqlDbType.Structured;
                pNames.TypeName = "StudentList";

                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                        yield return rdr["Name"].ToString();
                }
            }
        }
    }
}
