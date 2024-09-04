using ConsoleApp1.StudentService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StudentService.Implementation
{
    public class StudentService : IStudent
    {
        public Dictionary<string, Student> studentData = new Dictionary<string, Student>();

        // Add Student 
        public void AddStudent(string id, Student student)
        {
            // Check if student already exist in the Dictionary
            if (studentData.ContainsKey(id))
            {
                throw new ArgumentException("Student ID already exists.");
            }

            // Add Student to the Dictionary
            studentData[id] = student;
        }

        // Display all student
        public void DisplayAllStudents()
        {
            foreach (var student in studentData)
            {
                Console.WriteLine($"Student ID: {student.Key}, Name: {student.Value.Name}, Grade: {student.Value.Grade}");
            }
        }
    }
}
