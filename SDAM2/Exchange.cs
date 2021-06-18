using System;
namespace SDAM2
{
    public class Exchange
    {
        public StockManager stockManager { get; set; } = new StockManager();
        public BankManager bankManager { get; set; } = new BankManager();
        public LogManager logManager {get;set;} = new LogManager();
        public Exchange()
        {

        }
    }
}