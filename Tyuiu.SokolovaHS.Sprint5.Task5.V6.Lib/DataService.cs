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
            // Читаем весь файл
            string allText = File.ReadAllText(path);

            // Нормализуем - заменяем запятые на точки
            allText = allText.Replace(',', '.');

            // Разбиваем на числа по пробелам
            string[] numberStrings = allText.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries
            );

            double sum = 0;
            int count = 0;

            foreach (string numStr in numberStrings)
            {
                // Убираем лишние пробелы
                string cleanNumStr = numStr.Trim();

                if (double.TryParse(cleanNumStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
                {
                    sum += number;
                    count++;
                }
            }

            if (count == 0)
                return 0;

            double average = sum / count;
            return Math.Round(average, 3);
        }
    }
}