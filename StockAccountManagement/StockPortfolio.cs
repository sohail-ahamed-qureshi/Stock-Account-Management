using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockAccountManagement
{
    class StockPortfolio
    {
        /// <summary>
        /// Managing Portfolio of person holding stocks of various companies
        /// </summary>
        public string StockHolder { get; set; }
        public string[] portStockName { get; set; }
        public int[] portNumberOfShare{ get; set; }
        public float[] protStockPrice { get; set; }

        public static List<StockPortfolio> stockPortfolioList = new List<StockPortfolio>();
        Stock stock = new Stock();
        /// <summary>
        /// view format for portfolio,
        /// calculating value of each stock and total value of stocks.
        /// </summary>
        public void PortFolioView()
        {
            try
            {
                int i = 0;
                float portValueOfStocks, portTotalValue = 0;
                Console.WriteLine();
                foreach (StockPortfolio sp in stockPortfolioList)
                {
                    Console.WriteLine("PortFolio of " + sp.StockHolder);
                    Console.WriteLine("Stock name\tNumber of Shares\tValue of Stocks(.Rs)");
                    while (i <= 4)
                    {
                        Console.WriteLine();
                        Console.Write(sp.portStockName[i] + "\t\t  ");
                        Console.Write(sp.portNumberOfShare[i] + "\t\t\t  ");
                        portValueOfStocks = stock.ValueOfStock(sp.protStockPrice[i], sp.portNumberOfShare[i]);
                        Console.WriteLine(portValueOfStocks);
                        portTotalValue += stock.TotalValue(portValueOfStocks);
                        i++;
                    }
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine($"Total Value(.Rs)\t\t\t  {portTotalValue} ");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        /// <summary>
        /// using streamwriter for writing details to file from list
        /// </summary>
        public void WriteFile()
        {
            //file path for writing and reading details
            string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\Stock Account Management\Stock-Account-Management\StockAccountManagement\bin\Debug\netcoreapp3.1\Sohail.txt";

            using StreamWriter streamWriter = new StreamWriter(filepath);
            streamWriter.WriteLine(StockHolder);
            int i = 0;
            foreach (StockPortfolio st in stockPortfolioList)
            {
                while (i <= 4)
                {
                    streamWriter.WriteLine(st.portStockName[i] + "\t" + st.portNumberOfShare[i]);
                    i++;
                }
            }
        }
    }
}
