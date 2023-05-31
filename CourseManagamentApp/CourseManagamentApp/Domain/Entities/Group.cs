using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CourseManagamentApp.Domain.Common;
using CourseManagamentApp.Helper;


namespace CourseManagamentApp.Domain.Entities
{
    public class Group:BaseEntity
    {
         
        public string GroupNum { get; set; }
        public Category Category { get; set; }
        public int Capacity { get; set; }
        public List<Student> students;
        static int _id=1;

        public Group(Category category,int capacity)
        {
            students=new List<Student>();
             Id = _id++;
            if (category==Category.Programming)
            {
                GroupNum = $"PR{StaticGroupNums.PR++}";
               
            }
            else if (category == Category.Marketing)
            {
                GroupNum = $"MA{StaticGroupNums.MA++}";
            }
            else if (category == Category.Design)
            {
                GroupNum = $"DG{StaticGroupNums.DG++}";
            }
            else if (category == Category.Network)
            {
                GroupNum = $"NW{StaticGroupNums.NW++}";
            }
            else if (category == Category.System)
            {
                GroupNum = $"SY{StaticGroupNums.SY++}";
            }
            else if (category == Category.CyberSecurity)
            {
                GroupNum = $"CB{StaticGroupNums.CB++}";
            }
            else
            {
                Console.WriteLine("This group name is not exist!");
             
            }
            Category = category;
            Capacity = capacity;
           


        }
        public void AddStudent(Student student)
        {

            if (students.Count < Capacity)
            {
                students.Add(student);
            }
            else
            {
               ConsoleColor.Red.WriteConsole("Student capacity is full");
                return;
            }
            if (student.GroupNo == default)
            {
                student.GroupNo = GroupNum;
            }
            else
            {
                throw new Exception("This student belong to other group");
            }

        }

    }
}
