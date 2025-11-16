using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task4.V15.Lib
{
    public class DataService : ISprint5Task4V15
    {
        public double LoadFromDataFile(string path)
        {
            // Читаем значение из файла
            string data = File.ReadAllText(path);
            double x = double.Parse(data);

            // Вычисляем значение по формуле: y = sin(x) + x²/2
            double y = Math.Sin(x) + (x * x) / 2;

            // Округляем до трёх знаков после запятой
            return Math.Round(y, 3);
        }
    }
}
