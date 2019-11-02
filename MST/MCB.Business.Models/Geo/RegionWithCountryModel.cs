using System.Collections.Generic;

namespace MCB.Business.Models.Geo
{
    public class RegionWithCountryModel : RegionModel
    {
        public int Id { get; set; }
        public List<CountryModel> Countries { get; set; }
    }
}