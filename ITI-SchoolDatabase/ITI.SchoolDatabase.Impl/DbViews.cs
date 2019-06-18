using ITI.SchoolDatabase.Model;
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
        /// <summary>
        /// Call View.sql
        /// </summary>
        /// <returns></returns>
        public static string Views()
        {
			throw new NotImplementedException();
		}

        /// <summary>
        /// Call View
        /// </summary>
        /// <param name="connection">Sql connection</param>
        /// <returns>View result</returns>
		public static IEnumerable<View> GetViewValues(SqlConnection connection)
        {
			throw new NotImplementedException();
		}
	}
}
