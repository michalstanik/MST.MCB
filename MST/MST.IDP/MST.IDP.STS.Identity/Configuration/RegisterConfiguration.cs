using MST.IDP.STS.Identity.Configuration.Intefaces;

namespace MST.IDP.STS.Identity.Configuration
{
    public class RegisterConfiguration : IRegisterConfiguration
    {
        public bool Enabled { get; set; } = true;
    }
}
