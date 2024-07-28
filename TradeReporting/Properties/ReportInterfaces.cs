using System;
using System.Collections.Generic;

namespace TradeReporting.Properties
{
    public interface IBroker // All common Broker items
    {
        void EnvCheck();  // Assume this is a necessary internal process
        void RefreshBroker();  // Assume this is a necessary internal process
    }
    
    public interface ITrade // All common trading items
    {
        List<string> TradeRefs { get; }
        List<int> ProductIds { get; }
        List<string> ProductNames { get; }
        List<DateTime> TradeDates { get; }
        List<decimal> Qty { get; }
        List<string> BuySell { get; }
        List<decimal> Prices { get; }
        void PrintTrades();
        void PrintHeader();
    }
    
    public interface IBrokerTrade : IBroker, ITrade{} // Interface for all combinations of Broker/Asset types
}