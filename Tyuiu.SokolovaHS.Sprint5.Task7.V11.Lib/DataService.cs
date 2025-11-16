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

            // Убираем пробелы перед знаками препинания
            cleaned = cleaned.Replace(" ,", ",");
            cleaned = cleaned.Replace(" ?", "?");
            cleaned = cleaned.Replace(" !", "!");
            cleaned = cleaned.Replace(" :", ":");
            cleaned = cleaned.Replace(" ;", ";");

            // Оставляем пробел перед точкой только если это не первая точка
            // Для этого найдем все точки и обработаем их по-разному
            string[] parts = cleaned.Split('.');
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim();
                if (i < parts.Length - 1)
                {
                    // Для всех точек кроме последней убираем пробел перед точкой
                    if (parts[i].EndsWith(" "))
                    {
                        parts[i] = parts[i].Substring(0, parts[i].Length - 1);
                    }
                }
            }

            // Собираем обратно
            cleaned = string.Join(".", parts);

            return cleaned.Trim();
        }
    }
}