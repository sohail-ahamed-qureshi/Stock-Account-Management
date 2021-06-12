using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockAccountManagement
{
    interface IStockAccount
    {
        double ValueOf();
        void Buy(int amount, String symbol);
        void Sell(int amount, String symbol);
        void Save(String filename);
        void PrintReport();

    }
    class StockAccount
    {
        string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\Stock Account Management\Stock-Account-Management\StockAccountManagement\StockAccountData.json";
        private string filename;
        //public StockAccount(string filename)
        //{
        //    this.filename = filename;
        //}

        public void Buy(int amount, string symbol)
        {
            var jsonOutput = File.ReadAllText(filepath);
            var jObject = JObject.Parse(jsonOutput);
            var stockArray = (JArray)jObject["stock account"];

            if (jObject != null)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Stock Report~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
                Console.WriteLine("Stock Name     Symbol  Number of Shares   Share Price $ ");
                foreach (var item in stockArray)
                {
                   bool stockFound = SearchStock(item["symbol"], symbol);
                    if(stockFound == true)
                    {
                        Console.WriteLine($"  {item["stockname"]}\t{item["symbol"]}  \t{item["numberofstocks"]}\t\t\t${item["stockprice"]}");
                        Console.WriteLine($"press 'Y' to confirm stock(s) Buy of ${amount}. ");
                        Console.WriteLine("press 'N' to cancel. ");
                        char inp = Convert.ToChar(Console.ReadLine());
                        char input = Char.ToUpper(inp);
                        if(input == 'Y')
                        {
                            //allot stocks of ${amount} and deduct stocks in numberofShares.
                          float sharesAlloted =  AllotStock( amount, item["stockprice"]);
                            Console.WriteLine("Transaction Successful!!");
                            Console.WriteLine($"you're alloted, {sharesAlloted} shares of {item["stockname"]}");

                        }
                        if(input == 'N')
                        {
                            break;
                        }
                    }

                }
            }
        }

        internal float AllotStock(int amount, JToken stockPrice)
        {
            float stocks = 0;
            int convstockPrice = stockPrice.ToObject<int>();
            
            try
            {
                if (convstockPrice != 0)
                {
                    stocks = amount / convstockPrice;
                    return stocks;
                }
                else
                {
                    Console.WriteLine("stock price is 0. Can't perform transactions.");
                    return stocks;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return stocks;
        }

        internal bool SearchStock(JToken stockSymbol, string symbol)
        {
            string convSymbol = stockSymbol.ToObject<string>();
            if (convSymbol.Equals(symbol))
                return true;
            else
                return false;
        } 
    }
}
