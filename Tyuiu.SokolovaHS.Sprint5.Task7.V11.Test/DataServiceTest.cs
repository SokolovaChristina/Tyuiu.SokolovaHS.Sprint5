using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task7.V11.Lib;
using System.IO;
using System.Text;

namespace Tyuiu.SokolovaHS.Sprint5.Task7V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedExpectedFormat()
        {
            string inputPath = @"test_input.txt";

            // Создаем тестовый файл
            File.WriteAllText(inputPath, "Привет,? мир. это тест.", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = "П,?О.О.";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedNoSpacesAtAll()
        {
            string inputPath = @"test_input2.txt";

            File.WriteAllText(inputPath, "текст с пробелами и , ? . символами", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = ",?.символами";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedOnlyRussianLowercaseRemoved()
        {
            string inputPath = @"test_input3.txt";

            File.WriteAllText(inputPath, "абвгд ABC abc 123 ,.!", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = "ABCabc123,.!";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }
    }
}