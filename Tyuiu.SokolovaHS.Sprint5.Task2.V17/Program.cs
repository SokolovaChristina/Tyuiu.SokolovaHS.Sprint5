using System;
using Tyuiu.SokolovaHS.Sprint5.Task2.V17.Lib;

namespace Tyuiu.SokolovaHS.Sprint5.Task2.V17
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 3] { { 2, 1, 7 }, { 1, 2, 4 }, { 2, 3, 4 } };

            Console.Title = "Спринт #5 | Выполнила: Соколова Х. С. | ПКТБ-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Класс File. Запись структурированных данных в текстовый файл      *");
            Console.WriteLine("* Задание #2                                                              *");
            Console.WriteLine("* Вариант #17                                                             *");
            Console.WriteLine("* Выполнила: Соколова Христина Сергеевна | ПКТБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан двумерный целочисленный массив 3 на 3 элементов. Заменить нечетные  *");
            Console.WriteLine("* элементы массива на 0. Результат сохранить в файл OutPutFileTask2.csv.  *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            Console.WriteLine("Исходный массив:");
            PrintMatrix(matrix);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            string res = ds.SaveToFileTextData(matrix);

            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Создан!");

            // Вывод преобразованного массива
            Console.WriteLine("\nПреобразованный массив (нечетные заменены на 0):");
            PrintTransformedMatrix(matrix);

            // Вывод содержимого файла
            Console.WriteLine("\nСодержимое файла:");
            string fileContent = File.ReadAllText(res);
            Console.WriteLine(fileContent);

            Console.ReadLine();
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        static void PrintTransformedMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int value = matrix[i, j] % 2 != 0 ? 0 : matrix[i, j];
                    Console.Write($"{value,4}");
                }
                Console.WriteLine();
            }
        }
    }
}
