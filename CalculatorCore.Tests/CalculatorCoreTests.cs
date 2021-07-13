using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        private Calculator calc;

        [TestInitialize]
        public void Setup()
        {
            calc = new Calculator();
        }

        [TestMethod]
        public void AddTwoNumbers()
        {
            var result = calc.Evaluate("6 + 8");
            Assert.AreEqual(14m, result.Result);
        }

        [TestMethod]
        public void TestFirstValueIsNotANumber()
        {
            var result = calc.Evaluate("bob + 7");
            Assert.AreEqual("The first value you entered, bob, was not a valid number.", result.ErrorMessage);
        }

        [TestMethod]
        public void TestSecondValueIsNotANumber()
        {
            var result = calc.Evaluate("7 + bob");
            Assert.AreEqual("The second value you entered, bob, was not a valid number.", result.ErrorMessage);
        }

        [TestMethod]
        public void SubtractTwoNumbers()
        {
            var result = calc.Evaluate("10 - 6");
            Assert.AreEqual(4m, result.Result);
        }

        [TestMethod]
        public void MultiplyTwoNumbers()
        {
            var result = calc.Evaluate("5 * 5");
            Assert.AreEqual(25m, result.Result);
        }

        [TestMethod]
        public void DivideTwoNumbers()
        {
            var result = calc.Evaluate("20 / 40");
            Assert.AreEqual(0.5m, result.Result);
        }

        [TestMethod]
        public void ValidateOperator()
        {
            var result = calc.Evaluate("7 plus 7");
            Assert.AreEqual("The operation 'plus' is invalid. You must use one of the following: + - * /", result.ErrorMessage);
        }

        [TestMethod]
        public void ValidateFormat()
        {
            var result = calc.Evaluate("7 +");
            Assert.AreEqual("An operation must be in the form '5 + 8'  or '+ 8' if continuing from a previous value. Please try again.", result.ErrorMessage);
        }

        [TestMethod]
        public void ContinueOperations()
        {
            calc.Evaluate("5 + 5");
            var result = calc.Evaluate("+ 5");
            Assert.AreEqual(15m, result.Result);
        }
    }
}
