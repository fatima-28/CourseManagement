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
            //List<Student> stuList = _stuService.GetAll();

            ConsoleColor.Yellow.WriteConsole("Add Students Age:");
             int age = int.Parse(Console.ReadLine());
            if (age < 14) {
                ConsoleColor.Red.WriteConsole("Student's age have to more than 14!");
                return;
            }
            Student stu = new Student(fullName,age);

            AddStuToGroup(stu);
            _stuService.Create(stu);
           
        }
        public void GetAllStu()
        {
            var res = _stuService.GetAll();
            foreach (var item in res)
            {
                ConsoleColor.Green.WriteConsole($"Id:{item.Id} Fullname:{item.FullName} Age:{item.Age} Group:{item.GroupNo}");
            }

        }
        public void Delete()
        {
            try
            {
                ConsoleColor.Green.WriteConsole($"Current students in database:");
                GetAllStu();
                if (_stuService.GetAll().Count == 0)
                {
                    ConsoleColor.Red.WriteConsole($"Database is empty!");
                    return;
                }
                ConsoleColor.Yellow.WriteConsole($"Choose which student you want to delete:");
                int id = int.Parse(Console.ReadLine());

                _stuService.Delete(id);
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole($"Error occured!Try again");
                return;
            }
        } 
        public void GetByGroupId()
        {

        }
        public  void AddStuToGroup(Student student) {
            
            if (_groupService.GetAll().Count > 0)
            {

                ConsoleColor.Yellow.WriteConsole("Groups in Database:");
                for (int i = 0; i < _groupService.GetAll().Count; i++)
                {
                    Console.WriteLine($"\n{i + 1}.{_groupService.GetAll()[i].GroupNum}\n");
                }

                ConsoleColor.Yellow.WriteConsole("Write group name where you want to add:");
               GroupInput: string groupInput = Console.ReadLine();
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

                    ConsoleColor.Red.WriteConsole("We have not such group name in database! Try again!");
                    goto GroupInput;
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
