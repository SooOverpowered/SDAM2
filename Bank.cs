using System;

namespace SDAM2
{
    class Bank
    {
        String name { get; set; }
        StockManager stockManager = new StockManager();
        public Bank(String name)
        {
            this.name = name;
        }
    }
}
