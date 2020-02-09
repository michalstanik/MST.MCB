using System;

namespace MCB.Business.Models.Flights
{
    public abstract class FlightAbstractBase
    {
        public string FlightNumber { get; set; }

        public long Distance { get; set; }
        public long FlightTime { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivialDate { get; set; }
    }
}
