using System;
using System.IO;
using System.Globalization;
using Tyuiu.SokolovaHS.Sprint5.Task4.V15.Lib;

namespace Tyuiu.SokolovaHS.Sprint5.Task4.V15
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\DataSprint5\InPutDataFileTask4V0.txt";

            Console.Title = "Спринт #5 | Выполнила: Соколова Х. С. | ПКТБ-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Чтение данных из текстового файла                                 *");
            Console.WriteLine("* Задание #4                                                              *");
            Console.WriteLine("* Вариант #15                                                             *");
            Console.WriteLine("* Выполнила: Соколова Христина Сергеевна | ПКТБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл, в котором есть вещественное значение. Прочитать значение из   *");
            Console.WriteLine("* файла и подставить вместо X в формуле y = sin(x) + x²/2. Вычислить      *");
            Console.WriteLine("* значение и вернуть полученный результат на консоль.                     *");
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

            // Читаем значение из файла
            string fileContent = File.ReadAllText(path);
            Console.WriteLine("Данные из файла: '" + fileContent + "'");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            Console.WriteLine($"Результат: {result.ToString("F3", CultureInfo.InvariantCulture)}");
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

            // Записываем тестовое значение в файл с точкой
            File.WriteAllText(path, "3.54");
            Console.WriteLine("Создан тестовый файл со значением: 3.54");
        }
    }
}