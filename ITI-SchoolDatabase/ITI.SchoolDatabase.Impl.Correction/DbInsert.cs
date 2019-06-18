using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public static class DbInsert
    {
        public static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString("DefaultConnection");
        }

        //Call script sql Insert Teacher Table
        public static string InsertTeacherTable()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\Insert\InsertTeachers.sql");
        }

        //Call script sql Insert Student Table
        public static string InsertStudentTable()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\Insert\InsertStudents.sql");
        }

        //Call script sql Insert Classroom Table
        public static string InsertClassroomTable()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\Insert\InsertClassrooms.sql");
        }
    }
}
