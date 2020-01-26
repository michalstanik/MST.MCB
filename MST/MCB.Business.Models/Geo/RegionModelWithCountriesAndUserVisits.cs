using System.Collections.Generic;

namespace MCB.Business.Models.Geo
{
    public class RegionModelWithCountriesAndUserVisits : RegionModelWithStats
    {
        public List<CountryModelWithAssesments> Countries { get; set; }
    }
}
