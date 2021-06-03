using System;
using System.Text.Json;
using System.Linq;

namespace SDAM2
{
    class Program
    {
        static void Main()
        {
            InitializeProgram();
        }
        static void InitializeProgram()
        {
            Exchange exchange = new Exchange();
            Login(exchange.bankManager);
            MainMenu(exchange);

        }
        static void Login(BankManager bankManager)
        {
            bool flag = true;
            while (flag)
            {
                Console.Write("Please enter you bank name");
                String bankName = Console.ReadLine();
                if ((from bank in bankManager.BankList where bank.name == bankName select bank).Count() == 1)
                {
                    Console.Write("Authenticated");
                    flag = false;
                }
                else
                {
                    Console.Write("Bank has not been signed up with the Exchange");
                }
            }
        }
        static void MainMenu(Exchange exchange)
        {
            const int EXIT = 0;
            const int START = 1;
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.WriteLine("Please choose an option");
                    int choice = Convert.ToInt16(Console.Read());
                    switch (choice)
                    {
                        case START:
                            break;
                        case EXIT:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Please choose from the listed options");
                            break;

                    }
                }
                catch
                {
                    Console.Write("Please choose from the listed options");
                }
            }
        }
    }
}


