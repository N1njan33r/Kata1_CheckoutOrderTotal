using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutOrderTotal.UnitTest
{
    [TestClass]
    public class TestTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new Test();

            var result = test.TestString();

            Assert.AreEqual("1", result);
        }
    }
}
