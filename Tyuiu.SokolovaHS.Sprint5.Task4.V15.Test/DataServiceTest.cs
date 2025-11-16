using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task4.V15.Lib;
using System.IO;
using System.Globalization;

namespace Tyuiu.SokolovaHS.Sprint5.Task4.V15.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedValidCalculationWithDot()
        {
            string path = @"test_file.txt";

            // Создаем тестовый файл с точкой как разделителем
            File.WriteAllText(path, "3.54");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Проверяем вычисление: sin(3.54) + (3.54²)/2
            double expected = Math.Sin(3.54) + (3.54 * 3.54) / 2;
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result);

            // Удаляем тестовый файл
            File.Delete(path);
        }

        [TestMethod]
        public void CheckedValidCalculationWithComma()
        {
            string path = @"test_file2.txt";

            // Создаем тестовый файл с запятой как разделителем
            File.WriteAllText(path, "2,5");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Проверяем вычисление: sin(2.5) + (2.5²)/2
            double expected = Math.Sin(2.5) + (2.5 * 2.5) / 2;
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result);

            // Удаляем тестовый файл
            File.Delete(path);
        }

        [TestMethod]
        public void CheckedWithSpaces()
        {
            string path = @"test_file3.txt";

            // Создаем тестовый файл с пробелами
            File.WriteAllText(path, "  1.23  ");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Проверяем вычисление: sin(1.23) + (1.23²)/2
            double expected = Math.Sin(1.23) + (1.23 * 1.23) / 2;
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result);

            // Удаляем тестовый файл
            File.Delete(path);
        }
    }
}
