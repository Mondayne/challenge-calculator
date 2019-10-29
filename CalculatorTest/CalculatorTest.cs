using ChallengeCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_TwoNumberInput_ReturnsEqual()
        {
            string input = "1,2";
            var result = Calculator.Add(input);
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Cannot have more than 2 numbers.")]
        public void Add_MoreThanTwoNumberInput_ReturnsFormatException()
        {
            string input = "1,2,3";
            Calculator.Add(input);
        }

        [TestMethod]
        public void Add_OneNumberInput_ReturnsNumber()
        {
            string input = "1";
            var result = Calculator.Add(input);
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void Add_OneGoodInputAndOneBadInput_ReturnsEqual()
        {
            string input = "1, l;ijk";
            var result = Calculator.Add(input);
            Assert.AreEqual("1", result);
        }

    }
}
