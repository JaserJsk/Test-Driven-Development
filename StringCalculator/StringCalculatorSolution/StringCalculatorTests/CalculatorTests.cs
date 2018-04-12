using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StringCalculatorApp;

namespace StringCalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator sut = new Calculator();

        [Test]
        public void AddEmptyStringReturnsZero()
        {
            int result = sut.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void AddOneNumberReturnOneNumber()
        {
            int result = sut.Add("21");

            Assert.AreEqual(21, result);
        }

        [Test]
        public void AddTwoNumbersDelimitedWithComma_ReturnsSum()
        {
            int result = sut.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void AddMultipleNumbersDelimitedWithComma_ReturnsSum()
        {
            int result = sut.Add("1,2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddTwoNumbersDelimitedWithNewLine_ReturnsSum()
        {
            int result = sut.Add("1\n2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void AddTwoNumbersDelimitedWithCustomDelimiter_ReturnsSum()
        {
            string input = "//;\n1;2";
            int result = sut.Add(input);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void AddNegativeNumber_ThrowsArgumentException()
        {
            
            Assert.Throws<ArgumentException>((() => sut.Add("-1")));
        }

        [Test]
        public void AddNegativeNumber_ErrorMessageContainsNumber()
        {
            try
            {
                sut.Add("-1");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Negatives not allowed: -1", e.Message);
            }
        }

        [Test]
        public void AddMultipleNegativeNumbers_ErrorMessageContainsAllNegativeNumbers()
        {
            try
            {
                sut.Add("-1,2,-3");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Negatives not allowed: -1 -3", e.Message);
            }
        }
    }
}
