using System;
using System.Collections.Generic;
using System.Linq;
namespace SDAM2
{
    class StockManager
    {
        public List<Stock> StockList { get; set; } = new List<Stock>();
        public StockManager()
        {

        }
        public void addStock(String stockCode, decimal price, int volume)
        {
            if (getStock(stockCode).Count() == 0)
            {
                Stock temp_stock = new Stock(stockCode, price, volume);
                StockList.Add(temp_stock);
            }
            else if (getStock(stockCode, price).Count() == 0)
            {
                Stock temp_stock = new Stock(stockCode, price, volume);
                StockList.Add(temp_stock);
            }
            else
            {
                getStock(stockCode, price).First().volume += volume;
            }
        }
        public List<Stock> getStock(String stockCode)
        {
            return new List<Stock>(from s in StockList where s.stockCode == stockCode orderby s.price select s);
        }
        public List<Stock> getStock(String stockcode, decimal price)
        {
            return new List<Stock>(from s in StockList where s.stockCode == stockcode & s.price == price orderby s.price select s);
        }
        public List<Stock> getStockFromVolume(String stockcode, int volume)
        {
            return new List<Stock>(from s in StockList where s.stockCode == stockcode & s.volume >= volume orderby s.price select s);
        }
    }
}