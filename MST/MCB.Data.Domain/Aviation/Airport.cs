using MCB.Data.Domain.Geo;

namespace MCB.Data.Domain.Aviation
{
    public class Airport
    {
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
    }
}
