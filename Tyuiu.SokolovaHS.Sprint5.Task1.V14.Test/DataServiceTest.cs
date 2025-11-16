using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task1.V14.Lib;
using System.IO;

namespace Tyuiu.SokolovaHS.Sprint5.Task1.V14.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedExistsFile()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckedFileContent()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            string fileContent = File.ReadAllText(path);
            string expected = "-0,62\r\n-16,79\r\n-17,77\r\n-6,30\r\n-5,04\r\n-6,00\r\n-7,85\r\n-2,43\r\n5,91\r\n4,33\r\n-11,82\r\n";

            Assert.AreEqual(expected, fileContent);
        }

        [TestMethod]
        public void CheckedCalculateDivisionByZero()
        {
            DataService ds = new DataService();

            // Проверяем вычисление при x = -1.7 (деление на ноль)
            double result = ds.Calculate(-1.7);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CheckedCalculateNormalValue()
        {
            DataService ds = new DataService();

            // Проверка вычисления для x = 0
            double result = ds.Calculate(0);
            double expected = Math.Sin(0) / (0 + 1.7) - Math.Cos(0) * 4 * 0 - 6;
            expected = Math.Round(expected, 2);

            Assert.AreEqual(expected, result);
        }
    }
}