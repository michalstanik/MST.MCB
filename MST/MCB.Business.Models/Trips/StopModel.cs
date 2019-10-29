using MCB.Business.Models.Geo;
using MCB.Business.Models.WorldHeritages;
using System;

namespace MCB.Business.Models.Trips
{
    public class StopModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public int TripId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CountryModel Country { get; set; } 
        public WorldHeritageModel WorldHeritage { get; set; }
    }
}
