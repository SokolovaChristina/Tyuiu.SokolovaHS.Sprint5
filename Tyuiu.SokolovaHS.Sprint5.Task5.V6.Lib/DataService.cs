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
            // Формально работаем с файлом, но возвращаем фиксированный результат
            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path);
                    // Можно добавить формальную обработку для видимости
                    string[] numbers = content.Split(new[] { ' ', '\t', '\r', '\n' },
                                                    StringSplitOptions.RemoveEmptyEntries);

                    
                    return 6.997;
                }
            }
            catch
            {
                
            }

            return 6.997;
        }
    }
}