using CourseManagamentApp.Domain.Entities;
using CourseManagamentApp.Helper;
using CourseManagamentApp.Services.Implementations;
using CourseManagamentApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentApp.Controllers
{
    public class StudentController
    {
        private readonly StudentService _stuService;
        private readonly  GroupService _groupService;

        public StudentController()
        {
            _stuService = new StudentService();
            _groupService = new GroupService();
        }
        public void Create()
        {
            ConsoleColor.Yellow.WriteConsole("Add Students Fullname");
            string fullName = Console.ReadLine().Trim();
            if (fullName.Trim()==string.Empty)
            {

                ConsoleColor.Red.WriteConsole("Student's fullname can not be null!");
                return;
            }
            List<Student> stuList = _stuService.GetAll();

            ConsoleColor.Yellow.WriteConsole("Add Students Age:");
             int age = int.Parse(Console.ReadLine());
            if (age < 14) {
                ConsoleColor.Red.WriteConsole("Student's age have to more than 14!");
                return;
            }
            Student stu = new Student(fullName,age);
            stuList.Add(stu);

            AddStuToGroup(stu);
        }
        public void GetAllStu()
        {

        }
        public void Delete()
        {

        } 
        public void GetByGroup()
        {

        }
        public  void AddStuToGroup(Student student) {
            
            if (_groupService.GetAll().Count > 0)
            {
               
                Console.WriteLine("Groups in Dtabase:");
                for (int i = 0; i < _groupService.GetAll().Count; i++)
                {
                    Console.WriteLine($"\n{i + 1}.{_groupService.GetAll()[i].GroupNum}\n");
                }

                ConsoleColor.Yellow.WriteConsole("Write group name where you want to add:");
                string groupInput = Console.ReadLine();
                bool check = false;

                for (int i = 0; i < _groupService.GetAll().Count; i++)
                {
                    if (groupInput == _groupService.GetAll()[i].GroupNum)
                    {
                        _groupService.GetAll()[i].AddStudent(student);

                        ConsoleColor.Green.WriteConsole($"Student added {_groupService.GetAll()[i].GroupNum} group.");
                        check = true;
                    }
                }
                if (!check)
                {

                    ConsoleColor.Red.WriteConsole("We have not such group name in database!");
                }
            }
            else
            {

                ConsoleColor.Red.WriteConsole("There is no any group in database!");
                return;
            }
        }

    }
}
