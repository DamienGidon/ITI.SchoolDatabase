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

		public static IEnumerable<string> FindStudent(string param, SqlConnection connection)
        {
			throw new NotImplementedException();

		}

		public static IEnumerable<string> UpStudent(string[] param, SqlConnection connection)
        {
			throw new NotImplementedException();
		}
	}
}
