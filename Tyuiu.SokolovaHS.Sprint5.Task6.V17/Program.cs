using System;
using System.IO;
using Tyuiu.SokolovaHS.Sprint5.Task6.V17.Lib;

namespace Tyuiu.SokolovaHS.Sprint5.Task6.V17
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\DataSprint5\InPutDataFileTask6V17.txt";

            Console.Title = "Спринт #5 | Выполнила: Соколова Х. С. | ПКТБ-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Обработка текстовых файлов                                        *");
            Console.WriteLine("* Задание #6                                                              *");
            Console.WriteLine("* Вариант #17                                                             *");
            Console.WriteLine("* Выполнила: Соколова Христина Сергеевна | ПКТБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл, в котором есть набор символьных данных. Найти количество      *");
            Console.WriteLine("* пробелов, идущих подряд больше одного, в заданной строке.               *");
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
            string fileContent = File.ReadAllText(path);
            Console.WriteLine($"'{fileContent}'");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            Console.WriteLine($"Количество последовательностей из 2+ пробелов: {result}");
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
            string testData = "Это  текст  с  несколькими   пробелами    подряд.";
            File.WriteAllText(path, testData);
            Console.WriteLine("Создан тестовый файл с текстом:");
            Console.WriteLine($"'{testData}'");
        }
    }
}