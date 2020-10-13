using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static StartProject startProject = new StartProject();
        static public int ViewMenu(string[] menuText)
        {
            Console.Clear();
            foreach (var text in menuText)
                Console.Write(text);
            int chek = startProject.CheckerMenu(menuText.Length);
            Console.Clear();
            return chek;
        }
        static void Main(string[] args)
        {
            Console.WindowHeight = 40;

            string centerText = "=============================================================\n " +
                                        "Добро пожаловать в InfoStudent\n" +
                              "=============================================================";
            
            startProject.Screensaver(centerText);
            Thread.Sleep(2000);
            Console.Clear();
            string[] menuText = { "Menu\n", "  1)Добавить студента\n", "  2)Посмотреть всех студентов\n", "  3)Изменить данные студента\n", "  4)Удалить студента\n", "  5)Выйти\n" };
            InfoStudents infoStudents = new InfoStudents();
            while (true)
            {
                
                int chek = ViewMenu(menuText);

                switch (chek)
                {
                    case 1:
                        infoStudents.AddStudent();
                        break;
                    case 2:
                        infoStudents.ViewStudent();
                        break;
                    case 3:
                        infoStudents.UpdateStudent(infoStudents.ChoiceStudent());
                        break;
                    case 4:
                        infoStudents.DeleteStudent(infoStudents.ChoiceStudent());
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                }
            }
            
        }
    }
}

