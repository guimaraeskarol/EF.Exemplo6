﻿using Microsoft.Extensions.Logging;

namespace EF.Exemplo6;

public class MeuLogProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return (new MeuLog());
    }

    public void Dispose()
    {
    }
}

public class MeuLog : ILogger
{
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        File.AppendAllText(@"D:\log\sql.log", formatter(state, exception));
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }
}