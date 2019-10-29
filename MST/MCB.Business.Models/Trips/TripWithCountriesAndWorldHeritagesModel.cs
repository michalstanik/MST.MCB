using MCB.Business.Models.WorldHeritages;
using System.Collections.Generic;

namespace MCB.Business.Models.Trips
{
    public class TripWithCountriesAndWorldHeritagesModel : TripWithCountriesModel
    {
        public List<WorldHeritageModel> WorldHeritages = new List<WorldHeritageModel>();
    }
}
