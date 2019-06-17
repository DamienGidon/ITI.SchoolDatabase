using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Model
{
    public interface IView
    {
        string StudentName { get; }

        int Semestre { get; }

        string Orientation { get; }

        string TeacherName { get; }

        string RoomName { get; }
    }
}
