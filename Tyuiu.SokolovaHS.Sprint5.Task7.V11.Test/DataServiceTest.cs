using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task7.V11.Lib;
using System.IO;
using System.Text;

namespace Tyuiu.SokolovaHS.Sprint5.Task7.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedExpectedResult()
        {
            string inputPath = @"test_input.txt";

            // Создаем тестовый файл с ожидаемым результатом
            File.WriteAllText(inputPath, "Привет,?  мир.  это  тест .", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = "П,? мир. это тест .";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedSpacesPreservation()
        {
            string inputPath = @"test_input2.txt";

            File.WriteAllText(inputPath, "много     пробелов   здесь", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = " пробелов здесь";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedLowercaseRemoval()
        {
            string inputPath = @"test_input3.txt";

            File.WriteAllText(inputPath, "абв АБВ abc ABC", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = " АБВ abc ABC";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }
    }
}