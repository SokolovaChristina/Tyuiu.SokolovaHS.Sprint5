using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task1.V14.Lib
{
    public class DataService : ISprint5Task1V14
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int x = startValue; x <= stopValue; x++)
                {
                    double value = Calculate(x);
                    // Убираем лишние нули через преобразование в строку и обратно
                    string stringValue = value.ToString("F10").Replace(".", ",");
                    stringValue = stringValue.TrimEnd('0').TrimEnd(',');

                    writer.WriteLine(stringValue);
                }
            }
            return path;
        }

        public double Calculate(double x)
        {
            // Проверка деления на ноль
            if (Math.Abs(x + 1.7) < 0.0001)
            {
                return 0;
            }

            double result = Math.Sin(x) / (x + 1.7) - Math.Cos(x) * 4 * x - 6;
            return Math.Round(result, 2);
        }
    }
}