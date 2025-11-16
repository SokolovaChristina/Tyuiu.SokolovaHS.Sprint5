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

            string inputText = File.ReadAllText(path);
            string resultText = ProcessText(inputText);

            File.WriteAllText(outputPath, resultText, Encoding.UTF8);
            return outputPath;
        }

        public string ProcessText(string text)
        {
            StringBuilder result = new StringBuilder();
            bool lastWasNonSpace = false;

            foreach (char c in text)
            {
                // Удаляем строчные русские буквы
                if ((c >= 'а' && c <= 'я') || c == 'ё')
                    continue;

                // Если это пробел
                if (c == ' ')
                {
                    // Добавляем пробел только если перед ним был не пробельный символ
                    if (lastWasNonSpace)
                    {
                        result.Append(' ');
                        lastWasNonSpace = false;
                    }
                }
                else
                {
                    // Добавляем символ и отмечаем, что был не пробел
                    result.Append(c);
                    lastWasNonSpace = true;
                }
            }

            // Убираем пробел в конце, если есть
            return result.ToString().Trim();
        }
    }
}