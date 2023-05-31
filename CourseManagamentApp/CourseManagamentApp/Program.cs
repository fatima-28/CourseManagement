
using CourseManagamentApp.Controllers;
using CourseManagamentApp.Helper;

try
{
    bool checker = true;
    GroupController group = new();
    StudentController stu = new();
    while (checker)
    {

        ConsoleColor.White.WriteConsole("***1.Create Student");
        ConsoleColor.White.WriteConsole("***2.Show all Students");
        ConsoleColor.White.WriteConsole("***3.Create Group");
        ConsoleColor.White.WriteConsole("***4.Show all Groups");
        ConsoleColor.White.WriteConsole("5.Get Student by Group Id");
        ConsoleColor.White.WriteConsole("***6.Delete Group");
        ConsoleColor.White.WriteConsole("***7.Delete Student");
        ConsoleColor.White.WriteConsole("***8.Get Group By Id");
        ConsoleColor.White.WriteConsole("***0.Stop ");

        ConsoleColor.Yellow.WriteConsole("Choose option:");
    Option: string option = Console.ReadLine();

        int selectedOption;

        bool isParseOption = int.TryParse(option, out selectedOption);



        if (isParseOption)
        {
            switch (selectedOption)
            {
                case 1:
                    stu.Create();
                    break;
                case 2:
                    stu.GetAllStu();
                    break;
                case 3:
                    group.Create();
                    break;
                case 4:
                    group.GetAllGroups();
                    break;
                case 5:
                    stu.GetByGroupId();
                    break;
                case 6:
                    group.Delete();
                    break;
                case 7:
                    stu.Delete();
                    break;
                case 8:
                    group.GetById();
                    break;
                case 0:
                    return;
                default:
                    ConsoleColor.Red.WriteConsole("This option is not exist! Pls try again! ");
                    break;
            }


        }
        else
        {
            ConsoleColor.Red.WriteConsole("Please select correct option!");
            goto Option;
        }
    }

}
catch (Exception ex)
{

    ConsoleColor.Red.WriteConsole($"{ex.Message}");
}