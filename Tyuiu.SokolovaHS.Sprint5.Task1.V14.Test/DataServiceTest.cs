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

            string[] fileLines = File.ReadAllLines(path);

            Assert.IsTrue(fileLines.Length > 0);
            Assert.AreEqual("x\tf(x)", fileLines[0]); // Проверка заголовка

            // Проверка что файл содержит данные для всех x от -5 до 5
            Assert.AreEqual(11, fileLines.Length); // заголовок + 11 строк данных
        }

        [TestMethod]
        public void CheckedCalculateDivisionByZero()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-2, -1);

            string[] fileLines = File.ReadAllLines(path);

            // Проверяем что при x = -1.7 (округляется до -2) значение равно 0
            bool foundZero = false;
            foreach (string line in fileLines)
            {
                if (line.Contains("-2") && line.Contains("0"))
                {
                    foundZero = true;
                    break;
                }
            }
            Assert.IsTrue(foundZero);
        }

        [TestMethod]
        public void CheckedCalculateNormalValue()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(0, 0);

            string[] fileLines = File.ReadAllLines(path);
            string dataLine = fileLines[1]; // Первая строка с данными

            string[] parts = dataLine.Split('\t');
            double result = double.Parse(parts[1]);

            // Проверка вычисления для x = 0
            double expected = Math.Sin(0) / (0 + 1.7) - Math.Cos(0) * 4 * 0 - 6;
            expected = Math.Round(expected, 2);

            Assert.AreEqual(expected, result);
        }
    }
}