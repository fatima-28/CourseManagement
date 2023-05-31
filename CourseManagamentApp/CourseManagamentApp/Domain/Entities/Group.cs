using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagamentApp.Helper;

namespace CourseManagamentApp.Domain.Entities
{
    public class Group
    {
        public string GroupNum;
        public bool Status;
        public Category Category;
        public int Capacity;
        public List<Student> students;
        public static List<Group> groups = new List<Group>() { };

        public Group(Category category, bool status)
        {
            if (category==Category.Programming)
            {
                GroupNum = $"PR{StaticGroupNums.PR++}";
               
            }
            else if (category == Category.Network)
            {
                GroupNum = $"PR{StaticGroupNums.NW++}";
            }
            else if (category == Category.System)
            {
                GroupNum = $"PR{StaticGroupNums.SY++}";
            }
            else if (category == Category.CyberSecurity)
            {
                GroupNum = $"PR{StaticGroupNums.CB++}";
            }
            else if (category == Category.Design)
            {
                GroupNum = $"PR{StaticGroupNums.DG++}";
            }
            else if (category == Category.Marketing)
            {
                GroupNum = $"PR{StaticGroupNums.MA++}";
            }
            else
            {
                Console.WriteLine("This group name is not exist!");
             
            }
            Category = category;
            if (status == true )
            {
                Status = status;
                Capacity = 15;
                students = new List<Student>(Capacity);
            }
            else if(status == false)
            {
                Status = status;
                Capacity = 10;
                students = new List<Student>(Capacity);
            }
            else
            {
                Console.WriteLine("Status only can be true or false!");
                return;
            }
        }
    }
}
