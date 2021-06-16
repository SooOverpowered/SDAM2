using System.Collections.Generic;
using System;
using System.IO;
namespace SDAM2
{
    class LogManager
    {
        public List<string> logs { get; set; } = new List<string>();
        public LogManager()
        { }
        public void addLog(String origin, String type, String stockCode, int volume, Decimal price, DateTime timeStamp, String bankName = "")
        {
            if (bankName != "")
            {
                File.AppendAllText("log.txt", $"{origin}-{bankName}@{timeStamp}: {type} {volume} {stockCode} at {price}");
            }
            else
            {
                File.AppendAllText("log.txt", $"{origin}@{timeStamp}: {type} {volume} {stockCode} at {price}");
            }

        }
    }
}