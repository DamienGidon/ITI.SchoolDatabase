using ITI.SchoolDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
	public class View : IView
	{
		public View(string studentName, int semestre, string orientation, string teacherName, string roomName)
		{

		}

        public string StudentName => throw new NotImplementedException();

        public int Semestre => throw new NotImplementedException();

        public string Orientation => throw new NotImplementedException();

        public string TeacherName => throw new NotImplementedException();

        public string RoomName => throw new NotImplementedException();
    }
}
