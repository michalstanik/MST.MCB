using MCB.Data.Domain.Flights;
using MCB.Data.Domain.Geo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCB.Data.Domain.Aviation
{
    public class Airport
    {
        public Airport()
        {
            ArrivalFlights = new List<Flight>();
            DepartureFlights = new List<Flight>();
        }

        public int Id { get; set; }
        public string AirportId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }

        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }

        [InverseProperty("ArrivalAirport")]
        public List<Flight> ArrivalFlights { get; set; }

        [InverseProperty("DepartureAirport")]
        public List<Flight> DepartureFlights { get; set; }
    }
}
