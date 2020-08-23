using System.Collections.Generic;
using StudentRegistration.Models;

namespace StudentRegistration.Repository
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetStudents();

        Student GetStudentById(int id);

        void CreateStudent(Student cmd);

        bool SaveChanges();
    }
}