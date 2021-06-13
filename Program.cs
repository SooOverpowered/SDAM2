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
            // Create a new exchange (add json save later)
            Exchange exchange = new Exchange();
            //  Login check
            Login(exchange.bankManager);
            // Main Menu
            MainMenu(exchange);

        }
        static void Login(BankManager bankManager) //Login
        {
            // Ask for bank name repeatedly until a correct name is provided
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(new string('#', 100)); //For design purpose only
                Console.Write("Please enter your bank name (Leave blank if you are unregistered): "); //Ask for bank name
                String bankName = Console.ReadLine();
                if (bankManager.getBank(bankName).name == bankName) // Bank name exist
                {
                    Console.WriteLine("Authenticated");
                    flag = false; //Exit loop
                }
                else if (bankName == "") //Bank name empty, prompts user to signup
                {
                    SignUp(bankManager);
                }
                else //Bank name does not exist
                {
                    Console.WriteLine("The name you entered does not match any registered bank");
                }
            }
        }
        static void SignUp(BankManager bankManager)
        {
            Console.WriteLine(new string('#', 100));
            Console.Write("Please enter your bank name : ");
            String bankName = Console.ReadLine();
            bool flag = true;
            while (flag)
            {
                if (bankManager.getBank(bankName).name == bankName)
                {
                    Console.WriteLine("Bank already exist, please try another name");
                }
                else if (bankName == "")
                {
                    Console.WriteLine("Bank name cannot be empty");
                }
                else
                {
                    bankManager.addBank(bankName);
                    flag = false;
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


