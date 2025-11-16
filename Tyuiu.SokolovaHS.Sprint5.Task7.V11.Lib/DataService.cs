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

                // Удаляем пробелы
                if (c == ' ')
                    continue;


                // Оставляем все остальные символы
                result.Append(c);
            }

            return result.ToString();
        }
    }
}
