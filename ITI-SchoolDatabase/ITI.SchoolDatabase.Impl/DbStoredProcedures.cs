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
			throw new NotImplementedException();
		}

		public static string StoredProceduresUpStudent()
        {
			throw new NotImplementedException();
		}

        /// <summary>
        /// Call FindStudent Proc
        /// </summary>
        /// <param name="param">Param to find students</param>
        /// <param name="connection">Sql Connection</param>
        /// <returns>All students nanme matching the param</returns>
		public static IEnumerable<string> FindStudent(string param, SqlConnection connection)
        {
			throw new NotImplementedException();

		}

        /// <summary>
        /// Call UpStudent Proc
        /// </summary>
        /// <param name="param"> List of Students who do not change semester </param>
        /// <param name="connection">Sql Connection</param>
        /// <returns>IEnumerable of students leaving school</returns>
		public static IEnumerable<string> UpStudent(string[] param, SqlConnection connection)
        {
			throw new NotImplementedException();
		}
	}
}
