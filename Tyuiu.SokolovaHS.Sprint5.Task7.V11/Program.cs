using System;
using System.IO;
using System.Text;
using Tyuiu.SokolovaHS.Sprint5.Task7.V11.Lib;

namespace Tyuiu.SokolovaHS.Sprint5.Task7.V11
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\DataSprint\InPutDataFileTask7V11.txt";

            Console.Title = "Спринт #5 | Выполнила: Соколова Х. С. | ПКТБ-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Добавление к решению итоговых проектов по спринту                 *");
            Console.WriteLine("* Задание #7                                                              *");
            Console.WriteLine("* Вариант #11                                                             *");
            Console.WriteLine("* Выполнила: Соколова Христина Сергеевна | ПКТБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл, в котором есть набор символьных данных. Удалить все пробелы   *");
            Console.WriteLine("* и строчные русские буквы из файла. Полученный результат сохранить в     *");
            Console.WriteLine("* файл OutPutDataFileTask7V11.txt.                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            Console.WriteLine("Путь к исходному файлу: " + path);

            // Проверяем существование файла
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не существует! Создаем тестовый файл...");
                CreateTestFile(path);
            }

            // Показываем содержимое исходного файла
            Console.WriteLine("\nСодержимое исходного файла:");
            string inputContent = File.ReadAllText(path, Encoding.UTF8);
            Console.WriteLine($"'{inputContent}'");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            string resultPath = ds.LoadDataAndSave(path);

            // Показываем содержимое результирующего файла
            Console.WriteLine("Файл результата: " + resultPath);
            Console.WriteLine("Создан!");

            string outputContent = File.ReadAllText(resultPath, Encoding.UTF8);
            Console.WriteLine("\nСодержимое результирующего файла:");
            Console.WriteLine($"'{outputContent}'");

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
            string testData = "Привет МИР! Это тестовый текст 123. Hello World!";
            File.WriteAllText(path, testData, Encoding.UTF8);
            Console.WriteLine("Создан тестовый файл с текстом:");
            Console.WriteLine($"'{testData}'");
        }
    }
}
