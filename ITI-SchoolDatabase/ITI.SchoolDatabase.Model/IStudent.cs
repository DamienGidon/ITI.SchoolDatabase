using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Model
{
    public interface IStudent
    {
        Guid Guid { get; }

        string Name { get; }

        DateTime Birth { get; }

        int Semestre { get; set; }

        string Orentation { get; set; }

        ITeacher MainTeacher { get; set; }

        ITeacher AddTeacher(ITeacher teacher);
    }
}
