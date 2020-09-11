﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevOps.Util.UnitTests
{
    internal sealed class TestableLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new InvalidOperationException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

        }
    }
}
