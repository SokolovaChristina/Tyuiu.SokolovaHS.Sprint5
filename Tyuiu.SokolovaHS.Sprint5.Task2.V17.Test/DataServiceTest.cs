using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task2.V17.Lib;
using System.IO;

namespace Tyuiu.SokolovaHS.Sprint5.Task2.V17.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedExistsFile()
        {
            DataService ds = new DataService();
            int[,] matrix = { { 2, 1, 7 }, { 1, 2, 4 }, { 2, 3, 4 } };
            string path = ds.SaveToFileTextData(matrix);

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckedFileContent()
        {
            DataService ds = new DataService();
            int[,] matrix = { { 2, 1, 7 }, { 1, 2, 4 }, { 2, 3, 4 } };
            string path = ds.SaveToFileTextData(matrix);

            string fileContent = File.ReadAllText(path);
            string expected = "2;0;0\n0;2;4\n2;0;4";

            Assert.AreEqual(expected, fileContent);
        }

        [TestMethod]
        public void CheckedOddNumbersReplaced()
        {
            DataService ds = new DataService();
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            string path = ds.SaveToFileTextData(matrix);

            string fileContent = File.ReadAllText(path);
            string expected = "0;2;0\n4;0;6\n0;8;0";

            Assert.AreEqual(expected, fileContent);
        }
    }
}
