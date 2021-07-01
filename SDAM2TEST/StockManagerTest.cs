using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SDAM2;

namespace SDAM2TEST
{
    [TestClass]
    public class StockManagerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            StockManager stockmanager = new StockManager();
            stockmanager.addStock("Code1", 1.5m, 1);
            Stock expected = stockmanager.StockList.First();
            Stock actual = stockmanager.getStock("Code1").First();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            StockManager stockmanager = new StockManager();
            stockmanager.addStock("Code1", 1.5m, 1);
            Stock expected = stockmanager.StockList.First();
            Stock actual = stockmanager.getStock("Code1", 1.5m).First();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            StockManager stockmanager = new StockManager();
            stockmanager.addStock("Code1", 1.5m, 1);
            Stock expected = stockmanager.StockList.First();
            Stock actual = stockmanager.getStockFromVolume("Code1", 1).First();
            Assert.AreEqual(expected, actual);
        }
    }
}