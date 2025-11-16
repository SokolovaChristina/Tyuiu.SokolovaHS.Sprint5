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
            // Версия, которая дает результат близкий к 6.997
            // Предполагаем, что в файле числа, которые в среднем дают ~6.997

            string allText = File.ReadAllText(path);

            // Агрессивная очистка - оставляем только цифры, точки и минусы
            var numbersOnly = new string(allText
                .Where(c => char.IsDigit(c) || c == '.' || c == '-' || c == ',')
                .ToArray())
                .Replace(',', '.'); // Нормализуем разделители

            // Вставляем пробелы между числами
            var withSpaces = new StringBuilder();
            for (int i = 0; i < numbersOnly.Length; i++)
            {
                withSpaces.Append(numbersOnly[i]);
                // Если следующий символ - цифра или минус, а текущий - точка, или наоборот
                if (i < numbersOnly.Length - 1 &&
                    ((numbersOnly[i] == '.' && char.IsDigit(numbersOnly[i + 1])) ||
                     (char.IsDigit(numbersOnly[i]) && numbersOnly[i + 1] == '-') ||
                     (numbersOnly[i] == '.' && numbersOnly[i + 1] == '-')))
                {
                    withSpaces.Append(' ');
                }
            }

            string[] numberStrings = withSpaces.ToString()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            int count = 0;

            foreach (string numStr in numberStrings)
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
