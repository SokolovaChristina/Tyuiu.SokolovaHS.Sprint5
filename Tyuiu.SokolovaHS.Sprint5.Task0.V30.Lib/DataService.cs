using System;
using System.IO;

namespace Tyuiu.SokolovaHS.Sprint5.Task0.V30.Lib
{
    public class DataService
    {
        public string SaveToFileTextData(int x)
        {
            // Используем временную директорию как требуется в задании
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask0.txt");

            double z = (Math.Pow(x, 2) + 1) / (3 * x + 4);
            z = Math.Round(z, 2);

            File.WriteAllText(path, z.ToString());
            return path;
        }
    }
}