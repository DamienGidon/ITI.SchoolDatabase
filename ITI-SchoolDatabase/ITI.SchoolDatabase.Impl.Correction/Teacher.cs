using ITI.SchoolDatabase.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public class Teacher : ITeacher
    {
        public Teacher(string name, string course, string orientation, DateTime birth, bool Isinternal)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(orientation) || string.IsNullOrEmpty(course))
                throw new ArgumentNullException();

            Name = name;
            Birth = birth;
            Guid = Guid.NewGuid();
            Course = course;
            Orentation = orientation;
            IsInternal = Isinternal;
        }

        public Guid Guid { get; }

        public string Name { get; }

        public DateTime Birth { get; }

        public bool IsInternal { get; }
        public string Course { get; }
        public string Orentation { get; }
    }
}
