using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDAM2;

namespace SDAM2TEST
{
    [TestClass]
    public class LogManagerTest
    {
        [TestMethod]
        public void addLogTest()
        {
            String date = "2009-05-08";
            LogManager logManager = new LogManager();
            logManager.addLog("A", "B", "C", "D", 10, 10m, DateTime.Parse(date));
            Log expected = new Log("A", "B", "C", "D", 10, 10m, DateTime.Parse(date));
            Log actual = logManager.LogList.First();
            Assert.AreEqual(expected.origin, actual.origin);
            Assert.AreEqual(expected.dest, actual.dest);
            Assert.AreEqual(expected.type, actual.type);
            Assert.AreEqual(expected.stockCode, actual.stockCode);
            Assert.AreEqual(expected.volume, expected.volume);
            Assert.AreEqual(expected.price, actual.price);
            Assert.AreEqual(expected.timeStamp, actual.timeStamp);
        }
        [TestMethod]
        public void getBankTransactionsTest()
        {
            String date = "2009-05-08";
            LogManager logManager = new LogManager();
            logManager.addLog("A", "B", "bought", "D", 10, 10m, DateTime.Parse(date));
            logManager.addLog("A", "B", "bought", "D", 10, 10m, DateTime.Parse(date));
            logManager.addLog("A", "B", "anything", "D", 10, 10m, DateTime.Parse(date));
            int expected = 2;
            Assert.AreEqual(logManager.getBankTransactions("B").Count(), expected);
        }
    }
}