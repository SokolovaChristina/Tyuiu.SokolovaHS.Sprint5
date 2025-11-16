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
        public void CheckedWithExpectedResult()
        {
            string path = @"test_expected.txt";

            // Создаем тестовый файл, который должен дать результат ~6.997
            // Подберем числа так, чтобы среднее было 6.997
            string[] testData = {
                "5.5 6.8 7.2",
                "8.1 6.3 7.8",
                "6.2 7.5 6.9"
            };
            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Вычисляем ожидаемое значение
            double[] numbers = { 5.5, 6.8, 7.2, 8.1, 6.3, 7.8, 6.2, 7.5, 6.9 };
            double expected = numbers.Average();
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        public void CheckedFileContentAnalysis()
        {
            string path = @"debug_file.txt";

            // Создаем файл с разными форматами для отладки
            string[] testData = {
                "1,5 2.7 3,9",
                "4.2 5,1 6.8",
                "7,3 8.6 9,4"
            };
            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Должно быть: (1.5+2.7+3.9+4.2+5.1+6.8+7.3+8.6+9.4)/9 = 49.5/9 = 5.5
            double expected = 5.5;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        public void CheckedSingleLineFormat()
        {
            string path = @"single_line.txt";

            // Тестируем формат с числами в одной строке
            File.WriteAllText(path, "6.5 7.2 8.1 6.3 7.8");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // (6.5+7.2+8.1+6.3+7.8)/5 = 35.9/5 = 7.18
            double expected = 7.18;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }
    }
}
