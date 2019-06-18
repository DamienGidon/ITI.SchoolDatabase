using ITI.SchoolDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.SchoolDatabase.Impl
{
    public class Student : IStudent
    {
        readonly int _semestre;
        readonly string _orientation;
        ITeacher _teacher;
        public Student(string name, DateTime birth, int semestre, string orientation = null)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            Name = name;
            Birth = birth;
            Guid = Guid.NewGuid();
            _semestre = semestre;
            _orientation = orientation;
        }
        public Guid Guid { get; }

        public string Name { get; }

        public DateTime Birth { get; }

        public int Semestre { get => _semestre; set => throw new NotImplementedException(); }

        public string Orentation { get => _orientation; set => throw new NotImplementedException(); }

        public ITeacher MainTeacher { get => _teacher; set => _teacher = value; }

        public ITeacher AddTeacher(ITeacher teacher)
        {
            if (teacher is null)
                throw new ArgumentNullException();
            return MainTeacher = teacher;
        }
    }
}
