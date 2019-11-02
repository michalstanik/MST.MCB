using System.Collections.Generic;

namespace MCB.Business.Models.Geo
{
    public class ContinentWithRegionsAndCountriesModel : ContinentModel
    {
        public List<RegionWithCountryModel> Regions { get; set; }
        public int VisitetCountriesOnContinent { get; set; }
    }
}
