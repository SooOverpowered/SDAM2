using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SDAM2;

namespace SDAM2TEST
{
    [TestClass]
    public class StockTest
    {
        [TestMethod]
        public void StockCodeTest()
        {
            Stock stock = new Stock("Code1", 1.5m, 1);
            string expected = "Code1";
            string actual = stock.stockCode;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StockPriceTest()
        {
            Stock stock = new Stock("Code1", 1.5m, 1);
            decimal expected = 1.5m;
            decimal actual = stock.price;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StockVolumeTest()
        {
            Stock stock = new Stock("Code1", 1.5m, 1);
            int expected = 1;
            int actual = stock.volume;
            Assert.AreEqual(expected, actual);
        }
    }
}