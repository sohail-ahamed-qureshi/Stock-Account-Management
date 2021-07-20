using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockAccountManagement
{
    /// <summary>
    /// model class of Stock account
    /// </summary>
    public class Stock
    {
        [JsonProperty("stockname")]
        public string Stockname { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("stockprice")]
        public int Stockprice { get; set; }
        [JsonProperty("numberofstocks")]
        public int Numberofstocks { get; set; }
    }
    /// <summary>
    /// class to read the list of stocks from the file
    /// </summary>
    public class Root
    {
        [JsonProperty("stock account")]
       public List<Stock> StockAccount { get; set; }
    }
}
