using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockAccountManagement
{

    public class StockAccount
    {

        string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\Stock Account Management\Stock-Account-Management\StockAccountManagement\StockAccountData.json";

        public void GetStockDetails()
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string stockData = File.ReadAllText(filepath);
                    Root root = JsonConvert.DeserializeObject<Root>(stockData);
                    List<Stock> stocks = root.StockAccount;
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

