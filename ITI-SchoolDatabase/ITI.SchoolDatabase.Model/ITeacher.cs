using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        string Course { get;}

        string Orentation { get; }

        bool IsInternal { get;}

    }
}
