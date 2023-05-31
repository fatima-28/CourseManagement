using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagamentApp.Domain.Common;
using CourseManagamentApp.Helper;


namespace CourseManagamentApp.Domain.Entities
{
    public class Group:BaseEntity
    {
         
        public string GroupNum { get; set; }
        public Category Category { get; set; }
        public int Capacity { get; set; }
        public List<Student> students { get; set; }
        static int _id=1;

        public Group(Category category,int capacity)
        {
            Id = _id++;
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
            Capacity = capacity;
           


        }
    //    public void AddStu(Student student)
    //    {

    //        if (students.Count < Capacity)
    //        {
    //            students.Add(student);
    //        }
    //        else
    //        {
    //            Console.WriteLine("Student capacity is full!");
    //            return;
    //        }
    //        if (student.GroupNo == default)
    //        {
    //            student.GroupNo = GroupNum;
    //        }
    //        else
    //        {
    //            throw new Exception("This student belong to other group!");
    //        }

    //    }
    }
}
