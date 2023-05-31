using CourseManagamentApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourseManagamentApp.Domain.Entities
{
    public class Student:BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string GroupNo { get; set; }
        static int _id = 1;
        public Student(string fullName,int age)
        {
            Id = _id++;
            FullName = fullName;
            Age = age;  

        }
    }
}
