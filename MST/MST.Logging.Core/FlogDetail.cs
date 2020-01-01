using System;
using System.Collections.Generic;

namespace MST.Flogging.Core
{
    public class FlogDetail
    {
        public FlogDetail()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public string Message { get; set; }

        //WHERE
        public string Product { get; set; }
        public string Layer { get; set; }
        public string Location { get; set; }
        public string  Hostname { get; set; }

        //WHO
        public string UserId { get; set; }
        public string UserName { get; set; }

        //Everything Else
        public long? ElapsedMilliseconds { get; set; }
        public Exception Exception { get; set; }
        public Dictionary<string, object> AdditionalInfo { get; set; }
    }
}
