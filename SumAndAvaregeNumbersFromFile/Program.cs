using System;
using System.IO;

namespace DomaciUkol17012022
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var processor = new FileProcessor();

            var path = processor.GetFilePath();
            var numbers = processor.ReadNumbersFromFile(File.ReadAllLines(path));
            var sum = processor.GetSum(numbers);
            var avarage = processor.GetAvarage(numbers);
            OutputWriter.PrintInfo(numbers, sum, avarage);
            }
    }
}