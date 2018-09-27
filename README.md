# Grammophone.Logging
This library abstracts logging in order to decouple projects from specific logger frameworks.
In order to provide logging, one needs to implement only minimal interfaces, `ILogger`
for writing log entries and `ILogProvider` for requesting `ILogger` implementations by name.
These mplementations must be thread-safe.

In order to invoke loggers efficiently, initialize a `LoggersRepository` with an `ILoggerProvider` and use the `GetLogger`
method to obtains loggers. `LoggersRepository` is caching the frequently requested loggers and is thread-safe, so it can be
a static member.

The library has a dependency on [Grammophone.Caching](https://github.com/grammophone/Grammophone.Caching) which must reside
in a sibling directory.
