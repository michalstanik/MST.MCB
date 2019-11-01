namespace MCB.Api.Configuration.Interfaces
{
    public interface IAuthConfiguration
    {
        string STSAuthority { get; }
        string STSApiName { get; }
        string STSApiAuthorizeUrl { get; }
        string STSOAuthClientId { get; }
        string STSApiDescription { get; }
    }
}
