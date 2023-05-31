using CourseManagamentApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentApp.Services.Interfaces
{
    public interface IStudentService
    {

        Student Create(Student stu);
        //Student Update(int id, Student stu);
        void Delete(int id);
        Student GetById(int id);
        List<Student> GetAll();
        }
    
}
