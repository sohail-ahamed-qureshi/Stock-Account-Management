using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockAccountManagement
{

    class Wrapper
    {
        public DemoStockAccount demoStock { get; set; }

        public void GetDataDemo()
        {
            //string filepath = @"C:\Users\Admin\Desktop\BridgeLabs Assignments\Stock Account Management\Stock-Account-Management\StockAccountManagement\StockAccountData.json";

            string output = @"{
  ""stock account"": [
    {
                ""stockname"": ""IntrBM"",
      ""symbol"": ""IBM"",
      ""numberofstocks"": 100,
      ""stockprice"": 20
    },
    {
                ""stockname"": ""Reliance"",
      ""symbol"": ""RIL"",
      ""numberofstocks"": 1000,
      ""stockprice"": 40
    },
    {
                ""stockname"": ""AB Company"",
      ""symbol"": ""ABC"",
       ""numberofstocks"": 50,
      ""stockprice"": 30
    },
    {
                ""stockname"": ""Tata CS"",
      ""symbol"": ""TCS"",
       ""numberofstocks"": 1000,
      ""stockprice"": 50
    },
    {
                ""stockname"": ""Infosys"",
      ""symbol"": ""INFY"",
       ""numberofstocks"": 500,
      ""stockprice"": 40
    }
  ]
}";
            using (StreamReader sr = new StreamReader(output))
            {
                string jsonString = sr.ReadToEnd();
                var valueSet = JsonConvert.DeserializeObject<Wrapper>(jsonString).demoStock;

                foreach (KeyValuePair<string, Values> item in valueSet.ValuesD)
                {
                    Console.WriteLine(item.Key);
                    Console.WriteLine(item.Value.stockname);

                }
            }

        }
    }
    class DemoStockAccount
    {
        public Dictionary<string, Values> ValuesD { get; set; }
    }

    class Values
    {
        public string stockname { get; set; }
        public string symbol { get; set; }
        public int stockprice { get; set; }
        public int numberofstocks { get; set; }
    }
}
