using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public static class DbRequest
    {
        public static string Requests()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\Requests\Requests.sql");
        }
    }
}
