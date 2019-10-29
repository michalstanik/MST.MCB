using MCB.Business.Models.Geo;
using System.Collections.Generic;

namespace MCB.Business.Models.Trips
{
    public class TripWithCountriesModel : TripModel
    {
        public List<CountryModel> Countries = new List<CountryModel>();
    }
}
