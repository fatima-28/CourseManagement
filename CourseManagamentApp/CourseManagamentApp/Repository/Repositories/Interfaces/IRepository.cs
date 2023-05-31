using CourseManagamentApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentApp.Repository.Repositories.Interfaces
{
    public interface IRepository<T> 
    {
        void Add(T entity);
        void Delete(T entity);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);

        //void Update(T entity);
    }
}
