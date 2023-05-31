using CourseManagamentApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentApp.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        //Group Update(int id, Group group);
        void Delete(int id);
        Group GetById(int id);
        Group GetByName(string name);
        List<Group> GetAll();
    }
}
