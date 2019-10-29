using MCB.Business.Models.Geo;
using MCB.Business.Models.WorldHeritages;
using System;
using System.Collections.Generic;

namespace MCB.Business.Models.Trips
{
    public class TripFullModel : TripWithStopsAndUsersModel
    {
        public List<CountryModel> Countries = new List<CountryModel>();
        public List<WorldHeritageModel> WorldHeritages = new List<WorldHeritageModel>();
        public Dictionary<string, int> Statistics = new Dictionary<string, int>();
        public Dictionary<string, DateTime> Dates = new Dictionary<string, DateTime>();
    }
}
