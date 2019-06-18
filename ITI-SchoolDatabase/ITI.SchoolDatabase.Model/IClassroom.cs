using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Model
{
    public interface IClassroom
    {
        Guid Guid { get; }

        string Name { get; }

        int Capacity { get; }

        bool Projector { get; }

    }
}
