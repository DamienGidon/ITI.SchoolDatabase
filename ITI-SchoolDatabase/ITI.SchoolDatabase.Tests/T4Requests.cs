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
    public class T4Requests
    {
        string[] StudentScripts;
        string[] TeacherScripts;
        string[] ClassroomScripts;

        [SetUp]
        public void Setup()
        {
            StudentScripts = File.ReadAllText(DbRequest.StudentRequests()).Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            TeacherScripts = File.ReadAllText(DbRequest.TeacherRequests()).Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            ClassroomScripts = File.ReadAllText(DbRequest.ClassroomRequests()).Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
        }

        [Test]
        public void T1_Find_All_Student_Whose_Teacher_Is_Born_In_1973_11_17()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();

                List<string> response = exe.ScriptReader(StudentScripts[0], connection, "Name").ToList();

                Assert.AreEqual(response.Count, 3);
                Assert.Contains("Damien Gidon", response);
                Assert.Contains("Vin Diesel", response);
                Assert.Contains("Thibault Cam", response);
            }
        }

        [Test]
        public void T2_Return_Classroom_Where_You_Can_Find_Student_Whose_Name_Starts_With_Thibau_When_They_Are_With_Their_MainTeacher()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();

                List<string> response = exe.ScriptReader(ClassroomScripts[1], connection, "Name").ToList();

                Assert.AreEqual(response.Count, 2);
                Assert.Contains("E07", response);
                Assert.Contains("E03", response);
            }
        }

        [Test]
        public void T3_Return_Teachers_Courses_Who_Have_At_Least_One_Student()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();

                List<string> response = exe.ScriptReader(TeacherScripts[0], connection, "Course").ToList();

                Assert.AreEqual(response.Count, 5);
                Assert.Contains("Programmation", response);
                Assert.Contains("Ex-Dirlo <3", response);
                Assert.Contains("PFH", response);
                Assert.Contains("Programmation", response);
                Assert.Contains("Antiquaire", response);
            }
        }

        [Test]
        public void T4_Return_Classroom_Name_Alphabeticaly_With_An_IL_Teacher_And_A_Projector()
        {
            using (SqlConnection connection = new SqlConnection(DbInit.GetConnectionString()))
            {
                connection.Open();

                ScriptExecutor exe = new ScriptExecutor();

                List<string> response = exe.ScriptReader(ClassroomScripts[0], connection, "Name").ToList();

                response.Count().Should().Be(3);
                Assert.AreEqual("E01", response[0]);
                Assert.AreEqual("E02", response[1]);
                Assert.AreEqual("E07", response[2]);
            }
        }
    }
}
