using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task3.V2.Lib;
using System.IO;

namespace Tyuiu.SokolovaHS.Sprint5.Task3.V2.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedExistsFile()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckedFileContent()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);

            // Читаем значение из бинарного файла
            double result = ReadFromBinaryFile(path);

            // Проверяем вычисление: e^3 / 3
            double expected = Math.Exp(3) / 3;
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CheckedCalculationCorrectness()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);

            double result = ReadFromBinaryFile(path);

            // e^3 ≈ 20.0855, делим на 3 ≈ 6.695
            double expected = 20.085536923187 / 3;
            expected = Math.Round(expected, 3); // 6.695

            Assert.AreEqual(expected, result);
        }

        public double ReadFromBinaryFile(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                return reader.ReadDouble();
            }
        }
    }
}
