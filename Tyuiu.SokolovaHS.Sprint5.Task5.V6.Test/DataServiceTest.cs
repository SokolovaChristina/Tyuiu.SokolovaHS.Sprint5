using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task5.V6.Lib;
using System.IO;
using System.Globalization;

namespace Tyuiu.SokolovaHS.Sprint5.Task5.V6.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedValidCalculation()
        {
            string path = @"test_file.txt";

            // Создаем тестовый файл
            string[] testData = { "1.5 2.5 3.5", "4.5 5.5" };
            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Среднее: (1.5+2.5+3.5+4.5+5.5)/5 = 17.5/5 = 3.5
            double expected = 3.5;

            Assert.AreEqual(expected, result);

            // Удаляем тестовый файл
            File.Delete(path);
        }

        [TestMethod]
        public void CheckedMixedNumbers()
        {
            string path = @"test_file2.txt";

            // Создаем тестовый файл с разными форматами чисел
            string[] testData = { "1,5 2.7", "3.9 4,2", "5.1" };
            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Среднее: (1.5+2.7+3.9+4.2+5.1)/5 = 17.4/5 = 3.48
            double expected = 3.48;

            Assert.AreEqual(expected, result);

            // Удаляем тестовый файл
            File.Delete(path);
        }

        [TestMethod]
        public void CheckedEmptyFile()
        {
            string path = @"test_file3.txt";

            // Создаем пустой файл
            File.WriteAllText(path, "");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Для пустого файла должно вернуться 0
            Assert.AreEqual(0, result);

            // Удаляем тестовый файл
            File.Delete(path);
        }

        [TestMethod]
        public void CheckedWithSpacesAndTabs()
        {
            string path = @"test_file4.txt";

            // Создаем файл с пробелами и табуляциями
            string[] testData = { "  1.5\t2.7  ", "3.9\t\t4.2", "  5.1  " };
            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Среднее: (1.5+2.7+3.9+4.2+5.1)/5 = 17.4/5 = 3.48
            double expected = 3.48;

            Assert.AreEqual(expected, result);

            // Удаляем тестовый файл
            File.Delete(path);
        }

        [TestMethod]
        public void CheckedRounding()
        {
            string path = @"test_file5.txt";

            // Создаем файл с числами, которые требуют округления
            string[] testData = { "1.111 2.222", "3.333 4.444" };
            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Среднее: (1.111+2.222+3.333+4.444)/4 = 11.11/4 = 2.7775 → округление до 2.778
            double expected = 2.778;

            Assert.AreEqual(expected, result);

            // Удаляем тестовый файл
            File.Delete(path);
        }
    }
}
