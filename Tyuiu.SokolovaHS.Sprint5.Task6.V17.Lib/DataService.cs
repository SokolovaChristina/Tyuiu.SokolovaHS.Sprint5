using System;
using System.IO;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task6.V17.Lib
{
    public class DataService : ISprint5Task6V17
    {
        public int LoadFromDataFile(string path)
        {
            // Читаем весь текст из файла
            string text = File.ReadAllText(path);

            int count = 0;
            bool inMultipleSpaces = false;

            // Проходим по всем символам в тексте
            for (int i = 0; i < text.Length - 1; i++)
            {
                // Если текущий символ пробел и следующий тоже пробел
                if (text[i] == ' ' && text[i + 1] == ' ')
                {
                    // Если мы еще не считаем эту последовательность пробелов
                    if (!inMultipleSpaces)
                    {
                        count++;
                        inMultipleSpaces = true;
                    }
                }
                else
                {
                    // Сброс флага, когда последовательность пробелов закончилась
                    inMultipleSpaces = false;
                }
            }

            return count;
        }
    }
}
