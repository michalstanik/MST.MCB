using MCB.Business.Models.Geo;
using MCB.Business.Models.WorldHeritages;
using System;

namespace MCB.Business.Models.Stops
{
    public class StopModel : StopAbstractBase
    {
        public int Id { get; set; }
       
        public int TripId { get; set; }

        public CountryModel Country { get; set; } 
        public WorldHeritageModel WorldHeritage { get; set; }
    }
}
