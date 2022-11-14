using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcLibraryForTests;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(10, 7)]
        [DataRow(13, 53)]
        public void TestSum(int a, int b)
        {
            var expResult = a + b;

            var result = ClassOfCalcLibrary.Sum(a, b);

            Assert.AreEqual(result, expResult);
        }

        [TestMethod]
        [DataRow(13, 4)]
        [DataRow(4234, 5423)]
        public void TestMinus(int a, int b)
        {
            var expResult = a - b;

            var result = ClassOfCalcLibrary.Minus(a, b);

            Assert.AreEqual(result, expResult);
        }

        [TestMethod]
        [DataRow(8, 4)]
        [DataRow(5532, 135)]
        public void TestMultiple(int a, int b)
        {
            var expResult = a * b;

            var result = ClassOfCalcLibrary.Multiple(a, b);

            Assert.AreEqual(result, expResult);
        }

        [TestMethod]
        [DataRow(10, 2)]
        [DataRow(4224, 8954)]
        public void TestDivide(int a, int b)
        {
            var expResult = a / b;

            var result = ClassOfCalcLibrary.Devide(a, b);

            Assert.AreEqual(result, expResult);
        }

        [TestMethod]
        [DataRow(10, 0)]
        [DataRow(14248, 0)]
        [ExpectedException(typeof(DivideByZeroException), "Oh my god, we can't divison on zero :(")]
        public void TestDivideByZero(int a, int b)
        {
           var result = ClassOfCalcLibrary.Devide(a, b);            
        }

        /*[TestMethod]
        [DataRow(2147483648, 2)]
        [ExpectedException(typeof(ArgumentException), "Object of type 'System.UInt32' cannot be converted to type 'System.Int32'.")]
        public void HandlingExceptionForExceedingInt(int a, int b)
        {
           
        }
        */
    }
}