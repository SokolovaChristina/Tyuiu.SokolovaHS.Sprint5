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
        public void CheckedFileCreation()
        {
            string inputPath = @"test_input.txt";

            // Создаем тестовый файл
            File.WriteAllText(inputPath, "тест ТЕСТ 123", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            // Проверяем, что выходной файл создан
            FileInfo fileInfo = new FileInfo(outputPath);
            bool fileExists = fileInfo.Exists;

            Assert.IsTrue(fileExists);

            // Удаляем тестовые файлы
            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedTextProcessing()
        {
            string inputPath = @"test_input2.txt";

            // Создаем тестовый файл с русскими буквами и пробелами
            File.WriteAllText(inputPath, "Привет мир! Это ТЕСТ 123.", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            // Читаем результат
            string result = File.ReadAllText(outputPath, Encoding.UTF8);

            // Должно остаться: "!ТЕСТ123." (пробелы и строчные русские буквы удалены)
            string expected = "!ТЕСТ123.";

            Assert.AreEqual(expected, result);

            // Удаляем тестовые файлы
            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedOnlySpacesAndLowercase()
        {
            string inputPath = @"test_input3.txt";

            // Создаем тестовый файл только с пробелами и строчными русскими буквами
            File.WriteAllText(inputPath, "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            // Читаем результат
            string result = File.ReadAllText(outputPath, Encoding.UTF8);

            // Должно остаться пустая строка
            string expected = "";

            Assert.AreEqual(expected, result);

            // Удаляем тестовые файлы
            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedUppercaseAndSymbolsRemain()
        {
            string inputPath = @"test_input4.txt";

            // Создаем тестовый файл с заглавными буквами, цифрами и символами
            File.WriteAllText(inputPath, "АБВГД ABC 123 !@#$", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            // Читаем результат
            string result = File.ReadAllText(outputPath, Encoding.UTF8);

            // Должно остаться все, кроме пробелов: "АБВГДABC123!@#$"
            string expected = "АБВГДABC123!@#$";

            Assert.AreEqual(expected, result);

            // Удаляем тестовые файлы
            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckedMixedContent()
        {
            string inputPath = @"test_input5.txt";

            // Создаем тестовый файл со смешанным содержимым
            File.WriteAllText(inputPath, "Строчная заглавная 123 test TEST", Encoding.UTF8);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            // Читаем результат
            string result = File.ReadAllText(outputPath, Encoding.UTF8);

            // Должно остаться: "123testTEST" (строчные русские удалены, английские остаются)
            string expected = "123testTEST";

            Assert.AreEqual(expected, result);

            // Удаляем тестовые файлы
            File.Delete(inputPath);
            File.Delete(outputPath);
        }
    }
}