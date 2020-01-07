using MCB.Api.Configuration.Interfaces;

namespace MCB.Api.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public bool RecreateDB { get; set; }

        public bool DeleteData { get; set; }

        public double RemoveLogsOlderThanHours { get; set; }
    }
}
