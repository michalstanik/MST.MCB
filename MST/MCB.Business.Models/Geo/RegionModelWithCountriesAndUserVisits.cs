using System.Collections.Generic;

namespace MCB.Business.Models.Geo
{
    public class RegionModelWithCountriesAndUserVisits : RegionModel
    {
        public List<CountryModelWithAssesments> Countries { get; set; }
    }
}
