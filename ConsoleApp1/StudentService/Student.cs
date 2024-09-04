using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StudentService
{
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }
    }
}
