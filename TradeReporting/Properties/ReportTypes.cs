using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TradeReporting.Properties
{
internal class EquityCLSA: IBrokerTrade
    {
        private String AssetType { get; }
        private string BrokerName { get; }
        private DateTime TargetTradeDate { get; }
        public List<string> TradeRefs { get; private set; } // TODO: Hardcoded; should depend on RefreshBroker()
        public List<int> ProductIds { get; private set; } // TODO: Hardcoded; should depend on RefreshBroker()
        public List<string> ProductNames { get; private set; } // TODO: Hardcoded; should depend on RefreshBroker()
        public List<DateTime> TradeDates { get; private set; } // TODO: Hardcoded; should depend on RefreshBroker()
        public List<decimal> Qty { get; private set; } // TODO: Hardcoded; should depend on RefreshBroker()
        public List<string> BuySell { get; private set; } // TODO: Hardcoded; should depend on RefreshBroker()
        public List<decimal> Prices { get; private set; } // TODO: Hardcoded; should depend on RefreshBroker()
        private List<string> EquityType { get; set; } // TODO: Hardcoded; should depend on RefreshBroker()
        
        public EquityCLSA(String assetType, String brokerName, DateTime targetTradeDate)
        {
            AssetType = assetType; // Todo: Redundant for now
            BrokerName = brokerName; // Todo: Redundant for now
            TargetTradeDate = targetTradeDate;
            ((IBroker)this).EnvCheck();
            ((IBroker)this).RefreshBroker();
        }

        public void PrintHeader()
        {
            Console.WriteLine(string.Join(",", typeof(EquityCLSA).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(prop => prop.PropertyType.IsGenericType 
                               && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                .Select(prop => prop.Name)
                .ToList()));
        }
        
        public void PrintTrades()
        {
            List<bool> equalsList = TradeDates.Select(date => date == TargetTradeDate).ToList();
            List<string> tradeDatesToStr = TradeDates.Select(date => date.ToString("yyyy/MM/dd")).ToList();
            
            PrintArray(new []
            {
                TradeRefs.Where((item, index) => equalsList[index]).Cast<object>().ToList(),
                ProductIds.Where((item, index) => equalsList[index]).Cast<object>().ToList(),
                ProductNames.Where((item, index) => equalsList[index]).Cast<object>().ToList(),
                tradeDatesToStr.Where((item, index) => equalsList[index]).Cast<object>().ToList(),
                Qty.Where((item, index) => equalsList[index]).Cast<object>().ToList(),
                BuySell.Where((item, index) => equalsList[index]).Cast<object>().ToList(),
                Prices.Where((item, index) => equalsList[index]).Cast<object>().ToList(),
                EquityType.Where((item, index) => equalsList[index]).Cast<object>().ToList()
            });
        }
        
        private static void PrintArray(List<object>[] lists)
        {
            for (int i = 0; i < lists[0].Count; i++)
            {
                for (int j = 0; j < lists.Length; j++)
                {
                    // Print each element separated by a comma
                    if (i < lists[j].Count)
                    {
                        Console.Write(lists[j][i]);
                    }
                    if (j < lists.Length - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine(); // New line for the next row
            }
        }
        
        void IBroker.EnvCheck() // TODO: Make it secure
        {
            // TODO: For some internal security check before for CLSA
        }
        
        void IBroker.RefreshBroker() // TODO: Make it secure
        { 
            // TODO: Do something that refreshes db containing all trades related to this broker
            // Hardcode below pretending the above automatically populated them:
            TradeRefs = new List<string> { "EQTY_CLSA_1", "EQTY_CLSA_2", "EQTY_CLSA_3", "EQTY_CLSA_4", "EQTY_CLSA_5"};
            ProductIds = new List<int> { 1, 2, 3, 4, 5 };
            ProductNames = new List<string> { "KKR", "TXS", "XP", "AAPL", "XSC" };
            TradeDates = new List<DateTime> { new DateTime(2024, 2, 13), 
                new DateTime(2024, 2, 17), new DateTime(2024, 2, 13), 
                new DateTime(2024, 2, 17), new DateTime(2024, 4, 13)};
            Qty = new List<decimal> { 12313m, 4234235m, 123.2m, 63.6m, 23412m };
            BuySell = new List<string> { "B", "S", "B", "S", "B" };
            Prices = new List<decimal> { 1.22m, 2.345m, 342m, 432m, 12.3214m };
            EquityType = new List<string> { "Common", "Preferred", "Common", "Common", "Preferred" };
        }
    }
}