using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public static class DbInit
    {

        public static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString("DefaultConnection");
        }

        public static string GetDbConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString("DbConnection");
        }

        public static string CreateDatabse()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\CreateItiSchoolDb.sql");
        }

        //Call script sql Create Teacher Table
        public static string CreateTableTeacher()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\CreateTable\CreateTeacherTable.sql");
        }

        public static string CreateTableClassroom()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\CreateTable\CreateClassroomTable.sql");

        }

        public static string CreateTableStudent()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\CreateTable\CreateStudentTable.sql");
        }
    }
}
