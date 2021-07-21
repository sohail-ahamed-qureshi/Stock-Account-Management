using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockAccountManagement
{
    class StockAccountManagement
    {
        string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\Stock Account Management\Stock-Account-Management\StockAccountManagement\StockAccountData.json";
        List<Stock> stocks;
        public void GetStockDetails()
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string stockData = File.ReadAllText(filepath);
                    Root root = JsonConvert.DeserializeObject<Root>(stockData);
                    stocks = root.StockAccount;
                    foreach (Stock stock in stocks)
                    {
                        Console.WriteLine($"Stock Name: {stock.Stockname}\n Symbol: {stock.Symbol}\n Number of Stocks: {stock.Numberofstocks}\n Stock Price: {stock.Stockprice}");
                    }
                }
                else
                {
                    Console.WriteLine("File not found!!");
                    throw new Exception();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Stock Buy(string symbol, double price)
        {
            if(price > 0)
            {
                foreach (Stock stock in stocks)
                {
                    if (stock.Symbol.Contains(symbol) && stock.Numberofstocks >= 1)
                    {
                        int buyStocks = (int)(price /stock.Stockprice);
                        stock.Numberofstocks -= buyStocks;
                        Console.WriteLine("Buy SuccessFull");
                        Console.WriteLine($"Stock Name: {stock.Stockname}\n Symbol: {stock.Symbol}\n Number of Stocks: {stock.Numberofstocks}\n Stock Price: {stock.Stockprice}");
                        return new Stock() { Stockname = stock.Stockname, Symbol = stock.Symbol, Numberofstocks = buyStocks, Stockprice = stock.Stockprice };
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid price!!");
            }
            return null;
        }

        public StockPortfolio Sell(string symbol, double price, StockPortfolio portfolio)
        {
            if(portfolio.stocksList.Count >= 1 && price >=0)
            {
                foreach(Stock stock in portfolio.stocksList)
                {
                    if (stock.Symbol.Contains(symbol) && stock.Numberofstocks >=1 )
                    {
                        int sellStocks = (int)price / stock.Stockprice;
                        stock.Numberofstocks -= sellStocks;
                        portfolio.cash += price;
                        UpdateStockAccount(sellStocks, symbol);
                        Console.WriteLine("Sell Successfull");
                        return portfolio;
                    }
                }
            }
            else
            {
                Console.WriteLine("No Available stocks to sell!!");
            }
            return null;
        }

        private void UpdateStockAccount(int sellStocks, string symbol)
        {
            foreach (Stock stock in stocks)
            {
                if (stock.Symbol.Contains(symbol))
                {
                    stock.Numberofstocks += sellStocks;
                }
            }
        }
    }
}
