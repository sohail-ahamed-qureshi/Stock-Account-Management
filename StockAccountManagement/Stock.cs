using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockAccountManagement
{
    class Stock
    {
        /// <summary>
        /// Each Stock has properties like name, number od shares and share price.
        /// this stocks are stored in StockAccountData.json file.
        /// GetStockDetails() method is used to access the stock details inside the json file.
        /// </summary>
        public void GetStockDetails()
        {
            //variables
            int valueOfStock, totalValueOfStock=0;
            //json filepath
            string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\Stock Account Management\Stock-Account-Management\StockAccountManagement\StockAccountData.json";
            
            var jsonOutput = File.ReadAllText(filepath);
            var jObject = JObject.Parse(jsonOutput);
            var stockArray = (JArray)jObject["stock account"];
            try
            {
                if (jObject != null)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Stock Report~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine();
                    Console.WriteLine("Stock Name     Symbol  Number of Shares   Share Price $  Value of Stock $");
                    foreach (var item in stockArray)
                    {
                        valueOfStock = GetValueOfStock(item["numberofstocks"], item["stockprice"]);
                        totalValueOfStock += valueOfStock;
                        Console.WriteLine();
                        Console.WriteLine($"  {item["stockname"]}\t{item["symbol"]}  \t{item["numberofstocks"]}\t\t\t${item["stockprice"]}\t\t${valueOfStock}");
                    }
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine($"                                      Total Value of Stocks: ${totalValueOfStock}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Calculation of value of each stock from json file
        /// </summary>
        /// <param name="numOfShares"></param>
        /// <param name="stockPrice"></param>
        /// <returns></returns>
        internal int GetValueOfStock(JToken numOfShares, JToken stockPrice)
        {
            int convNumOfShares = numOfShares.ToObject<int>();
            int convStockPrice = stockPrice.ToObject<int>();
            int valueOfStock=0;
            try
            {
                valueOfStock = convNumOfShares * convStockPrice;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return valueOfStock;
        } 
    }
}
