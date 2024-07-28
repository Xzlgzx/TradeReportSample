using System;
using System.Collections.Generic;

namespace TradeReporting.Properties
{
    internal static class TradeReportGenerator
    {
        private static List<IBrokerTrade> _allTrades = new List<IBrokerTrade>();

        public static void AddIBrokerTrade(IBrokerTrade brokerTrade) //TODO: To support adding multiple trades at once
        {
            _allTrades.Add(brokerTrade);
        }
        
        public static void CreateTradeReport()
        {
            foreach (IBrokerTrade assetPerBroker in _allTrades)
            {
                try
                {
                    Console.WriteLine("\n************Beginning of Report************\n");
                    assetPerBroker.PrintHeader();
                    assetPerBroker.PrintTrades();
                    Console.WriteLine("\n---------------End of Report---------------\n");
                }
                catch (Exception e) // TODO: Specify exceptions
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}