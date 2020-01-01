using Serilog;
using System;
using System.IO;

namespace MST.Flogging.Core
{
    public static class Flogger
    {
        private static readonly ILogger _perfLogger;
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;

        static Flogger()
        {
            _perfLogger = new LoggerConfiguration()
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\perf.txt"))
                .CreateLogger();

            _usageLogger = new LoggerConfiguration()
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\usage.txt"))
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\error.txt"))
                .CreateLogger();

            _diagnosticLogger = new LoggerConfiguration()
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\diagnostic.txt"))
                .CreateLogger();
        }

    }
}
