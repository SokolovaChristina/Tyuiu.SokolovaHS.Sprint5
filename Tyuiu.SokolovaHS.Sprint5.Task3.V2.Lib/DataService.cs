using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task3.V2.Lib
{
    public class DataService : ISprint5Task3V2
    {
        public string SaveToFileTextData(int x)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            // Вычисляем значение функции
            double y = Math.Exp(x) / x;
            y = Math.Round(y, 3);

            // Записываем в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(y);
            }

            return path;
        }
    }
}
