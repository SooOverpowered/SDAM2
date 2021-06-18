using System;

namespace SDAM2
{
    class Log
    {
        public String origin { get; set; }
        public String dest { get; set; }
        public String type { get; set; }
        public String stockCode { get; set; }
        public int volume { get; set; }
        public Decimal price { get; set; }
        public DateTime timeStamp { get; set; }
        public Log(String origin, String dest, String type, String stockCode, int volume, Decimal price, DateTime timeStamp)
        {
            this.origin = origin;
            this.dest = dest;
            this.type = type;
            this.stockCode = stockCode;
            this.volume = volume;
            this.price = price;
            this.timeStamp = timeStamp;
        }
    }
}