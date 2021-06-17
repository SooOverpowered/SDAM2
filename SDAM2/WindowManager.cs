using System;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace SDAM2
{
    public class WindowManager
    {
        public WindowManager()
        { }
        public void Initialize()
        {
            Exchange exchange;
            // check if json data exist, if not then instantiate a new exchange
            if (File.Exists("jsonsaved.json"))
            {
                String jsonstring = File.ReadAllText("jsonsaved.json");
                exchange = JsonSerializer.Deserialize<Exchange>(jsonstring);
            }
            else
            {
                exchange = new Exchange();
            }

            // TEST DATA
            Stock stock1 = new Stock("AAPL", 15.25m, 10000);
            Stock stock2 = new Stock("AAPL", 14.00m, 10000);
            Stock stock3 = new Stock("BAPL", 13.25m, 10000);
            exchange.stockManager.addStock(stock1);
            exchange.stockManager.addStock(stock2);
            exchange.stockManager.addStock(stock3);
            //


            //  Login check
            Login(exchange);
            // Main Menu
            MainMenu(exchange);

        }
        static void SaveData(Exchange exchange)
        {
            string jsonstring = JsonSerializer.Serialize<Exchange>(exchange);
            File.WriteAllText("jsonsaved.json", jsonstring);
        }
        static void Login(Exchange exchange) //Login
        {
            // Ask for bank name repeatedly until a correct name is provided
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------Log In------------"); //For design purpose only
                Console.Write("Please enter your bank name (Leave blank if you are unregistered): "); //Ask for bank name
                String bankName = Console.ReadLine();
                if (bankName == "") //Bank name empty, prompts user to signup
                {
                    SignUp(exchange);
                }
                else if ((from bank in exchange.bankManager.BankList where bank.name == bankName select bank).Count() == 1) // Bank name exist
                {
                    Console.WriteLine("Authenticated");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;//Exit loop
                }
                else
                {
                    Console.WriteLine("The name you entered does not match any registered bank");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

            }
        }
        static void SignUp(Exchange exchange)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------Sign Up------------");
                Console.Write("Please enter your bank name : ");
                String bankName = Console.ReadLine();
                if (bankName == "") // Bank name empty
                {
                    Console.WriteLine("Bank name cannot be empty");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else if ((from bank in exchange.bankManager.BankList where bank.name == bankName select bank).Count() == 1) // Bank name exist
                {
                    Console.WriteLine("Bank already exist, please try another name");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    exchange.bankManager.addBank(bankName);
                    SaveData(exchange);
                    Console.WriteLine($"Signed up under {bankName} successfully");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void MainMenu(Exchange exchange)
        {
            const int EXIT = 0;
            const int BUY = 1;
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("-----------MAIN MENU----------");
                Console.WriteLine("1. Trade");
                Console.WriteLine("2. Your Asset");
                Console.WriteLine("3. Transaction Log");
                Console.WriteLine("4. Financial Report");
                Console.WriteLine("0. EXIT PROGRAM");
                Console.WriteLine(new string('-', 29));
                Console.Write("Please choose an option: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case BUY:
                        StockExchangeMenu(exchange);
                        break;
                    case EXIT:
                        string jsonstring = JsonSerializer.Serialize<Exchange>(exchange);
                        File.WriteAllText("jsonsaved.json", jsonstring);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Please choose from the listed options");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void StockExchangeMenu(Exchange exchange)
        {
            const int EXIT = 0;
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("----------TRADE MENU----------");
                Console.WriteLine("\n0. BACK\n");
                Console.WriteLine("----------STOCK CODES---------");
                int count = 1;
                List<String> stockcodes = new List<String>((from stock in exchange.stockManager.StockList orderby stock.stockCode select stock.stockCode).Distinct());
                foreach (String s in stockcodes)
                {
                    Console.WriteLine($"{count}. {s}");
                    count += 1;
                }
                Console.Write("\nPlease choose a stock code: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                if (choice < 0 ^ choice > count)
                {
                    Console.WriteLine("Please choose from the listed options");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    switch (choice)
                    {
                        case EXIT:
                            flag = false;
                            break;
                        default:
                            ExchangeMenu(exchange, stockcodes[choice - 1]);
                            break;
                    }
                }
            }
        }
        static void ExchangeMenu(Exchange exchange, String stockCode)
        {
            const int EXIT = 0;
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("----------TRADE MENU----------");
                Console.WriteLine("\n0. BACK\n");
                Console.WriteLine("1. BUY");
                Console.WriteLine("2. QUOTE");
                Console.WriteLine("----------STOCK LIST----------");
                List<Stock> stocks = exchange.stockManager.getStock(stockCode);
                Console.WriteLine("{0,-8}{1,8}{2,12}", "Name", "Price", "Volume");
                Console.WriteLine("{0,-8}{1,8}{2,12}", "----", "-----", "------");
                foreach (Stock s in stocks.GetRange(0, 10))
                {
                    Console.WriteLine("{0, -8}{1,8:C2}{2,12}", s.stockCode, s.price, s.volume);
                }
                Console.Write("\nPlease choose a stock code: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case EXIT:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}