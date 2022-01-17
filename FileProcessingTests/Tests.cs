using System;
using System.Collections.Generic;
using System.Linq;
using DomaciUkol17012022;
using NUnit.Framework;


namespace FileProcessingTests
{
    [TestFixture]
    public class Tests
    {
        private FileProcessor processor;

        public Tests()
        {
            processor = new FileProcessor();
        }

        [Test]
        public void TestNumberConverting()
        {
            string[] dataToProcess = {"b;ssf;fdsa;5;fdss;68;1;dsat","b;ssf;fdsa;5;fdss;63;4;dsat"};
            List<int> processedNumbers = processor.ReadNumbersFromFile(dataToProcess);
            List<int> expectedNumbers = new List<int>() {5, 68, 1, 5, 63, 4};

            CollectionAssert.AreEqual(expectedNumbers, processedNumbers);
        }

        List<int> numbers = new List<int>() {5, 68, 1, 5, 63, 4};

        [Test]
        public void TestSumCounting()
        {
            Assert.AreEqual(numbers.Sum(), processor.GetSum(numbers));
        }

        [Test]
        public void TestAvarageCounting()
        {
            Assert.AreEqual(numbers.Average(), processor.GetAvarage(numbers));
        }

        [Test]
        public void TestGettingLongestText()
        {
            Assert.AreEqual(9, OutputWriter.GetLongestRowLenght(new[] {"praha", "les", "pardubice", "strecha"}));
        }
    }
}