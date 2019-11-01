namespace MCB.Api.Configuration.Interfaces
{
    public interface IAppConfiguration
    {
        bool RecreateDB { get; }
        bool DeleteData { get; }
    }
}
