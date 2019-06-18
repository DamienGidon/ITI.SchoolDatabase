using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public static class DbModificationScheme
    {
        public static string UpdateTableStudent()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\ModificationScheme\StudentMod.sql");
        }

        public static string UpdateTableTeacher()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SqlScript\ModificationScheme\TeacherMod.sql");
        }
    }
}
