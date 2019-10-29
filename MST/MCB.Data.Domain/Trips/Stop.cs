using MCB.Data.Domain.Geo;
using MCB.Data.Domain.WorldHeritages;
using System;

namespace MCB.Data.Domain.Trips
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public int? WorldHeritageId { get; set; }
        public WorldHeritage WorldHeritage { get; set; }
    }
}
