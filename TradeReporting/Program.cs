using System;
using System.Collections.Generic;
using TradeReporting.Properties;

namespace TradeReporting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] inputItems;
        
            // Ensure we have exactly 3 items
            do
            {
                Console.WriteLine("Please enter your trade with asset type, broker name, trade date in yyyy/MM/dd, each separated by a ,");
                string inputLine = Console.ReadLine();

                inputItems = inputLine.Split(',');
            } while (inputItems.Length != 3);
            
            /*
             * TODO: Do some try catch here using static methods
             */
            
            // Trim whitespace and assign to variables
            string assetType = inputItems[0].Trim();
            string brokerName = inputItems[1].Trim();
            string tradeDate = inputItems[2].Trim(); //2024/04/13 OR 2024/02/13 for now, needs better handling
            DateTime parsedTradeDate = DateTime.ParseExact(tradeDate, "yyyy/MM/dd", null);
            
            Console.WriteLine("Successfully read.");

            //TODO: Replace below with a more intelligent mapping tool to hide implementation details and use factory directly
            EquityCLSA equityCLSA1 = new EquityCLSA(assetType, brokerName, parsedTradeDate); // For testing
            EquityCLSA equityCLSA2 = new EquityCLSA(assetType, brokerName, new DateTime(2024, 2, 17)); // For testing
            EquityCLSA equityCLSA3 = new EquityCLSA(assetType, brokerName, new DateTime(2024, 1, 1)); // For testing

            TradeReportGenerator.AddIBrokerTrade(equityCLSA1);
            TradeReportGenerator.AddIBrokerTrade(equityCLSA2);
            TradeReportGenerator.AddIBrokerTrade(equityCLSA3);

            TradeReportGenerator.CreateTradeReport();
        }
    }
}