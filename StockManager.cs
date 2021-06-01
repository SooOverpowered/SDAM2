using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
namespace SDAM2
{
    class StockManager
    {
        List<Stock> StockList { get; } = new List<Stock>();
        public StockManager()
        {
            
        }
    }
}