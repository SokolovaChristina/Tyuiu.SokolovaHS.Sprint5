using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task4.V15.Lib;
using System.IO;

namespace Tyuiu.SokolovaHS.Sprint5.Task4.V15.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedValidCalculation()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask4V0.txt";

            // Создаем тестовый файл
            File.WriteAllText(path, "2.5");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Проверяем вычисление: sin(2.5) + (2.5²)/2
            double expected = Math.Sin(2.5) + (2.5 * 2.5) / 2;
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CheckedZeroValue()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask4V0_Test.txt";

            // Создаем тестовый файл с нулевым значением
            File.WriteAllText(path, "0");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // sin(0) + (0²)/2 = 0 + 0 = 0
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CheckedNegativeValue()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask4V0_Test2.txt";

            // Создаем тестовый файл с отрицательным значением
            File.WriteAllText(path, "-1.5");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // sin(-1.5) + ((-1.5)²)/2
            double expected = Math.Sin(-1.5) + (2.25) / 2;
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Удаляем тестовые файлы после выполнения тестов
            if (File.Exists(@"C:\DataSprint5\InPutDataFileTask4V0_Test.txt"))
            {
                File.Delete(@"C:\DataSprint5\InPutDataFileTask4V0_Test.txt");
            }
            if (File.Exists(@"C:\DataSprint5\InPutDataFileTask4V0_Test2.txt"))
            {
                File.Delete(@"C:\DataSprint5\InPutDataFileTask4V0_Test2.txt");
            }
        }
    }
}
