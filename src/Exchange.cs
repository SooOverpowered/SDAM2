using System;
namespace SDAM2
{
    class Exchange
    {
        public StockManager stockManager { get; set; } = new StockManager();
        public BankManager bankManager { get; set; } = new BankManager();
        public Exchange()
        {

        }
    }
}