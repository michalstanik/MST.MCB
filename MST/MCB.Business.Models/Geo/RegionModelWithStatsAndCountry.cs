using System.Collections.Generic;

namespace MCB.Business.Models.Geo
{
    public class RegionModelWithStatsAndCountry : RegionModelWithStats
    { 
        public List<CountryModel> Countries { get; set; }
    }
}