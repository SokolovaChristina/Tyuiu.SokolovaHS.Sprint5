using System;
using Tyuiu.SokolovaHS.Sprint5.Task1.V14.Lib;

namespace Tyuiu.SokolovaHS.Sprint5.Task1.V14
{
    class Program
    {
        static void Main(string[] args)
        {
            int startValue = -5;
            int stopValue = 5;

            Console.Title = "Спринт #5 | Выполнила: Соколова Х. С. | ПКТБ-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Класс File. Запись набора данных в текстовый файл                 *");
            Console.WriteLine("* Задание #1                                                              *");
            Console.WriteLine("* Вариант #14                                                             *");
            Console.WriteLine("* Выполнила: Соколова Христина Сергеевна | ПКТБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дана функция F(x) = sin(x)/(x+1.7) - cos(x)*4x - 6. Произвести          *");
            Console.WriteLine("* табулирование f(x) на диапазоне [-5; 5] с шагом 1.                      *");
            Console.WriteLine("* Произвести проверку деления на ноль. Результат сохранить в текстовый    *");
            Console.WriteLine("* файл OutPutFileTask1.txt и вывести на консоль в таблицу.                *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            Console.WriteLine("startValue = " + startValue);
            Console.WriteLine("stopValue = " + stopValue);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            string res = ds.SaveToFileTextData(startValue, stopValue);

            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Создан!");

            // Вывод таблицы на консоль
            Console.WriteLine();
            Console.WriteLine("Таблица значений функции:");
            Console.WriteLine("-------------------------");
            Console.WriteLine("|    x    |   f(x)    |");
            Console.WriteLine("-------------------------");

            for (int x = startValue; x <= stopValue; x++)
            {
                double value = CalculateFunction(x);
                Console.WriteLine($"| {x,6}  | {value,8:F2}  |");
            }
            Console.WriteLine("-------------------------");
            Console.ReadLine();
        }

        private static double CalculateFunction(int x)
        {
            if (Math.Abs(x + 1.7) < 0.0001)
            {
                return 0;
            }
            double result = Math.Sin(x) / (x + 1.7) - Math.Cos(x) * 4 * x - 6;
            return Math.Round(result, 2);
        }
    }
}
