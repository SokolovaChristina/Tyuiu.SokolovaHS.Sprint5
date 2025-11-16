using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task5.V6.Lib
{
    public class DataService : ISprint5Task5V6
    {
        public double LoadFromDataFile(string path)
        {
            // Читаем весь файл
            string allText = File.ReadAllText(path);

            // Нормализуем разделители - заменяем запятые на точки
            allText = allText.Replace(',', '.');

            // Заменяем все НЕ-цифровые символы (кроме точек и минусов) на пробелы
            var cleanedText = new StringBuilder();
            foreach (char c in allText)
            {
                if (char.IsDigit(c) || c == '.' || c == '-')
                {
                    cleanedText.Append(c);
                }
                else
                {
                    cleanedText.Append(' ');
                }
            }

            // Разбиваем на "слова" и парсим числа
            string[] potentialNumbers = cleanedText.ToString()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            int count = 0;

            foreach (string numStr in potentialNumbers)
            {
                if (double.TryParse(numStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
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
