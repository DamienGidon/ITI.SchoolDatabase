using ITI.SchoolDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public static class SchoolFactory
    {
        public static IStudent CreateStudent(string name, int semestre, DateTime birth, string orientation = null)
        {
           return new Student(name,birth,semestre,orientation);
        }

        public static ITeacher CreateTeacher(string name, string course, string orientation, DateTime birth, bool Isinternal)
        {
            return new Teacher(name, course, orientation, birth, Isinternal);
        }

        public static IClassroom CreateClassroom(string name, int capacity, bool projector)
        {
            return new Classroom(name, capacity, projector);
        }
    }
}
