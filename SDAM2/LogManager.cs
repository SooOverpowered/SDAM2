using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
namespace SDAM2
{
    public class LogManager
    {
        public List<Log> LogList { get; set; } = new List<Log>();
        public LogManager()
        { }
        public void addLog(String origin, String dest, String type, String stockCode, int volume, Decimal price, DateTime timeStamp)
        {
            LogList.Add(new Log(origin, dest, type, stockCode, volume, price, timeStamp));
        }
        public List<Log> getBankTransactions(String bankName)
        {
            return new List<Log>(from log in LogList where log.dest == bankName & log.type == "bought" orderby log.timeStamp select log);
        }
    }
}
