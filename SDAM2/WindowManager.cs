using System;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace SDAM2
{
    class WindowManager
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
            exchange.stockManager.addStock("AAPL", 15.25m, 10000);
            exchange.stockManager.addStock("AAPL", 14.00m, 10000);
            exchange.stockManager.addStock("BAPL", 13.25m, 10000);
            //


            //  Login check
            Bank user = Login(exchange);
            // Main Menu
            MainMenu(exchange, user);

        }
        static void SaveData(Exchange exchange)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonstring = JsonSerializer.Serialize<Exchange>(exchange, options);
            File.WriteAllText("jsonsaved.json", jsonstring);
        }
        static Bank Login(Exchange exchange) //Login
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
                else if (exchange.bankManager.getBank(bankName).Count() == 1) // Bank name exist
                {
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine("AUTHENTICATED");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    return exchange.bankManager.getBank(bankName).First();//Exit loop
                }
                else
                {
                    Console.WriteLine(new string('-', 30));
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
                Console.Write("Please enter your bank name (Leave blank to go back to login screen): ");
                String bankName = Console.ReadLine();
                if (bankName == "") // Bank name empty
                {
                    break;
                }
                else if (exchange.bankManager.getBank(bankName).Count() == 1) // Bank name exist
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
        static void MainMenu(Exchange exchange, Bank user)
        {
            const String EXIT = "0";
            const String TRADE = "1";
            const String ASSET = "2";
            const String INVOICE = "3";
            const String LOG = "4";
            const String REPORT = "5";
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("-----------MAIN MENU----------");
                Console.WriteLine("1. Trade");
                Console.WriteLine("2. Your Asset");
                Console.WriteLine("3. Your Invoice");
                Console.WriteLine("4. Transaction Log");
                Console.WriteLine("5. Financial Report");
                Console.WriteLine("0. EXIT PROGRAM");
                Console.WriteLine(new string('-', 30));
                Console.Write("Please choose an option: ");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case TRADE:
                        {
                            StockExchangeMenu(exchange, user);
                            break;
                        }
                    case ASSET:
                        {
                            DisplayAsset(exchange, user);
                            break;
                        }
                    case INVOICE:
                        {
                            DisplayInvoice(exchange, user);
                            break;
                        }
                    case LOG:
                        {
                            DisplayLog(exchange);
                            break;
                        }
                    case REPORT:
                        {
                            DisplayReport(exchange);
                            break;
                        }
                    case EXIT:
                        {
                            SaveData(exchange);
                            Console.Clear();
                            flag = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose from the listed options");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
        static void StockExchangeMenu(Exchange exchange, Bank user)
        {
            const String EXIT = "0";
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("----------TRADE MENU----------");
                Console.WriteLine("0. BACK");
                Console.WriteLine("----------STOCK CODES---------");
                Console.WriteLine("{0,-8}{1,8}", "Name", "Price");
                Console.WriteLine("{0,-8}{1,8}", "----", "-----");
                List<String> stockcodes = new List<String>((from stock in exchange.stockManager.StockList orderby stock.stockCode select stock.stockCode).Distinct());
                foreach (String s in stockcodes)
                {
                    Stock st = exchange.stockManager.getStock(s).First();
                    Console.WriteLine("{0, -8}{1,8:C2}", st.stockCode, st.price);
                }
                Console.WriteLine(new string('-', 30));
                Console.Write("\nChoose one of the menu option or enter stock name: ");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case EXIT:
                        {
                            SaveData(exchange);
                            flag = false;
                            break;
                        }
                    default:
                        {
                            if (stockcodes.Contains(choice))
                            {
                                ExchangeMenu(exchange, user, choice);
                            }
                            else
                            {
                                Console.WriteLine("Please choose from the listed options");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                            }
                            break;
                        }
                }
            }
        }
        static void ExchangeMenu(Exchange exchange, Bank user, String stockCode)
        {
            const String EXIT = "0";
            const String BUY = "1";
            const String QUOTE = "2";
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("----------TRADE MENU----------");
                Console.WriteLine("0. BACK\n");
                Console.WriteLine("1. BUY");
                Console.WriteLine("2. QUOTE");
                Console.WriteLine("----------STOCK LIST----------");
                Console.WriteLine("{0,-8}{1,8}{2,12}", "Name", "Price", "Volume");
                Console.WriteLine("{0,-8}{1,8}{2,12}", "----", "-----", "------");
                List<Stock> stocks = exchange.stockManager.getStock(stockCode);
                int count = 0;
                foreach (Stock s in stocks)
                {
                    Console.WriteLine("{0,-8}{1,8:C2}{2,12}", s.stockCode, s.price, s.volume);
                    count += 1;
                    if (count == 10)
                    {
                        break;
                    }
                }
                Console.WriteLine(new string('-', 30));
                Console.Write("\nPlease choose an option: ");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case EXIT:
                        {
                            SaveData(exchange);
                            flag = false;
                            break;
                        }
                    case BUY:
                        {
                            Console.Write("Please enter price: ");
                            decimal user_price = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Please enter volume: ");
                            int user_vol = Convert.ToInt32(Console.ReadLine());
                            exchange.logManager.addLog(user.name, "EXCH", "buy", stockCode, user_vol, user_price, DateTime.Now);
                            if (exchange.stockManager.getStock(stockCode, user_price).Count() == 1) //Stock with user_price exist
                            {
                                Stock avail_stock = exchange.stockManager.getStock(stockCode, user_price).First();
                                if (user_vol == 0) //Volume 0 means a quote
                                {
                                    Console.WriteLine($"Quote {avail_stock.volume} {avail_stock.stockCode} at ${avail_stock.price}");
                                    exchange.logManager.addLog("EXCH", user.name, "quote", avail_stock.stockCode, avail_stock.volume, avail_stock.price, DateTime.Now);
                                }
                                else if (avail_stock.volume >= user_vol) //Banks buy successful
                                {
                                    user.stockManager.addStock(stockCode, user_price, user_vol);
                                    Console.WriteLine($"Bought {user_vol} {stockCode} at ${user_price}");
                                    exchange.logManager.addLog("EXCH", user.name, "bought", stockCode, user_vol, user_price, DateTime.Now);
                                    SaveData(exchange);
                                }
                                else //not enough stock -> quote stock with enough volume and having best price
                                {
                                    //Send a quote
                                    Console.WriteLine($"Only {avail_stock.volume} {stockCode} available at ${user_price}");
                                    exchange.logManager.addLog("EXCH", user.name, "only", stockCode, avail_stock.volume, user_price, DateTime.Now);
                                    List<Stock> quoted = exchange.stockManager.getStockFromVolume(stockCode, user_vol);
                                    if (quoted.Count() == 0) //not stock with that volume available
                                    {
                                        Console.WriteLine("No stock available at that volume");
                                    }
                                    else //stock with sufficient volume available
                                    {
                                        Console.WriteLine($"Quote {quoted.First().volume} {quoted.First().stockCode} at ${quoted.First().price}");
                                        exchange.logManager.addLog("EXCH", user.name, "quote", stockCode, quoted.First().volume, quoted.First().price, DateTime.Now);
                                    }
                                }
                            }
                            else //Stock with user_price does not exist -> quote another price and volume
                            {
                                Console.WriteLine($"No {stockCode} stock available at {user_price}");
                                Console.WriteLine($"Quote {stocks.First().volume} {stockCode} at ${stocks.First().price}"); //Quote best price available
                                exchange.logManager.addLog("EXCH", user.name, "quote", stockCode, stocks.First().volume, stocks.First().price, DateTime.Now);
                            }
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    case QUOTE:
                        {
                            Console.Write("Please enter price: ");
                            decimal user_price = Convert.ToDecimal(Console.ReadLine());
                            if (exchange.stockManager.getStock(stockCode, user_price).Count() == 0)
                            {
                                Console.WriteLine($"No {stockCode} stock available at {user_price}");
                                Console.WriteLine($"Quote {stocks.First().volume} {stockCode} at ${stocks.First().price}");
                                exchange.logManager.addLog("EXCH", user.name, "quote", stockCode, stocks.First().volume, stocks.First().price, DateTime.Now);
                            }
                            else
                            {
                                Stock quoted = exchange.stockManager.getStock(stockCode, user_price).First();
                                Console.WriteLine($"Quote {quoted.volume} {quoted.stockCode} at ${quoted.price}");
                                exchange.logManager.addLog("EXCH", user.name, "quote", stockCode, quoted.volume, quoted.price, DateTime.Now);
                            }
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose from the listed options");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
        static void DisplayAsset(Exchange exchange, Bank user)
        {
            Console.Clear();
            Console.WriteLine("------------ASSETS------------");
            Console.WriteLine($"Asset of: {user.name}");
            Console.WriteLine(new string('-', 30));
            List<String> stockcodes = new List<String>((from stock in user.stockManager.StockList orderby stock.stockCode select stock.stockCode).Distinct());
            Console.WriteLine("{0,-4}{1,9}", "Name", "Volume");
            Console.WriteLine("{0,-4}{1,9}", "----", "------");
            foreach (String stock in stockcodes)
            {
                List<Stock> st = user.stockManager.getStock(stock);
                Console.WriteLine("{0,-4}{1,9}", stock, st.Sum(item => item.volume));
            }
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        static void DisplayInvoice(Exchange exchange, Bank user)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 26) + "INVOICE" + new string('-', 27));
            Console.WriteLine($"Invoice for: {user.name}");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("{0,-20}{1,8}{2,8}{3,9}{4,14}", "Date", "Name", "Price", "Volume", "Amount");
            Console.WriteLine("{0,-20}{1,8}{2,8}{3,9}{4,14}", new string('-', 20), "----", "-----", "------", new string('-', 12));
            List<Log> logs = exchange.logManager.getBankTransactions(user.name);
            Decimal total = 0m;
            foreach (Log log in logs)
            {
                total += log.price * log.volume;
                Console.WriteLine("{0,-20}{1,8}{2,8}{3,9}{4,14:C2}", log.timeStamp, log.stockCode, log.price, log.volume, log.price * log.volume);
            }
            Console.WriteLine("\n{0,-20}{1,-20:C2}", "Total (w/o fee):", total);
            Console.WriteLine("{0,-20}{1,-20:C2}", "Total (w/ fee):", total * 1.05m);
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        static void DisplayLog(Exchange exchange)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 35) + "LOG" + new string('-', 35));
            foreach (Log log in exchange.logManager.LogList)
            {
                Console.WriteLine("{0}->{1}@{2}: {3} {4} {5} at {6:C2}", log.origin, log.dest, log.timeStamp, log.type, log.volume, log.stockCode, log.price);
            }
            Console.WriteLine(new string('-', 73));
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        static void DisplayReport(Exchange exchange)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 27) + "EXCHANGE REPORT" + new string('-', 28));
            Console.WriteLine("{0,-8}{1,20}{2,20}{3,20}", "Bank", "Total Credit", "Processing Fee", "Total");
            Console.WriteLine("{0,-8}{1,20}{2,20}{3,20}", "--------", "------------", "--------------", "-------------");
            Decimal fees = 0m;
            foreach (Bank bank in exchange.bankManager.BankList)
            {
                Decimal total = 0m;
                foreach (Stock stock in bank.stockManager.StockList)
                {
                    total += stock.price * stock.volume;
                }
                fees += total * 0.05m;
                Console.WriteLine("{0,-8}{1,20:C2}{2,20:C2}{3,20:C2}", bank.name, total, total * 0.05m, total * 1.05m);
            }
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("{0:-20}{1,-20:C2}", "Total fees:", fees);
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}