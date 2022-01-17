using System;
using System.Collections.Generic;

namespace DomaciUkol17012022
{
    public static class OutputWriter
    {
        public static void PrintInfo(List<int> numbers, double sum, double avarage)
        {
            Console.Clear();
            var collectionInfoText = " Načtená čísla: " + WriteCollection(numbers);
            var sumInfoText = " Součet čísel: " + sum;
            var avarageInfoText = " Průměr čísel: " + avarage;

            var rowLenght = GetLongestRowLenght(new[] {collectionInfoText, sumInfoText, avarageInfoText}) + 2;

            DrawLine(rowLenght);
            WriteRow(collectionInfoText, rowLenght);
            DrawLine(rowLenght);
            WriteRow(sumInfoText, rowLenght);
            DrawLine(rowLenght);
            WriteRow(avarageInfoText, rowLenght);
            DrawLine(rowLenght);
            Console.ReadKey();
        }

        private static void DrawLine(int count)
        {
            for (var i = 0; i < count; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine();
        }

        private static string WriteCollection(List<int> numbers)
        {
            var collectionRow = "";
            foreach (var number in numbers)
            {
                collectionRow += number + " ";
            }

            return collectionRow;
        }

        public static int GetLongestRowLenght(string[] rows)
        {
            var longest = int.MinValue;

            foreach (var row in rows)
            {
                if (row.Length > longest)
                {
                    longest = row.Length;
                }
            }

            return longest;
        }

        private static void WriteRow(string text, int lenght)
        {
            lenght -= 2;
            Console.Write("|");
            Console.Write(text);
            for (var i = text.Length; i < lenght; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine("|");
        }
    }
}