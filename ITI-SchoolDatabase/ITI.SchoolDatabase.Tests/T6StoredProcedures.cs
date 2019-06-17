using FluentAssertions;
using ITI.SchoolDatabase.Impl;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Tests
{
    [TestFixture]
    public class T6StoredProcedures
    {
        [Test]
        public void T1_Create_Proc_FindStudent_With_Specific_String_In_Their_Name()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();
                exe.ScriptExe(DbStoredProcedures.StoredProceduresFindStudent(), connection);

                string cmdText = @"USE itiSchoolDB IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'FindStudent') SELECT 1 ELSE SELECT 0";
                SqlCommand DateCheck = new SqlCommand(cmdText, connection);
                int x = Convert.ToInt32(DateCheck.ExecuteScalar());
                x.Should().Be(1);

                // Check if already Exist
                exe.ScriptExe(DbStoredProcedures.StoredProceduresFindStudent(), connection);
            }
        }

        [TestCase("in", 2, new string[] { "Kouinox Punchy", "Vin Diesel" })]
        [TestCase("lo", 1, new string[] { "Floriant Dugat"})]
        [TestCase("st", 0, new string[] { })]
        [TestCase("on", 3, new string[] { "Damien Gidon", "Julie Laconépa", "Monique Monrade"})]
        public void T2_Call_FindStudent_Proc(string param, int success, string[] arraySuccess)
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetDbConnectionString()))
            {
                connection.Open();

                List<string> results = DbStoredProcedures.FindStudent(param, connection).ToList();
                results.Count.Should().Be(success);
                if(success > 0)
                {
                    foreach (string suc in arraySuccess)
                    {
                        Assert.Contains(suc, results);
                    }
                }
            }
        }
        /// <summary>
        /// Creer une proc qui prend une liste en param et qui va incrementer le semestre de tous les élèves qui ne sont pas dans cette liste. Elle retournera les élèves qui on dépassé le S10 avant de les supprimer
        /// Nom du parametre : @Students
        /// </summary>
        [TestCase(new string[] { "Monique Monrade", "Damien Gidon" }, 1, new string[] { "Thibault Cam"}, 10)]
        [TestCase(new string[] { "Monique Monrade" }, 2, new string[] { "Thibault Cam", "Damien Gidon" }, 9)]
        [TestCase(new string[] { "Thibault Cam", "Damien Gidon" }, 0, new string[] {  }, 11)]
        [TestCase(new string[] { }, 2, new string[] { "Thibault Cam", "Damien Gidon" }, 9)]
        public void T3_Create_Proc_UpStudent(string[] redoublants, int nbValidated, string[] validatedNames, int sizeTable)
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();
                exe.ScriptExe(DbStoredProcedures.StoredProceduresUpStudent(), connection);

                string cmdText = @"USE itiSchoolDB IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpStudent') SELECT 1 ELSE SELECT 0";
                SqlCommand DateCheck = new SqlCommand(cmdText, connection);
                int x = Convert.ToInt32(DateCheck.ExecuteScalar());
                x.Should().Be(1);

                // Check if already Exist
                exe.ScriptExe(DbStoredProcedures.StoredProceduresUpStudent(), connection);

                ResetTable(connection);

                // Test if proc is working
                StringBuilder str = new StringBuilder("use itiSchoolDB");
                str.Append(" DECLARE @Students AS StudentList");
                for(int i = 0; i < redoublants.Length; i++)
                    str.Append(" INSERT INTO @Students VALUES ('"+ redoublants[i]+"')");
                str.Append(" EXEC UpStudent @Students");

                List<string> results = exe.ScriptReader(str.ToString(), connection, "Name").ToList();
                results.Count.Should().Be(nbValidated);
                foreach (string suc in validatedNames)
                {
                    Assert.Contains(suc, results);
                }

                // Check if validated students have been deleted
                exe.ScriptReader("use itiSchoolDB SELECT * from Student", connection, "Name").Count().Should().Be(sizeTable);
            }
        }

        [TestCase(new string[] { "Monique Monrade", "Damien Gidon" }, 1, new string[] { "Thibault Cam" }, 10)]
        [TestCase(new string[] { "Monique Monrade" }, 2, new string[] { "Thibault Cam", "Damien Gidon" }, 9)]
        [TestCase(new string[] { "Thibault Cam", "Damien Gidon" }, 0, new string[] { }, 11)]
        [TestCase(new string[] { }, 2, new string[] { "Thibault Cam", "Damien Gidon" }, 9)]
        public void T4_Call_UpStudent_Programmatically(string[] redoublants, int nbValidated, string[] validatedNames, int sizeTable)
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetDbConnectionString()))
            {
                connection.Open();

                ResetTable(connection);

                var results = DbStoredProcedures.UpStudent(redoublants, connection).ToList();
                results.Count.Should().Be(nbValidated);
                foreach (string suc in validatedNames)
                {
                    Assert.Contains(suc, results);
                }

                // Check if validated students have been deleted
                ScriptExecutor exe = new ScriptExecutor();
                exe.ScriptReader("use itiSchoolDB SELECT * from Student", connection, "Name").Count().Should().Be(sizeTable);
            }
        }

        #region private methode
        void ResetTable(SqlConnection connection)
        {
            ScriptExecutor exe = new ScriptExecutor();

            int t = (int)new SqlCommand(@"use itiSchoolDB SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('Student')", connection).ExecuteScalar();
            if (t > 0) new SqlCommand("DROP TABLE Student", connection).ExecuteScalar();

            exe.ScriptExe(DbInit.CreateTableStudent(), connection);
            exe.ScriptExe(DbInsert.InsertStudentTable(), connection);
        }
        #endregion
    }
}
