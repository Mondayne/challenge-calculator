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
        public void Add_MoreThanTwoNumberInput_ReturnsFormatException()
        {
            string input = "1,2,3,4,5,6,7,8,9,10,11,12";
            var result = Calculator.Add(input);
            Assert.AreEqual("78", result);
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

        [TestMethod]
        public void Add_GoodInputsWithNewlineDelimiter_ReturnsEqual()
        {
            string input = "1\n2,3";
            var result = Calculator.Add(input);
            Assert.AreEqual("6", result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "-3")]
        public void Add_PositiveInputAndNegativeInput_ReturnsFormatExcepition()
        {
            string input = "4,-3";
            Calculator.Add(input);
        }

        [TestMethod]
        public void Add_GoodInputsWithInputOver1000_ReturnsEqual()
        {
            string input = "2,1001,6";
            var result = Calculator.Add(input);
            Assert.AreEqual("8", result);
        }

        [TestMethod]
        public void Add_InputsWithCustomDelimiterUsage_ReturnsEqual()
        {
            string input = "//#\n2#5";
            //string input = "//,\n2,ff,100";
            var result = Calculator.Add(input);
            Assert.AreEqual("7", result);
        }

        [TestMethod]
        public void Add_InputsWithCustomBracketedDelimiter_ReturnsEqual()
        {
            string input = "//[***]\n11***22***33";
            var result = Calculator.Add(input);
            Assert.AreEqual("66", result);
        }

        [TestMethod]
        public void Add_InputsWithMultipleCustomBracketedDelimiter_ReturnsEqual()
        {
            string input = "//[*][!!][r9r]\n11r9r22*hh*33!!44";
            var result = Calculator.Add(input);
            Assert.AreEqual("110", result);
        }

    }
}
