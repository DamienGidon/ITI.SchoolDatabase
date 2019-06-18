using FluentAssertions;
using ITI.SchoolDatabase.Impl;
using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ITI.SchoolDatabase.Tests
{
    [TestFixture]
    public class T3ModificationSchemeDB
    {
        [Test]
        public void T1_check_if_firstName_lastname_column_in_student_table_are_created_and_filled()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ResetTables(connection);

                ScriptExecutor exe = new ScriptExecutor();

                DataTable StudentDataTableBefore = new DataTable();
                string queryBefore = "use itiSchoolDB select * from Student";
                SqlCommand cmdBefore = new SqlCommand(queryBefore, connection);
                SqlDataAdapter daBefore = new SqlDataAdapter(cmdBefore);
                daBefore.Fill(StudentDataTableBefore);
                StudentDataTableBefore.Columns.Count.Should().Be(6);

                exe.ScriptExe(DbModificationScheme.UpdateTableStudent(), connection);

                DataTable datatable = new DataTable();

                string query = "select * from Student";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(datatable);

                datatable.Columns.Contains("Guid").Should().BeTrue();
                datatable.Columns.Contains("Name").Should().BeTrue();
                datatable.Columns.Contains("Semestre").Should().BeTrue();
                datatable.Columns.Contains("Orientation").Should().BeTrue();
                datatable.Columns.Contains("BirthDate").Should().BeTrue();
                datatable.Columns.Contains("MainTeacher").Should().BeTrue();
                datatable.Columns.Contains("Lastname").Should().BeTrue();
                datatable.Columns.Contains("Firstname").Should().BeTrue();
                datatable.Columns.Count.Should().Be(8);

                string students = "use itiSchoolDB select Name, Firstname, Lastname from Student";
                SqlCommand cmd1 = new SqlCommand(students, connection);
                SqlDataReader reader = cmd1.ExecuteReader();
                string fullNameConcat = "";
                string baseName = "";
                try
                {
                    while (reader.Read())
                    {
                        baseName = (String.Format("{0}", reader["Name"]));
                        fullNameConcat = (String.Format("{0} {1}", reader["Firstname"], reader["Lastname"]));
                        fullNameConcat.Should().Be(baseName);
                    }
                }
                finally
                {
                    reader.Close();
                }

                connection.Close();
            }
        }

        [Test]
        public void T2_check_if_firstName_lastname_column_in_teacher_table_are_created_and_filled_For_Teachers_Born_After_1975()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ResetTables(connection);

                ScriptExecutor exe = new ScriptExecutor();

                DataTable TeacherDataTableBefore = new DataTable();
                string queryBefore = "use itiSchoolDB select * from Teacher";
                SqlCommand cmdBefore = new SqlCommand(queryBefore, connection);
                SqlDataAdapter daBefore = new SqlDataAdapter(cmdBefore);
                daBefore.Fill(TeacherDataTableBefore);
                TeacherDataTableBefore.Columns.Count.Should().Be(6);

                exe.ScriptExe(DbModificationScheme.UpdateTableTeacher(), connection);

                DataTable datatable = new DataTable();

                string query = "select * from Teacher";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(datatable);

                datatable.Columns.Contains("Guid").Should().BeTrue();
                datatable.Columns.Contains("Name").Should().BeTrue();
                datatable.Columns.Contains("Course").Should().BeTrue();
                datatable.Columns.Contains("Orientation").Should().BeTrue();
                datatable.Columns.Contains("BirthDate").Should().BeTrue();
                datatable.Columns.Contains("IsInternal").Should().BeTrue();
                datatable.Columns.Contains("Lastname").Should().BeTrue();
                datatable.Columns.Contains("Firstname").Should().BeTrue();
                datatable.Columns.Count.Should().Be(8);

                string teachersWithFullName = "use itiSchoolDB select Name, Firstname, Lastname from Teacher where BirthDate > Convert(date, '1975-12-12' )";
                string teachersWithoutFullName = "use itiSchoolDB select Name, Firstname, Lastname from Teacher where BirthDate <= Convert(date, '1975-12-12' )";
                SqlCommand cmd1 = new SqlCommand(teachersWithFullName, connection);
                SqlCommand cmd2 = new SqlCommand(teachersWithoutFullName, connection);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                string fullNameConcat = "";
                string baseName = "";
                try
                {
                    while (reader1.Read())
                    {
                        baseName = (String.Format("{0}", reader1["Name"]));
                        fullNameConcat = (String.Format("{0} {1}", reader1["Firstname"], reader1["Lastname"]));
                        fullNameConcat.Should().Be(baseName);
                    }
                    while (reader2.Read())
                    {
                        baseName = String.Format("{0}", reader2["Name"]);
                        fullNameConcat = string.IsNullOrWhiteSpace(String.Format("{0} {1}", reader2["Firstname"], reader2["Lastname"])) ? null : String.Format("{0} {1}", reader2["Firstname"], reader2["Lastname"]);
                        fullNameConcat.Should().BeNull();
                    }
                }
                finally
                {
                    reader1.Close();
                    reader2.Close();
                }

                connection.Close();
            }
        }

        #region private methode
        void ResetTables(SqlConnection connection)
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
        #endregion
    }
}

