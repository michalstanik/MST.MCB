using System.Collections.Generic;

namespace MST.Flogging.Core.Model
{
    public class UsageFlogDetail : FlogDetailAbstract
    {
        public string CorrelationId { get; set; } // exception shielding from server to client
        public Dictionary<string, object> AdditionalInfo { get; set; }  // everything else
    }
}
