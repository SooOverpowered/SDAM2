using System;
using System.Collections.Generic;
using System.Linq;
namespace SDAM2
{
    class StockManager
    {
        public List<Stock> StockList { get; set; } = new List<Stock>();
        public int StockCount { get; set; } = 0;
        public StockManager()
        {

        }
        public void addStock(Stock stock)
        {
            StockList.Add(stock);
            if ((from s in StockList where s.stockCode == stock.stockCode select s).Count()==0)
            {
                StockCount+=1;
            }
        }
        public List<Stock> getStock(String stockCode)
        {
            return new List<Stock>(from s in StockList where s.stockCode==stockCode orderby s.price select s);
        }
    }
}