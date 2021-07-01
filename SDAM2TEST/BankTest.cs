using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SDAM2;

namespace SDAM2TEST
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void CreateBankTest()
        {
            Bank bank1 = new Bank("bank1");
            string expected = "bank1";
            string actual = bank1.name;
            Assert.AreEqual(expected, actual);
        }
    }
}