using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StartProject
    {
        public void Screensaver(string centerText)// Заставка
        {
            
            //Разбиваем текст на массив строк
            string[] lines = Regex.Split(centerText, "\r\n|\r|\n");

            //Отступ слева будет определяться для каждой строки отдельно
            int left = 0;
            //Определяем отступ сверху для первой строки
            int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1;

            //Находим центр консоли сразу, чтобы не грузить приложение лишними вычислениями
            //Делайте это стоит на свой страх и риск - если пользователь растянет консоль, весь текст поедет
            int center = Console.WindowWidth / 2;

            for (int i = 0; i < lines.Length; i++)
            {
                //Определяем отступ для текущей строки
                left = center - (lines[i].Length / 2);

                //Меняем положение курсора
                Console.SetCursorPosition(left, top);
                //Выводим строку
                Console.WriteLine(lines[i]);

                //Для каждой новой строки программа будет автоматически считать отступ сверху
                top = Console.CursorTop;
            }
            
        }

        public int CheckerMenu(int count, int startPos = 1, string arrow = "->")//Передвижение по меню с помощью стрелочек
        {
            string empty = new string(' ', arrow.Length);
            int i = startPos;
            Console.SetCursorPosition(0, startPos);
            Console.Write(arrow);
            ConsoleKeyInfo key;
            for (; ; )
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (i == count + startPos - 1)
                            continue;
                        Console.SetCursorPosition(0, i);
                        Console.Write(empty);
                        Console.SetCursorPosition(0, ++i);
                        Console.Write(arrow);
                        break;
                    case ConsoleKey.UpArrow:
                        if (i == startPos)
                            continue;
                        Console.SetCursorPosition(0, i);
                        Console.Write(empty);
                        Console.SetCursorPosition(0, --i);
                        Console.Write(arrow);
                        break;
                    case ConsoleKey.Enter:
                        return i + 1 - startPos;
                }
            }
        }
    }
}
