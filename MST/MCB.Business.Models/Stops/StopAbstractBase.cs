using System;

namespace MCB.Business.Models.Stops
{
    public class StopAbstractBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}