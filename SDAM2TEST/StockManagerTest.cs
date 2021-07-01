using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDAM2;

namespace SDAM2TEST
{
    [TestClass]
    public class StockManagerTest
    {
        [TestMethod]
        public void addStockTest()
        {
            StockManager stockManager = new StockManager();
            stockManager.addStock("A", 10m, 100);
            Assert.AreEqual(stockManager.StockList.Count(), 1);
            Assert.AreEqual(stockManager.StockList.First().stockCode, "A");
            Assert.AreEqual(stockManager.StockList.First().price, 10m);
            Assert.AreEqual(stockManager.StockList.First().volume, 100);
            stockManager.addStock("A", 12m, 100);
            Assert.AreEqual(stockManager.StockList.Count(), 2);
            Assert.AreEqual(stockManager.StockList[1].stockCode, "A");
            Assert.AreEqual(stockManager.StockList[1].price, 12m);
            Assert.AreEqual(stockManager.StockList[1].volume, 100);
            stockManager.addStock("A", 10m, 200);
            Assert.AreEqual(stockManager.StockList.Count(), 2);
            Assert.AreEqual(stockManager.StockList.First().volume, 300);
        }
    }
}
