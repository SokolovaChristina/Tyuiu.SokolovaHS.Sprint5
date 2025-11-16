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
            string expected = "-0,62\r\n-16,79\r\n-17,77\r\n-6,3\r\n-5,04\r\n-6\r\n-7,85\r\n-2,43\r\n5,91\r\n4,33\r\n-11,82\r\n";

            Assert.AreEqual(expected, fileContent);
        }
    }
}