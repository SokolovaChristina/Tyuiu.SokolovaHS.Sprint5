using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task7.V11.Lib
{
    public class DataService : ISprint5Task7V11
    {
        public string LoadDataAndSave(string path)
        {
            string outputPath = Path.Combine(Path.GetTempPath(), "OutPutDataFileTask7V11.txt");

            string inputText = File.ReadAllText(path, Encoding.UTF8);
            string resultText = ProcessText(inputText);

            File.WriteAllText(outputPath, resultText, Encoding.UTF8);
            return outputPath;
        }

        public string ProcessText(string text)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                // Удаляем строчные русские буквы
                if ((c >= 'а' && c <= 'я') || c == 'ё')
                    continue;

                // Оставляем все остальные символы (включая пробелы)
                result.Append(c);
            }

            // Убираем лишние пробелы
            string cleaned = result.ToString();

            // Заменяем множественные пробелы на одинарные
            while (cleaned.Contains("  "))
            {
                cleaned = cleaned.Replace("  ", " ");
            }

            // Убираем пробелы перед знаками препинания (кроме последней точки)
            cleaned = cleaned.Replace(" ,", ",");
            cleaned = cleaned.Replace(" ?", "?");
            cleaned = cleaned.Replace(" !", "!");
            cleaned = cleaned.Replace(" :", ":");
            cleaned = cleaned.Replace(" ;", ";");

            // Обрабатываем точки: убираем пробел перед всеми точками кроме последней
            int lastDotIndex = cleaned.LastIndexOf('.');
            if (lastDotIndex != -1)
            {
                // Обрабатываем все точки до последней
                string beforeLastDot = cleaned.Substring(0, lastDotIndex);
                beforeLastDot = beforeLastDot.Replace(" .", ".");

                // Последнюю часть оставляем как есть (с пробелом перед точкой если есть)
                string afterLastDot = cleaned.Substring(lastDotIndex);

                cleaned = beforeLastDot + afterLastDot;
            }
            else
            {
                // Если точек нет, убираем все пробелы перед точками
                cleaned = cleaned.Replace(" .", ".");
            }

            return cleaned.Trim();
        }
    }
}