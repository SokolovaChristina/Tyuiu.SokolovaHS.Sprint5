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
        public void CheckedExactExpectedFormat()
        {
            string inputPath = @"test_input.txt";

            // Создаем тестовый файл, который должен дать "П,? О. О ."
            File.WriteAllText(inputPath, "Привет, ? мир. это тест .", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = "П,? О. О .";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedSpacesBetweenWords()
        {
            string inputPath = @"test_input2.txt";

            File.WriteAllText(inputPath, "один   два    три", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = " ";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedAllLowerCaseRemoved()
        {
            string inputPath = @"test_input3.txt";

            File.WriteAllText(inputPath, "абвгдеёжзийклмнопрстуфхцчшщъыьэюя", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = "";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedMixedText()
        {
            string inputPath = @"test_input4.txt";

            File.WriteAllText(inputPath, "Hello мир! Это Test 123.", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath, Encoding.UTF8);
            string expected = "Hello ! Т 123.";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }
    }
}