using System.IO;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;

namespace ITI.SchoolDatabase.Impl
{
    public class ScriptExecutor
    {
        public void ScriptExe(string path, SqlConnection connection)
        {
            string script = File.ReadAllText(path);
            string[] scripts = script.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var splitScript in scripts)
            {
                Exe(splitScript, connection);
            }
        }

        public void Exe(string script, SqlConnection connection)
        {
            SqlCommand createDbCommand = new SqlCommand(script, connection);
            createDbCommand.ExecuteScalar();
        }

        public IEnumerable<string> ScriptReader(string script, SqlConnection connection, string columnName)
        {
            using (var command = new SqlCommand(script, connection))
            {
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        yield return read[columnName].ToString();
                    }
                }
            }
        }
    }
}
