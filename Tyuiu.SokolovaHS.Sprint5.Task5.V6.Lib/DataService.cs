using System;
using System.IO;
using System.Globalization;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task5.V6.Lib
{
    public class DataService : ISprint5Task5V6
    {
        public double LoadFromDataFile(string path)
        {
            // Читаем все строки из файла
            string[] lines = File.ReadAllLines(path);

            double sum = 0;
            int count = 0;

            foreach (string line in lines)
            {
                // Разбиваем строку на числа (разделители: пробелы, табуляции)
                string[] numbers = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string numberStr in numbers)
                {
                    // Пытаемся преобразовать строку в число
                    if (double.TryParse(numberStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                    {
                        sum += number;
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                return 0; // Если чисел нет, возвращаем 0
            }

            double average = sum / count;
            return Math.Round(average, 3);
        }
    }
}
