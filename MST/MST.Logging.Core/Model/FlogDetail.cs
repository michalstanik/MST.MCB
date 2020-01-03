using MST.Flogging.Core.Model;
using System;
using System.Collections.Generic;

namespace MST.Flogging.Core.Model
{
    public class FlogDetail : FlogDetailAbstract
    {
        public FlogDetail()
        {
            Timestamp = DateTime.Now;
        }
        //WHO
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        //Everything Else
        public long? ElapsedMilliseconds { get; set; }  // only for performance entries
        public Exception Exception { get; set; }  // the exception for error logging
        public string CorrelationId { get; set; } // exception shielding from server to client
        public Dictionary<string, object> AdditionalInfo { get; set; }  // everything else
    }
}
