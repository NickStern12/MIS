using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class InfoStudents
    {
        
        public string[,] student = new string[5, 8];//Матрица которая хранит информацию о студенте (1 строка = 1 студент)
                                                    //Столбцы отвечают за хранящийся данные (Фамилия,Имя,Отчетство,Возраст,Год рождения,Математика,Русский язык,Информатика)
        public string[] columsInfo = { "Фамилия", "Имя", "Отчетство", "Возраст", "Год рождения", "Математика", "Русский язык", "Информатика" };
        public int checkViewInfo;
        public bool checkValuesFIO(string check, string colums)
        {
            bool Validation = true;
            if (check == null && colums != "Отчество")
            {
                Console.WriteLine($"Ошибка! Необходимо ввести {colums}");
                Validation = false;
            }
            else if (Regex.IsMatch(check, @"^[0-9]+$"))
            {
                Console.WriteLine($"Ошибка! В {colums} не должно быть цифр");
                Validation = false;
            }
            return Validation;
        } //Проверка на правильность ввода ФИО

        public bool checkValuesNumbers(string check, string colums)
        {
            bool Validation = true;
            if (Regex.IsMatch(check, @"^[a-zA-Zа-яА-Я]+$"))//Проверка на буквы
            {
                Console.WriteLine($"Ошибка! {colums} не должно содержать буквы");
                Validation = false;
            }
            else if (check == null)
            {
                Console.WriteLine($"Ошибка! Заполните {colums}");
                Validation = false;
            }
            return Validation;
        } //Проверка на правильность ввода цифр

        public void AddStudent()//Добавление студента
        {
            for (int i = 0; i < student.GetLength(0); i++)
            {
                if (student[i, 0] != null) //Проверка на наличия свободной ячейке в БД
                {
                    if (i == student.Length - 1)
                    {
                        Console.WriteLine("База данных переполнина.");
                        break;
                    }
                    else
                        continue;
                }
                else 
                {
                    familia:
                    Console.Write("Фамилия: ");
                    student[i, 0] = Console.ReadLine();
                    if (checkValuesFIO(student[i, 0], "Фамилия") == false)
                        goto familia;
                    name:
                    Console.Write("Имя: ");
                    student[i, 1] = Console.ReadLine();
                    if (checkValuesFIO(student[i, 1], "Имя") == false)
                        goto name;
                    otchestvo:
                    Console.Write("Отчество: ");
                    student[i, 2] = Console.ReadLine();
                    if (checkValuesFIO(student[i, 2], "Отчество") == false)
                        goto otchestvo;
                    year_birth:
                    Console.Write("Год рождения: ");
                    student[i, 4] = Console.ReadLine();
                    if (checkValuesNumbers(student[i, 4], "Год рождения") == false)
                        goto year_birth;
                    student[i, 3] = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(student[i, 4])); //Считаем возраст
                    Console.WriteLine("Оценки: ");
                    for (int index = 5; index < 8; index++)
                    {
                        Assessment:
                        Console.Write($"{columsInfo[index]} -  ");
                        student[i, index] = Console.ReadLine();
                        if (checkValuesNumbers(student[i, 4], columsInfo[index]) == false)
                            goto Assessment;
                    }
                    break;

                }
                
            }
            Console.WriteLine("Студент добавлен");
            Thread.Sleep(1000);
        }

        public void ViewStudent()//Вывод всех студентов
        {
            Console.WriteLine("  Информация о студентах:");
            checkViewInfo = 0;
            int j = 0;
            for (int i = 0; i < student.GetLength(0); i++)
            {
                j = 0;
                if (student[i, j] != null)//Проверка на наличия студента
                {
                    Console.Write($"  {i + 1}) ");
                    for (j = 0; j < student.GetLength(1); j++)
                    {
                        Console.Write($"{student[i, j]} ");
                    }
                    Console.WriteLine();
                    checkViewInfo++;
                }
                else
                {
                    break;
                }
            }
            Console.ReadKey();
        }

        public int  ChoiceStudent() //Выбор студента для удаления или изменения
        {
            StartProject startProject = new StartProject();
            int check = -1;
            if (checkViewInfo > 0)
            {
                ViewStudent();
                check = startProject.CheckerMenu(checkViewInfo);
            }
            else
                Console.WriteLine("База данных не заполнина");
            return check;
        }

        public void UpdateStudent(int i)
        {
            Console.Clear();
            if (i != -1)
            {
                familia:
                Console.Write("Фамилия: ");
                student[i, 0] = Console.ReadLine();
                if (checkValuesFIO(student[i, 0], "Фамилия") == false)
                    goto familia;
                name:
                Console.Write("Имя: ");
                student[i, 1] = Console.ReadLine();
                if (checkValuesFIO(student[i, 1], "Имя") == false)
                    goto name;
                otchestvo:
                Console.Write("Отчество: ");
                student[i, 2] = Console.ReadLine();
                if (checkValuesFIO(student[i, 2], "Отчество") == false)
                    goto otchestvo;
                year_birth:
                Console.Write("Год рождения: ");
                student[i, 4] = Console.ReadLine();
                if (checkValuesNumbers(student[i, 4], "Год рождения") == false)
                    goto year_birth;
                student[i, 3] = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(student[i, 4])); //Считаем возраст
                Console.WriteLine("Оценки: ");
                for (int index = 5; index < 8; index++)
                {
                    Assessment:
                    Console.Write($"{columsInfo[index]} -  ");
                    student[i, index] = Console.ReadLine();
                    if (checkValuesNumbers(student[i, 4], columsInfo[index]) == false)
                        goto Assessment;
                }
                Console.WriteLine("Студент изменен");
                Thread.Sleep(1000);
            }
            else
                Console.WriteLine("В БД отсутствуют данные.");
            Console.ReadKey();
        }

        public void DeleteStudent(int i)
        {
            Console.Clear();
            if (i != -1)
            {
                for (int j = 0; j < student.GetLength(1); j++)
                    student[i, j] = null;
                Console.WriteLine("Студент удален");
                Thread.Sleep(1000);
            }
            else
                Console.WriteLine("В БД отсутствуют данные.");
            Console.ReadKey();
        }
    }
}
