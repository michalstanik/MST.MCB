namespace MST.IDP.Admin.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        IAdminConfiguration AdminConfiguration { get; }
        IAppConfiguration AppConfiguration { get; }
    }
}