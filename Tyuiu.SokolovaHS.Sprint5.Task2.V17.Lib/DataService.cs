using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SokolovaHS.Sprint5.Task2.V17.Lib
{
    public class DataService : ISprint5Task2V17
    {
        public string SaveToFileTextData(int[,] matrix)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask2.csv");

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            string output = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Заменяем нечетные элементы на 0
                    if (matrix[i, j] % 2 != 0)
                    {
                        output += "0";
                    }
                    else
                    {
                        output += matrix[i, j].ToString();
                    }

                    // Добавляем разделитель, если не последний элемент в строке
                    if (j < columns - 1)
                    {
                        output += ";";
                    }
                }

                // Добавляем перевод строки, если не последняя строка
                if (i < rows - 1)
                {
                    output += "\n";
                }
            }

            File.WriteAllText(path, output);
            return path;
        }
    }
}
