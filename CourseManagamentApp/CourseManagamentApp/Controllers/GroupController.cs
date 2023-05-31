using CourseManagamentApp.Domain.Entities;
using CourseManagamentApp.Helper;
using CourseManagamentApp.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentApp.Controllers
{
    public class GroupController
    {
        private readonly GroupService _groupService;

        public GroupController()
        {
            _groupService = new GroupService();
        }
        public void Create()
        {

            ConsoleColor.Yellow.WriteConsole("Choose Category:\n");
            ConsoleColor.Green.WriteConsole("1.Programming");
            ConsoleColor.Green.WriteConsole("2.Marketing");
            ConsoleColor.Green.WriteConsole("3.Design");
            ConsoleColor.Green.WriteConsole("4.Network");
            ConsoleColor.Green.WriteConsole("5.System");
            ConsoleColor.Green.WriteConsole("6.Cyber Security");
           
       
            Console.WriteLine("Choose options:");
            Category category = (Category)int.Parse(Console.ReadLine());
             if ((int)category < 0 || (int)category > 6)
            {

                ConsoleColor.Red.WriteConsole("This category is not exist");
                return;
            }
            ConsoleColor.Yellow.WriteConsole("Add Capacity:\n");
            Cap: int capacity = int.Parse(Console.ReadLine());
            if (capacity<10)
            {
                ConsoleColor.Red.WriteConsole("Group's minumum capacity is 10! Try again");
                goto Cap;
            }
            Group group = new Group(category, capacity);
            var res = _groupService.Create(group);
         
        } 
        public void GetAllGroups()
        {
            var res = _groupService.GetAll();
            foreach (var item in res)
            {
                ConsoleColor.Green.WriteConsole($"Id:{item.Id} Group:{item.GroupNum} Capacity:{item.Capacity}");
            }
        }
        public void Delete()
        {
            try
            {
                ConsoleColor.Green.WriteConsole($"Current groups in database:");
                GetAllGroups();
                if ( _groupService.GetAll().Count==0)
                {
                    ConsoleColor.Red.WriteConsole($"Database is empty!");
                    return;
                }
                ConsoleColor.Yellow.WriteConsole($"Choose which you want to delete:");
                int id = int.Parse(Console.ReadLine());

                _groupService.Delete(id);
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole($"Error occured!Try again");
                return;
            }
        }
        public void GetById()
        {
            try
            {
                ConsoleColor.Yellow.WriteConsole("Add group id:");
               idChoice: string GrId = Console.ReadLine();
                int newGrId;
                bool isParse = int.TryParse(GrId, out newGrId);

                if (isParse)
                {
                    var result = _groupService.GetById(newGrId);
                    if (result is null)
                    {
                        ConsoleColor.Red.WriteConsole("Group can't be found: ");
                        goto idChoice;
                    }
                    ConsoleColor.Green.WriteConsole($"{result.Id} {result.GroupNum} {result.Capacity}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please, enter correct id: ");
                    goto idChoice;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
