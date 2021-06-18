using System.Collections.Generic;
using System;
using System.IO;
namespace SDAM2
{
    class LogManager
    {
        public List<Log> logs { get; set; } = new List<Log>();
        public LogManager()
        { }
        public void addLog(String origin, String dest, String type, String stockCode, int volume, Decimal price, DateTime timeStamp)
        {
            logs.Add(new Log(origin, dest, type, stockCode, volume, price, timeStamp));
        }
    }
}
