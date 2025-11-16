using System;
using System.IO;
using Tyuiu.SokolovaHS.Sprint5.Task3.V2.Lib;

namespace Tyuiu.SokolovaHS.Sprint5.Task3.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;

            Console.Title = "Спринт #5 | Выполнила: Соколова Х. С. | ПКТБ-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Потоковый метод записи данных в бинарный файл                     *");
            Console.WriteLine("* Задание #3                                                              *");
            Console.WriteLine("* Вариант #2                                                              *");
            Console.WriteLine("* Выполнила: Соколова Христина Сергеевна | ПКТБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение y = e^x/x вычислить его значение при x = 3, результат    *");
            Console.WriteLine("* сохранить в бинарный файл OutPutFileTask3.bin и вывести на консоль.     *");
            Console.WriteLine("* Округлить до трёх знаков после запятой.                                 *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            Console.WriteLine("x = " + x);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            string res = ds.SaveToFileTextData(x);

            // Читаем значение из бинарного файла для вывода на консоль
            double resultValue = ReadResultFromBinaryFile(res);

            Console.WriteLine($"Результат: {resultValue:F3}");
            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Создан!");
            Console.ReadLine();
        }

        public static double ReadResultFromBinaryFile(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                return reader.ReadDouble();
            }
        }
    }
}