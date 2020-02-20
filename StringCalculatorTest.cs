using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTest

    {
        [Test]
        public void EmptyStringReturnsZero()
        {
            Assert.AreEqual(0, StringCalculator.Add(""));
        }

        [Test]
        public void BasicAddition()
        {
            Assert.AreEqual(3, StringCalculator.Add("1,2"));
        }

        [Test]
        public void GetBasicDelimiter()
        {
            const string input = "//;\n1;2";
            Assert.AreEqual(";", StringCalculator.GetDelimiter(input));
        }

        [Test]
        public void OnePlusTwo()
        {
            var result = StringCalculator.Add("1,2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void OnePlusTwoPlus3()
        {
            var result = StringCalculator.Add("1,2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void OnePlusTwoWithNewLineNAndComma()
        {
            var result = StringCalculator.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void OnePlusTwoWithNewLineRAndComma()
        {
            var result = StringCalculator.Add("1\r2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void OnePlusTwoWithNewLinesRandN()
        {
            var result = StringCalculator.Add("1\r2\n3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void OnePlusOneWithDelimiter()
        {
            var result = StringCalculator.Add("//;\n1;1");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ExceptionMessageIsCorrectForOneNegative()
        {
            var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add("-4,1"));
            Assert.That(ex.Message, Is.EqualTo("Negatives are not allowed: -4 "));
        }

        [Test]
        public void ExceptionMessageIsCorrectForThreeNegatives()
        {
            var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add("1,2,3,1,-6,12,-3,34,-6"));
            Assert.That(ex.Message, Is.EqualTo("Negatives are not allowed: -6 -3 -6 "));
        }

        [Test]
        public void Adds1000()
        {
            var result = StringCalculator.Add("1,2,1000");
            Assert.AreEqual(1003, result);
        }

        [Test]
        public void IgnoresNumbersGreaterThan1000()
        {
            var result = StringCalculator.Add("1,1,1001,1,2345");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void RandomLengthDelimiter()
        {
            const string input = "//[***]\n1***2***3";
            var result = StringCalculator.GetDelimiter(input);
            Assert.AreEqual("***", result);
        }

        [Test]
        public void DefaultDelimiter()
        {
            const string input = "1,2";
            Assert.AreEqual("[,\n\r]", StringCalculator.GetDelimiter(input));
        }
    }
}