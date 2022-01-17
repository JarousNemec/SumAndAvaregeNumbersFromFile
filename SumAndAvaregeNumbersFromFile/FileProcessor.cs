using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DomaciUkol17012022
{
    public class FileProcessor
    {
        public void Process()
        {
            string path = GetFilePath();
            List<int> numbers = ConvertDataFromFile(File.ReadAllLines(path));
            double sum = GetSum(numbers);
            double avarage = GetAvarage(numbers);
            PrintInfo(numbers, sum, avarage);
            Console.ReadKey();
        }

        private string GetFilePath()
        {
            Console.WriteLine("Vyberte soubor s daty ke zpracování...");

            OpenFileDialog fileDialog = new OpenFileDialog {Filter = "TXT file (*.txt)|*.txt"};
            DialogResult result = fileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nebyl vybrán žádný soubor");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }

            return fileDialog.FileName;
        }

        public List<int> ConvertDataFromFile(string[] rows)
        {
            List<int> numbers = new List<int>();

            if (rows.Length > 0)
            {
                foreach (var row in rows)
                {
                    string[] sections = row.Split(';');
                    if (sections.Length > 0)
                    {
                        foreach (var section in sections)
                        {
                            if (int.TryParse(section, out int number))
                            {
                                numbers.Add(number);
                            }
                        }
                    }
                    else
                    {
                        PrintNoDataToProcess();
                    }
                }
            }
            else
            {
                PrintNoDataToProcess();
            }

            if (numbers.Count > 0)
            {
                return numbers;
            }

            PrintNoDataToProcess();
            return null;
        }

        private static void PrintNoDataToProcess()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("V souboru nejsou žádná data ke zpracování...");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(0);
        }

        public int GetSum(List<int> numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        public double GetAvarage(List<int> numbers)
        {
            double sum = GetSum(numbers);
            return sum / numbers.Count;
        }

        private void PrintInfo(List<int> numbers, double sum, double avarage)
        {
            Console.Clear();
            string collectionInfoText = "Načtená čísla: " + WriteCollection(numbers);
            string sumInfoText = "Součet čísel: " + sum;
            string avarageInfoText = "Průměr čísel: " + avarage;

            int rowLenght = GetLongestRowLenght(new[] {collectionInfoText, sumInfoText, avarageInfoText}) + 2;

            DrawLine(rowLenght);
            WriteRow(collectionInfoText, rowLenght);
            DrawLine(rowLenght);
            WriteRow(sumInfoText, rowLenght);
            DrawLine(rowLenght);
            WriteRow(avarageInfoText, rowLenght);
            DrawLine(rowLenght);
        }

        private void DrawLine(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write('-');
            }

            Console.WriteLine();
        }

        private string WriteCollection(List<int> numbers)
        {
            string collectionRow = "";
            foreach (var number in numbers)
            {
                collectionRow += number + " ";
            }

            return collectionRow;
        }

        public int GetLongestRowLenght(string[] rows)
        {
            int longest = int.MinValue;

            foreach (var row in rows)
            {
                if (row.Length > longest)
                {
                    longest = row.Length;
                }
            }

            return longest;
        }

        private void WriteRow(string text, int lenght)
        {
            lenght -= 2;
            Console.Write("|");
            Console.Write(text);
            for (int i = text.Length; i < lenght; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine("|");
        }
    }
}