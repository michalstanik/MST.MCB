using MCB.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MCB.Tests.Data
{
    public static class DbSettingHellper
    {
        public static DbContextOptions<MCBContext> GetDbOptions(ITestOutputHelper output)
        {
            var connectionStringBuilder =
                             new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<MCBContext>()
                 .UseLoggerFactory(new LoggerFactory(
                        new[] { new LogToActionLoggerProvider((log) =>
                                {
                                   output.WriteLine(log);
                                }) }))
                .UseSqlite(connection)
                .Options;
            return options;
        }
    }
}
