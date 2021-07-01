using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDAM2;

namespace SDAM2TEST
{
    [TestClass]
    public class ExchangeTest
    {
        [TestMethod]
        public void exchange_has_stock_manager()
        {
            Exchange exchange = new Exchange();
            Assert.IsInstanceOfType(exchange.stockManager, typeof(StockManager));
        }

        [TestMethod]
        public void exchange_stock_manager_empty()
        {
            Exchange exchange = new Exchange();
            Assert.AreEqual(exchange.stockManager.StockList.Count(), 0);
        }

        [TestMethod]
        public void exchange_has_bank_manager()
        {
            Exchange exchange = new Exchange();
            Assert.IsInstanceOfType(exchange.bankManager, typeof(BankManager));
        }

        [TestMethod]
        public void exchange_bank_manager_empty()
        {
            Exchange exchange = new Exchange();
            Assert.AreEqual(exchange.bankManager.BankList.Count(), 0);
        }

        [TestMethod]
        public void exchange_has_log_manager()
        {
            Exchange exchange = new Exchange();
            Assert.IsInstanceOfType(exchange.logManager, typeof(LogManager));
        }

        [TestMethod]
        public void exchange_log_manager_empty()
        {
            Exchange exchange = new Exchange();
            Assert.AreEqual(exchange.logManager.LogList.Count(), 0);
        }
    }
}
