using System;
namespace SDAM2
{
    class Exchange
    {
        public StockManager stockManager {get;} = new StockManager();
        public BankManager bankManager {get;} = new BankManager();
        public Exchange()
        {

        }
    }
}