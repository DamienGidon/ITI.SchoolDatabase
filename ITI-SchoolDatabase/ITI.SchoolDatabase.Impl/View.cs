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
			StudentName = studentName;
			Semestre = semestre;
			Orientation = orientation;
			TeacherName = teacherName;
			RoomName = roomName;
		}

		public string StudentName { get; }

		public int Semestre { get; }

		public string Orientation { get; }

		public string TeacherName { get; }

		public string RoomName { get; }
	}
}
