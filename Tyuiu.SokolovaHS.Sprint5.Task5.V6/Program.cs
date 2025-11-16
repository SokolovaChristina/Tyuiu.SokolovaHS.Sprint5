using System;
using System.IO;
using System.Globalization;
using Tyuiu.SokolovaHS.Sprint5.Task5.V6.Lib;

namespace Tyuiu.SokolovaHS.Sprint5.Task5.V6
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\DataSprintS\InPutDataFileTaskSV6.txt";

            Console.Title = "Спринт #5 | Выполнила: Соколова Х. С. | ПКТБ-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Чтение набора данных из текстового файла                          *");
            Console.WriteLine("* Задание #5                                                              *");
            Console.WriteLine("* Вариант #6                                                              *");
            Console.WriteLine("* Выполнила: Соколова Христина Сергеевна | ПКТБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл, в котором есть набор значений. Найти среднее значение всех    *");
            Console.WriteLine("* вещественных чисел в файле. Полученный результат вывести на консоль.    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            Console.WriteLine("Путь к файлу: " + path);

            // Проверяем существование файла
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не существует! Создаем тестовый файл...");
                CreateTestFile(path);
            }

            // Показываем содержимое файла
            Console.WriteLine("\nСодержимое файла:");
            string[] fileContent = File.ReadAllLines(path);
            foreach (string line in fileContent)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            Console.WriteLine($"Среднее значение: {result.ToString("F3", CultureInfo.InvariantCulture)}");
            Console.ReadLine();
        }

        static void CreateTestFile(string path)
        {
            // Создаем директорию, если её нет
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Записываем тестовые данные в файл
            string[] testData = {
                "1.5 2.7 3.9",
                "4.2 5.1",
                "6.8 7.3 8.6 9.4"
            };

            File.WriteAllLines(path, testData);
            Console.WriteLine("Создан тестовый файл с числами:");
            foreach (string line in testData)
            {
                Console.WriteLine(line);
            }
        }
    }
}
