using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SokolovaHS.Sprint5.Task6.V17.Lib;
using System.IO;

namespace Tyuiu.SokolovaHS.Sprint5.Task6.V17.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedMultipleSpaces()
        {
            string path = @"test_file1.txt";

            // Создаем тестовый файл с несколькими последовательностями пробелов
            File.WriteAllText(path, "Это  текст  с   тремя    пробелами.");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            // Последовательности: "  ", "  ", "   ", "    " - но "  " считается один раз за последовательность
            // Всего 4 последовательности пробелов длиной 2+
            int expected = 4;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        public void CheckedSingleSpaces()
        {
            string path = @"test_file2.txt";

            // Создаем тестовый файл только с одиночными пробелами
            File.WriteAllText(path, "Текст с одиночными пробелами");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            // Нет последовательностей из 2+ пробелов
            int expected = 0;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        public void CheckedMixedSpaces()
        {
            string path = @"test_file3.txt";

            // Создаем тестовый файл со смешанными пробелами
            File.WriteAllText(path, "Раз   два    три     конец");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            // Последовательности: "   ", "    ", "     " - 3 последовательности
            int expected = 3;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        public void CheckedNoSpaces()
        {
            string path = @"test_file4.txt";

            // Создаем тестовый файл без пробелов
            File.WriteAllText(path, "ТекстБезПробелов");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            int expected = 0;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        public void CheckedOnlySpaces()
        {
            string path = @"test_file5.txt";

            // Создаем тестовый файл только с пробелами
            File.WriteAllText(path, "      ");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            // Одна длинная последовательность пробелов
            int expected = 1;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }
    }
}
