using System;
using System.Collections.Generic;
using System.Linq;
using StudentRegistration.Models;

namespace StudentRegistration.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentContext _context;

        public StudentRepo(StudentContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Students.Add(cmd);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(f=>f.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}