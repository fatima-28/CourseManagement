using CourseManagamentApp.Domain.Entities;
using CourseManagamentApp.Repository.DAL;
using CourseManagamentApp.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentApp.Repository.Repositories.Implementations
{

    public class StudentRepository : IRepository<Student>
    {
        public void Add(Student entity)
        {
            if (entity == null) throw new ArgumentNullException();
            AppDbContext<Student>.datas.Add(entity);
        }

        public void Delete(Student entity)
        {
            if (entity == null) throw new ArgumentNullException();
            AppDbContext<Student>.datas.Remove(entity);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return AppDbContext<Student>.datas.Find(predicate);
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return AppDbContext<Student>.datas.FindAll(predicate);
        }

      
    }


}
