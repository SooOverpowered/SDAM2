using System;

namespace SDAM2
{
    class Bank
    {
        public String name { get; set; }
        public StockManager stockManager { get; set; } = new StockManager();
        public Bank(String name)
        {
            this.name = name;
        }
    }
}