using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Calc.Tests
{
    [TestClass]
    public class CalcTest
    {
        Core.Calc calc = new Core.Calc();

        [TestMethod]
        public void TestSumInt()
        {
            // arange
            var sum = 10;

            // act
            var result = calc.Sum(new[] { 5, 3, 2 });

            // assert
            Assert.AreEqual(sum, result);
        }

        [TestMethod]
        public void TestSumDouble()
        {
            // arange
            var sum = 11.4;

            // act
            var result = (double)calc.Sum(new[] { 5.5, 3.1, 2.8 });

            // assert
            Assert.AreEqual(sum, result);
        }

        [TestMethod]
        public void TestRasInt()
        {
            // arange
            var ras = -13;

            // act
            var result = (int)calc.Ras(new[] { 4, 8, 9 });

            // assert
            Assert.AreEqual(ras, result);
        }

        [TestMethod]
        public void TestRasDouble()
        {
            // arange
            var ras = -15.2;

            // act
            var result = (double)calc.Ras(new[] { 3.2, 8.5, 9.9 });

            // assert
            Assert.AreEqual(ras, result);
        }

        [TestMethod]
        public void TestPowInt()
        {
            // arange
            var pow = 262144;

            // act
            var result = (int)calc.Pow(new[] { 2, 3, 6 });

            // assert
            Assert.AreEqual(pow, result);
        }

        [TestMethod]
        public void TestPowDouble()
        {
            // arange
            var pow = 626932771.13720214;

            // act
            var result = (double)calc.Pow(new[] { 2.3, 3.8, 6.4 });

            // assert
            Assert.AreEqual(pow, result);
        }
    }
}
