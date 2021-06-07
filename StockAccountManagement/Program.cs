using System;
using System.Collections.Generic;

namespace StockAccountManagement
{
    class Program
    {
        /// <summary>
        /// hard coding stocks into class.
        ///         Stock market
        /// 
        /// Stock Name       Stock Price
        ///    ABC      --     30.rs
        ///    IBM      --     20.rs
        ///    Infosys  --     100.rs
        ///    TCS      --     50.rs
        ///    Reliance --     40.rs
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stock stock = new Stock
            {
                stockName = "IBM",
                numberOfStocks = 100,
                stockPrice = 20 
            };
            Stock stock1 = new Stock
            {
                stockName = "ABC",
                numberOfStocks = 50,
                stockPrice = 30
            };
            Stock stock2 = new Stock
            {
                stockName = "TCS",
                numberOfStocks = 1000,
                stockPrice = 50
            };
            Stock stock3 = new Stock
            {
                stockName = "Infosys",
                numberOfStocks = 500,
                stockPrice = 100
            };
            Stock stock4 = new Stock
            {
                stockName = "RIL",
                numberOfStocks = 1000,
                stockPrice = 40
            };
            Stock.stockList.Add(stock4);
            Stock.stockList.Add(stock);
            Stock.stockList.Add(stock1);
            Stock.stockList.Add(stock2);
            Stock.stockList.Add(stock3);
            stock.StockView();
            //Portfolio 
            StockPortfolio stockPortfolio = new StockPortfolio
            {
                StockHolder = "Sohail",
                portStockName = new string[5] { "IBM", "ABC", "TCS", "Infosys", "RIL" },
                portNumberOfShare = new int[5] { 10, 22, 34, 49, 55 },
                protStockPrice = new float[5] {stock.stockPrice, stock1.stockPrice,stock2.stockPrice,
                stock3.stockPrice,stock4.stockPrice}
            };
            StockPortfolio.stockPortfolioList.Add(stockPortfolio);
            stockPortfolio.PortFolioView();
        }
    }
}
