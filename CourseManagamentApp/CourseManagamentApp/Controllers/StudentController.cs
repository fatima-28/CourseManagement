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
           

            ConsoleColor.Yellow.WriteConsole("Add Students Age:");
             int age = int.Parse(Console.ReadLine());
            if (age < 14) {
                ConsoleColor.Red.WriteConsole("Student's age have to more than 14!");
                return;
            }
            Student stu = new Student(fullName,age);

            AddStuToGroup(stu);
            if (_groupService.GetAll().Count > 0) _stuService.Create(stu);
            
            
           
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
            try
            {
                ConsoleColor.DarkGray.WriteConsole("Current groups in database:");

                for (int i = 0; i < _groupService.GetAll().Count; i++)
                {
                    ConsoleColor.Yellow.WriteConsole($"\n{_groupService.GetAll()[i].Id}.{_groupService.GetAll()[i].GroupNum}\n");
                }
                ConsoleColor.Yellow.WriteConsole("Select one of them:");
               Id: int groupId = int.Parse(Console.ReadLine());
                var group = _groupService.GetById(groupId);
               
                if (group is null)
                {
                    ConsoleColor.Red.WriteConsole("Group can't be found: ");
                    goto Id;
                }
                else
                {
                    for (int i = 0; i < group.students.Count; i++)
                    {
                        ConsoleColor.Green.WriteConsole($"Id: {group.students[i].Id} FullName: {group.students[i].FullName} Age: {group.students[i].Age}");
                    }
                }

            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
                return;
               


            }
        }
        public  void AddStuToGroup(Student student) {
            
            if (_groupService.GetAll().Count > 0)
            {

                ConsoleColor.Yellow.WriteConsole("Groups in Database:");
                for (int i = 0; i < _groupService.GetAll().Count; i++)
                {
                    ConsoleColor.Yellow.WriteConsole($"\n{i + 1}.{_groupService.GetAll()[i].GroupNum}\n");
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
