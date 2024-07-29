Note: code is directly from Rider

Architecture: mimicked Factory design pattern where "TradeReporting" folder contains all the source code.
1) Program.cs in TradeReportSample/TradeReporting is where the console app is run
2) Inside TradeReportSample/TradeReporting/Properties/
   - ReportInterfaces.cs defines the default contract that encompasses of both a) product type to trade b) broker type
   - ReportTypes.cs contain all unique implementation of the interfaces, such as broker CLSA with product type equity
   - ReportFactory.cs prints all possible ReportTypes polymorphically

Warning: no actual unit test is done as I have never done proper C# testing & didn't want to rely on GenAI as it's ingenuine. 
