using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDAM2;

namespace SDAM2TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Bank bank1 = new Bank("bank1");
            string expected = "bank1";
            string actual = bank1.name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        { }
    }
}
