using CourseManagamentApp.Domain.Entities;
using CourseManagamentApp.Repository.Repositories.Implementations;
using CourseManagamentApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentApp.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _repo;


        public StudentService()
        {
            _repo = new StudentRepository();
        }
        public Student Create(Student stu)
        {
           
            _repo.Add(stu);   
            return stu;
        }

        public void Delete(int id)
        {
            var stu = _repo.Get(m => m.Id == id);
            _repo.Delete(stu);
        }

        public List<Student> GetAll()
        {
            return _repo.GetAll(m => m.Id >= 0);
        }

        public Student GetById(int id)
        {
            if (id == null) throw new ArgumentNullException();
            return _repo.Get(m => m.Id == id);
        }

     
    }
}
