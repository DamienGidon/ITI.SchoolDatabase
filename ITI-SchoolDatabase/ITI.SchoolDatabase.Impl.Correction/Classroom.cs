using ITI.SchoolDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public class Classroom : IClassroom
    {
        public Classroom(string name, int capacity, bool projector)
        {
            if (string.IsNullOrEmpty(name) || capacity <= 0 || name.Length != 3)
                throw new ArgumentException();
            Guid = Guid.NewGuid();
            Name = name;
            Capacity = capacity;
            Projector = projector;
        }
        public Guid Guid { get; }

        public string Name { get; }

        public int Capacity { get; }

        public bool Projector { get; }
    }
}
