using System.IO;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;

namespace ITI.SchoolDatabase.Impl
{
    public class ScriptExecutor
    {
        /// <summary>
        /// Execute a script from a file
        /// </summary>
        /// <param name="path">Path's file</param>
        /// <param name="connection">SQL connection</param>
        public void ScriptExe(string path, SqlConnection connection)
        {
            string script = File.ReadAllText(path);
            string[] scripts = script.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Execute a script
        /// </summary>
        /// <param name="script">script</param>
        /// <param name="connection">SQL connection</param>
        public void Exe(string script, SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute a script 
        /// </summary>
        /// <param name="script">Script</param>
        /// <param name="connection">SQL connection</param>
        /// <param name="columnName">Name of the requested column</param>
        /// <returns>List of values of "columnName"</returns>
        public IEnumerable<string> ScriptReader(string script, SqlConnection connection, string columnName)
        {
            throw new NotImplementedException();
        }
    }
}
