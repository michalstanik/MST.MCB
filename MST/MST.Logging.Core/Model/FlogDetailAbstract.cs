using System;

namespace MST.Flogging.Core.Model
{
    public abstract class FlogDetailAbstract
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

        //WHERE
        public string Product { get; set; }
        public string Layer { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
    }
}
