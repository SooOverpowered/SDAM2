using System.Security.Principal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDAM2
{
    class BankManager
    {
        public List<Bank> BankList { get; set; } = new List<Bank>();
        public BankManager()
        { }
        public void addBank(string Name)
        {
            Bank bank = new Bank(Name);
            BankList.Add(bank);
        }
        public Bank getBank(string Name)
        {
            return (from bank in BankList where bank.name == Name select bank).First();

        }
    }
}
