using System;
using System.Collections.Generic;
using System.Text;

namespace StockAccountManagement
{
    class StockPortfolio
    {
        public string accountHolder { get; set; }
        public int id { get; set; }
        public double cash { get; set; }
        public List<Stock> stocksList;
        public StockPortfolio(string accountHolder, int id, double cash)
        {
            this.accountHolder = accountHolder;
            this.id = id;
            this.cash = cash;
            stocksList = new List<Stock>();
        }

        public void DisplayPortfolio()
        {
            Console.WriteLine($" Account Holder:{ accountHolder }\n Id: {id}\n Availble Cash: {cash}");
            Console.WriteLine("List of Stocks: ");
            foreach (Stock stock in stocksList)
            {
                Console.WriteLine($"Stock Name: {stock.Stockname}\n Symbol: {stock.Symbol}\n Number of Stocks: {stock.Numberofstocks}\n Stock Price: {stock.Stockprice}");
            }
        }
    }
}
