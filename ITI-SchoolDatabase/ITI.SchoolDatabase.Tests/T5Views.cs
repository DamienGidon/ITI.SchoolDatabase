using FluentAssertions;
using ITI.SchoolDatabase.Impl;
using ITI.SchoolDatabase.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Tests
{
    [TestFixture]
    public class T5Views
    {
        /// <summary>
        /// View that should return the list of all students by displaying : 
        /// Student's name as 'StudentName', Semester, Orientation, Teacher's main name as 'TeacherName', and the room as that 'RoomName'
        /// </summary>
        [Test]
        public void T1_Create_StudentsView()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();
                exe.ScriptExe(DbViews.Views(), connection);

                string cmdText = @"USE itiSchoolDB IF EXISTS (SELECT * FROM sys.objects WHERE type = 'V' AND name = 'StudentsView') SELECT 1 ELSE SELECT 0";
                SqlCommand DateCheck = new SqlCommand(cmdText, connection);
                int x = Convert.ToInt32(DateCheck.ExecuteScalar());
                x.Should().Be(1);

                // Check if already Exist
                exe.ScriptExe(DbViews.Views(), connection);
            }
        }

        [Test]
        public void T2_View_Returns_Expected_Values_Programmaticaly()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetDbConnectionString()))
            {
                connection.Open();

                ResetTable(connection);

                List<View> results = DbViews.GetViewValues(connection).ToList();

                Compare(results, GetAllUser()).Should().BeTrue();
            }
        }

        #region private Methode
        List<View> GetAllUser()
        {
            List<View> users = new List<View>();

            users.Add(item: new View("Pierre Viara", 6, "IL", "Antoine Raquillet", "E01"));
            users.Add(new View("Rodolf Vechter", 6, "SR", "Erico Lalita", ""));
            users.Add(new View("Thibault Cam", 10, "IL", "Olivier Spinelli", "E07"));
            users.Add(new View("Vin Diesel", 1, "SR", "Olivier Spinelli", "E07"));
            users.Add(new View("Monique Monrade", 1, "IL", "Michèle Talavéra", "E06"));
            users.Add(new View("Damien Gidon", 10, "IL", "Olivier Spinelli", "E07"));
            users.Add(new View("Jujou Ani", 5, "IL", "Antoine Raquillet", "E01"));
            users.Add(new View("Julie Laconépa", 9, "IL", "", ""));
            users.Add(new View("Kouinox Punchy", 3, "SR", "Erico Lalita", ""));
            users.Add(new View("Thibaud Duval", 9, "IL", "Catherine Dorignac", "E03"));
            users.Add(new View("Floriant Dugat", 5, "IL", "", ""));

            return users;
        }

        void ResetTable(SqlConnection connection)
        {
            ScriptExecutor exe = new ScriptExecutor();
            int c = (int)new SqlCommand(@"use itiSchoolDB SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('Classroom')", connection).ExecuteScalar();
            if (c > 0) new SqlCommand("DROP TABLE Classroom", connection).ExecuteScalar();
            int s = (int)new SqlCommand(@"use itiSchoolDB SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('Student')", connection).ExecuteScalar();
            if (s > 0) new SqlCommand("DROP TABLE Student", connection).ExecuteScalar();
            int t = (int)new SqlCommand(@"use itiSchoolDB SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('Teacher')", connection).ExecuteScalar();
            if (t > 0) new SqlCommand("DROP TABLE Teacher", connection).ExecuteScalar();

            exe.ScriptExe(DbInit.CreateTableTeacher(), connection);
            exe.ScriptExe(DbInsert.InsertTeacherTable(), connection);

            exe.ScriptExe(DbInit.CreateTableStudent(), connection);
            exe.ScriptExe(DbInsert.InsertStudentTable(), connection);

            exe.ScriptExe(DbInit.CreateTableClassroom(), connection);
            exe.ScriptExe(DbInsert.InsertClassroomTable(), connection);

        }

        private bool Compare(List<View> one, List<View> two)
        {
            foreach(View v in one)
            {
                var tmp = two.FirstOrDefault(x => x.StudentName == v.StudentName);
                if (tmp == null)
                    return false;
                if (tmp.Semestre != v.Semestre || tmp.Orientation != v.Orientation || tmp.TeacherName != v.TeacherName || tmp.RoomName != v.RoomName)
                    return false;
            }
            return true;
        }
        #endregion
    }
}
