using System.Collections.Generic;
using System;
namespace SDAM2
{
    class LogManager
    {
        public List<string> logs { get;} = new List<string>();
        public LogManager()
        { }
        public void addLog(String origin, String type, String stockCode, int volume, Decimal price, String bankName, DateTime timeStamp)
        { }
    }
}