using System;
namespace SDAM2
{
    public class Stock
    {
        public String stockCode { get; set; }
        public Decimal price { get; set; }
        public int volume { get; set; }
        public Stock(String stockCode, Decimal price, int volume)
        {
            this.stockCode = stockCode;
            this.price = price;
            this.volume = volume;
        }
    }
}