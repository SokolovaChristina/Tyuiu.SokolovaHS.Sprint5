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

            // Удаляем строчные русские буквы и множественные пробелы
            string resultText = RemoveLowercaseRussianLettersAndMultipleSpaces(inputText);

            // Сохраняем результат в новый файл
            File.WriteAllText(outputPath, resultText, Encoding.UTF8);

            return outputPath;
        }

        public string RemoveLowercaseRussianLettersAndMultipleSpaces(string text)
        {
            StringBuilder result = new StringBuilder();
            bool lastWasSpace = false;

            foreach (char c in text)
            {
                // Обрабатываем пробелы - оставляем только одиночные
                if (c == ' ')
                {
                    if (!lastWasSpace)
                    {
                        result.Append(c);
                        lastWasSpace = true;
                    }
                    // Пропускаем множественные пробелы
                    continue;
                }
                else
                {
                    lastWasSpace = false;
                }

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