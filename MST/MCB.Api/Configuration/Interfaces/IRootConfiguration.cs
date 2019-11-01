using MCB.Api.Configuration.Interfaces;

namespace MCB.Api.Interfaces.Configuration
{
    public interface IRootConfiguration
    {
        IAuthConfiguration AuthConfiguration { get; }
        IAppConfiguration AppConfiguration { get; }
    }
}