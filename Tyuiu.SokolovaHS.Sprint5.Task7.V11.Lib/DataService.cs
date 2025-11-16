using System;
using System.IO;
using System.Linq;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task7.V11.Lib
{
    public class DataService : ISprint5Task7V11
    {
        public string LoadDataAndSave(string path)
        {
            string outputPath = Path.Combine(Path.GetTempPath(), "OutPutDataFileTask7V11.txt");

            // Читаем исходный файл
            string inputText = File.ReadAllText(path);

            // Удаляем пробелы и строчные русские буквы
            string resultText = RemoveSpacesAndLowercaseRussianLetters(inputText);

            // Сохраняем результат в новый файл
            File.WriteAllText(outputPath, resultText, Encoding.UTF8);

            return outputPath;
        }

        public string RemoveSpacesAndLowercaseRussianLetters(string text)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                // Пропускаем пробелы
                if (c == ' ')
                    continue;

                // Пропускаем строчные русские буквы
                if (c >= 'а' && c <= 'я')
                    continue;

                // Пропускаем букву 'ё'
                if (c == 'ё')
                    continue;

                // Все остальные символы оставляем
                result.Append(c);
            }

            return result.ToString();
        }
    }
}
