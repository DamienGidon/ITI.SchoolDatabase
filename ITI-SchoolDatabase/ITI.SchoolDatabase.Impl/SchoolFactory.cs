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
			throw new NotImplementedException();
        }

        public static ITeacher CreateTeacher(string name, string course, string orientation, DateTime birth, bool Isinternal)
        {
			throw new NotImplementedException();
		}

		public static IClassroom CreateClassroom(string name, int capacity, bool projector)
        {
			throw new NotImplementedException();
		}
	}
}
