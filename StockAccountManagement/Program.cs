using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace StockAccountManagement
{
    class Program
    {
        /// <summary>
        /// Stock Name       Stock Price
        ///    ABC      --     30.rs
        ///    IBM      --     20.rs
        ///    Infosys  --     100.rs
        ///    TCS      --     50.rs
        ///    Reliance --     40.r
        /// </summary> 
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            StockAccountManagement management = new StockAccountManagement();
            management.GetStockDetails();
            StockPortfolio portfolio = new StockPortfolio("Sohail", 123, 500);

            Console.WriteLine("Enter the symbol: ");
            string stockSymbol = Console.ReadLine();
            Console.WriteLine("Enter the price: ");
            double price = Convert.ToInt64(Console.ReadLine());

            Stock stock = management.Buy(stockSymbol, price);
            portfolio.cash -= price;
            portfolio.stocksList.Add(stock);
            portfolio.DisplayPortfolio();

            portfolio = management.Sell("ABC", 30, portfolio);
            portfolio.DisplayPortfolio();




        }
    }
}
