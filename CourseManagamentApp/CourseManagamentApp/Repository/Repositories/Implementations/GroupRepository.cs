using CourseManagamentApp.Domain.Entities;
using CourseManagamentApp.Repository.DAL;
using CourseManagamentApp.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = CourseManagamentApp.Domain.Entities.Group;

namespace CourseManagamentApp.Repository.Repositories.Implementations
{
    public class GroupRepository : IRepository<Group>
    {
        public void Add(Group entity)
        {
            if (entity == null) throw new ArgumentNullException();
            AppDbContext<Group>.datas.Add(entity);
        }
      

        public void Delete(Group entity)
        {
            if (entity == null) throw new ArgumentNullException();
            AppDbContext<Group>.datas.Remove(entity);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return AppDbContext<Group>.datas.Find(predicate);
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            return AppDbContext<Group>.datas.FindAll(predicate);
        }

     

    }
}
