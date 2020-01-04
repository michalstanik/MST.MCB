using MST.Flogging.Core.Model;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace MST.Flogging.Core
{
    public static class Flogger
    {
        private static readonly ILogger _usageLogger;

        static Flogger()
        {
            _usageLogger = new LoggerConfiguration()
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\api_usage.txt"))
                .CreateLogger();
        }

        public static void WriteUsage(FlogDetail infoToLog)
        {
            _usageLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }
    }
}
