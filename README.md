# Grammophone.Logging
This .NET Standard 2.0 library abstracts logging in order to decouple projects from specific logger frameworks.
In order to provide logging, one needs to implement only minimal interfaces, `ILogger`
for writing log entries and `ILogProvider` for requesting `ILogger` implementations by name.
These mplementations must be thread-safe.

In order to invoke loggers efficiently, initialize a `LoggersRepository` with an `ILoggerProvider` and use the `GetLogger`
method to obtain loggers. `LoggersRepository` is caching the frequently requested loggers and is thread-safe, so it can be
a static member.

You can support many logging frameworks at once by aggregating them
using `Grammophone.Logging.Composite.CompositeLoggerProvider` which implements `ILoggerProvider` itself and accepts a collection of `ILoggerProvider` implementations in its constructor.

The library has a dependency on [Grammophone.Caching](https://github.com/grammophone/Grammophone.Caching) which must reside in a sibling directory.
