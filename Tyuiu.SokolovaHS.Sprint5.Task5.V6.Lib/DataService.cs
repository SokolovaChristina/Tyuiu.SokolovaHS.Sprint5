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
            // Читаем весь текст из файла
            string text = File.ReadAllText(path);

            // Заменяем запятые на точки для единообразного парсинга
            text = text.Replace(',', '.');

            // Разбиваем на числа по всем возможным разделителям
            string[] numberStrings = text.Split(
                new char[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries
            );

            double sum = 0;
            int count = 0;

            foreach (string numberStr in numberStrings)
            {
                // Пытаемся преобразовать строку в число
                if (double.TryParse(numberStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
                {
                    sum += number;
                    count++;
                }
            }

            if (count == 0)
            {
                return 0;
            }

            double average = sum / count;
            return Math.Round(average, 3);
        }
    }
}
