using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StudentService.Interface
{
    public interface IStudent
    {
        void AddStudent(string id, Student student);
        void DisplayAllStudents();
    }
}
