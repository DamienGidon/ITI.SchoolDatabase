using ITI.SchoolDatabase.Model;
using NUnit.Framework;
using System;
using FluentAssertions;
using ITI.SchoolDatabase.Impl;

namespace ITI.SchoolDatabase.Tests
{
    [TestFixture]
    public class T1ObjectLifeCycle
    {
        [Test]
        public void T1_creating_student()
        {
            Action action = (() => SchoolFactory.CreateStudent(null, 0, DateTime.Now, "IL"));
            action.Should().Throw<ArgumentNullException>();

            Action action1 = (() => SchoolFactory.CreateStudent(String.Empty, 0, DateTime.Now, String.Empty));
            action1.Should().Throw<ArgumentNullException>();

            {
                IStudent s = SchoolFactory.CreateStudent("Thibault Cam", 9, DateTime.Parse("21/02/1994"), "IL");
                s.Name.Should().Be("Thibault Cam");
                s.Semestre.Should().Be(9);
                s.Orentation.Should().Be("IL");
                s.Guid.Should().NotBeEmpty();
                s.Birth.Should().BeSameDateAs(DateTime.Parse("21/02/1994"));
            }
        }
        
        [Test]
        public void T2_creating_teacher()
        {
            Action action = (() => SchoolFactory.CreateTeacher(null, null, null, DateTime.Now, false));
            action.Should().Throw<ArgumentNullException>();

            Action action1 = (() => SchoolFactory.CreateTeacher(String.Empty, String.Empty, String.Empty, DateTime.Now, false));
            action1.Should().Throw<ArgumentNullException>();

            {
                ITeacher s = SchoolFactory.CreateTeacher("Olivier Spineli", "C#", "IL", DateTime.Parse("21/02/1994"), true);
                s.Name.Should().Be("Olivier Spineli");
                s.Course.Should().Be("C#");
                s.Orentation.Should().Be("IL");
                s.Guid.Should().NotBeEmpty();
                s.Birth.Should().BeSameDateAs(DateTime.Parse("21/02/1994"));
            }
        }

        [TestCase(null, false)]
        [TestCase("E07", true)]
        [TestCase("E", false)]
        [TestCase("E0", false)]
        [TestCase("", false)]
        [TestCase("E076", false)]
        public void T3_creating_classroom_with_valid_name( string name, bool success )
        {
            Action action = (() => SchoolFactory.CreateClassroom(name, 1,false));
            if (success) action.Should().NotThrow();
            else action.Should().Throw<ArgumentException>();


            {
                IClassroom s = SchoolFactory.CreateClassroom("E07", 10, true);
                s.Guid.Should().NotBeEmpty();
                s.Name.Length.Should().BeLessOrEqualTo(3);
                s.Projector.Should().BeTrue();
                s.Capacity.Should().BeGreaterThan(0);
            }
        }

        [TestCase(null, false)]
        [TestCase(0, false)]
        [TestCase(10, true)]
        [TestCase(-12, false)]
        public void T4_creating_classroom_with_valid_capacity(int capacity, bool success)
        {
            Action action = (() => SchoolFactory.CreateClassroom("E07", capacity, true));
            if (success) action.Should().NotThrow();
            else action.Should().Throw<ArgumentException>();

            {
                IClassroom s = SchoolFactory.CreateClassroom("E07", 10, true);
                s.Guid.Should().NotBeEmpty();
                s.Projector.Should().BeTrue();
                s.Name.Length.Should().BeLessOrEqualTo(3);
                s.Capacity.Should().BeGreaterThan(0);
            }
        }

        [Test]
        public void T5_adding_teacher_to_student()
        {
            
            IStudent s = SchoolFactory.CreateStudent("Thibault Cam", 9, DateTime.Parse("21/02/1994"), "IL");
            ITeacher t = SchoolFactory.CreateTeacher("Olivier Spineli", "C#", "IL", DateTime.Parse("21/02/1994"), true);

            Action action = (() => s.AddTeacher(null));
            action.Should().Throw<ArgumentNullException>();

            s.AddTeacher(t);
            s.MainTeacher.Should().NotBeNull();
            s.MainTeacher.Should().BeEquivalentTo(t);
        }

    }
}
