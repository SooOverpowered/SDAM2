using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SDAM2;

namespace SDAM2TEST
{
    [TestClass]
    public class BankManagerTest
    {
        [TestMethod]
        public void addBankTest()
        {
            BankManager bankmanager = new BankManager();
            bankmanager.addBank("bank1");
            string expected = "bank1";
            string actual = bankmanager.BankList.First().name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getBankTest()
        {
            BankManager bankmanager = new BankManager();
            bankmanager.addBank("bank1");
            Bank expected = bankmanager.BankList.First();
            Bank actual = bankmanager.getBank("bank1").First();
            Assert.AreEqual(expected, actual);
        }
    }
}