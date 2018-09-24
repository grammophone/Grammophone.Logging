# Grammophone.Logging
This library abstracts logging in order to decouple projects from specific logger frameworks.
In order to provide logging, one needs to implement only minimal interfaces, `ILogger`
for writing log entries and `ILogProvider` for requesting `ILogger` implementations by name. 
