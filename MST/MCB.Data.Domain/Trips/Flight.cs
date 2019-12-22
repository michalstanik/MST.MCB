using MCB.Data.Domain.Aviation;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCB.Data.Domain.Trips
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivialDate { get; set; }

        public Airport DepartureAirport { get; set; }

        public Airport ArrivalAirport { get; set; }

        public Trip Trip { get;set; }
        public int? TripId { get; set; }
    }
}
