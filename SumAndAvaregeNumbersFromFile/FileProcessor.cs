using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DomaciUkol17012022
{
    public class FileProcessor
    {
        public string GetFilePath()
        {
            Console.WriteLine("Vyberte soubor s daty ke zpracování...");

            var fileDialog = new OpenFileDialog {Filter = "TXT file (*.txt)|*.txt"};
            var result = fileDialog.ShowDialog();

            if (result == DialogResult.OK) return fileDialog.FileName;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nebyl vybrán žádný soubor");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(0);

            return fileDialog.FileName;
        }

        public List<int> ReadNumbersFromFile(string[] rows)
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

        private void PrintNoDataToProcess()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("V souboru nejsou žádná data ke zpracování...");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(0);
        }

        public int GetSum(List<int> numbers)
        {
            return numbers.Sum();
        }

        public double GetAvarage(List<int> numbers)
        {
            return numbers.Average();
        }

        
    }
}