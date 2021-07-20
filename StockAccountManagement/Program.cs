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
        ///    Reliance --     40.rs
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            StockAccount stockAccount = new StockAccount();
            stockAccount.GetStockDetails();
        }
    }
}
