using ITI.SchoolDatabase.Impl;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ITI.SchoolDatabase.Tests
{
    [TestFixture]
    public class T2initializationDb
    {

        const string _databaseName = "itiSchoolDB";

        [Test]
        public void T1_check_if_database_is_created()
        {
            ScriptExecutor exe = new ScriptExecutor();

            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();
                bool databaseExists;

                string checkIfExistCommand = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", _databaseName);
                SqlCommand sqlCmd = new SqlCommand(checkIfExistCommand, connection);
                object resultObj = sqlCmd.ExecuteScalar();

                int databaseID = 0;

                if (resultObj != null)
                {
                    int.TryParse(resultObj.ToString(), out databaseID);
                }

                databaseExists = (databaseID > 0);
                if (databaseExists == false)
                {
                    exe.ScriptExe(DbInit.CreateDatabse(),connection);
                    resultObj = sqlCmd.ExecuteScalar();
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    databaseID.Should().BeGreaterThan(0);
                }
                else
                {
                    String dropBaseCommand = "ALTER DATABASE "+ _databaseName +" SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE " + _databaseName;
                    SqlCommand sqlCommand = new SqlCommand(dropBaseCommand, connection);
                    sqlCommand.ExecuteScalar();
                    resultObj = sqlCmd.ExecuteScalar();
                    exe.ScriptExe(DbInit.CreateDatabse(),connection);
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    databaseID.Should().BeGreaterThan(0);
                }
            }
        }

        [Test]
        public void T2_check_if_teacher_table_is_created()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();

                int t = (int) new SqlCommand(@"use itiSchoolDB SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('Teacher')", connection).ExecuteScalar();
                if (t > 0) new SqlCommand("DROP TABLE Teacher", connection).ExecuteScalar();

                exe.ScriptExe(DbInit.CreateTableTeacher(), connection);

                string cmdText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='Teacher ') SELECT 1 ELSE SELECT 0";
                SqlCommand DateCheck = new SqlCommand(cmdText, connection);
                int x = Convert.ToInt32(DateCheck.ExecuteScalar());
                x.Should().Be(1);

                DataTable datatable = new DataTable();

                string query = "select * from Teacher";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(datatable);

                datatable.Columns.Contains("Guid").Should().Be(true);
                datatable.Columns.Contains("Name").Should().Be(true);
                datatable.Columns.Contains("Course").Should().Be(true);
                datatable.Columns.Contains("BirthDate").Should().Be(true);
                datatable.Columns.Contains("IsInternal").Should().Be(true);
                connection.Close();
            }
        }

        [Test]
        public void T3_check_if_classroom_table_is_created()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();
                ScriptExecutor exe = new ScriptExecutor();

                int t = (int)new SqlCommand(@"use itiSchoolDB SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('Classroom')", connection).ExecuteScalar();
                if (t > 0) new SqlCommand("DROP TABLE Classroom", connection).ExecuteScalar();

                exe.ScriptExe(DbInit.CreateTableClassroom(), connection);

                string cmdText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='Classroom ') SELECT 1 ELSE SELECT 0";
                SqlCommand DateCheck = new SqlCommand(cmdText, connection);
                int x = Convert.ToInt32(DateCheck.ExecuteScalar());
                x.Should().Be(1);

                DataTable datatable = new DataTable();

                string query = "select * from Classroom";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(datatable);
                datatable.Columns.Contains("Guid").Should().Be(true);
                datatable.Columns.Contains("Name").Should().Be(true);
                datatable.Columns.Contains("Capacity").Should().Be(true);
                datatable.Columns.Contains("Projector").Should().Be(true);
                connection.Close();
            }
        }

        [Test]
        public void T4_check_if_Student_table_is_created()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();

                int t = (int)new SqlCommand(@"use itiSchoolDB SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('Student')", connection).ExecuteScalar();
                if (t > 0) new SqlCommand("DROP TABLE Student", connection).ExecuteScalar();

                exe.ScriptExe(DbInit.CreateTableStudent(), connection);

                string cmdText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='Student ') SELECT 1 ELSE SELECT 0";
                SqlCommand DateCheck = new SqlCommand(cmdText, connection);
                int x = Convert.ToInt32(DateCheck.ExecuteScalar());
                x.Should().Be(1);

                DataTable datatable = new DataTable();

                string query = "select * from Student";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(datatable);
                datatable.Columns.Contains("Guid").Should().Be(true);
                datatable.Columns.Contains("Name").Should().Be(true);
                datatable.Columns.Contains("Semestre").Should().Be(true);
                datatable.Columns.Contains("Orientation").Should().Be(true);
                datatable.Columns.Contains("BirthDate").Should().Be(true);
                datatable.Columns.Contains("MainTeacher").Should().Be(true);
                connection.Close();
            }
        }

        [Test]
        public void T5_check_if_tables_are_filled()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();
                exe.ScriptExe(DbInsert.InsertTeacherTable(), connection);
                exe.ScriptExe(DbInsert.InsertStudentTable(), connection);
                exe.ScriptExe(DbInsert.InsertClassroomTable(), connection);

                DataTable datatableStudent = new DataTable();
                DataTable datatableTeacher = new DataTable();
                DataTable datatableClassroom = new DataTable();

                string teachers = "select count(*) from Teacher";
                string students = "select count(*) from Student";
                string classrooms = "select count(*) from Classroom";

                SqlCommand cmd1 = new SqlCommand(teachers, connection);
                SqlCommand cmd2 = new SqlCommand(students, connection);
                SqlCommand cmd3 = new SqlCommand(classrooms, connection);

                int sqlresult1 = (Int32)cmd1.ExecuteScalar();
                int sqlresult2 = (Int32)cmd2.ExecuteScalar();
                int sqlresult3 = (Int32)cmd3.ExecuteScalar();

                sqlresult1.Should().Be(9);
                sqlresult2.Should().Be(11);
                sqlresult3.Should().Be(8);
                connection.Close();
            }
        }
    }
}

