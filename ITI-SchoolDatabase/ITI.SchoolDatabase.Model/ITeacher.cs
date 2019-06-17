using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Model
{
    public interface ITeacher
    {
        Guid Guid { get; }

        string Name { get; }

        DateTime Birth { get; }

        string Course { get; set; }

        string Orentation { get; set; }

        bool IsInternal { get; set;  }

        IClassroom Classroom { get; set; }

        IClassroom AddClassroom(IClassroom classroom);
    }
}
