using MCB.Data.Domain.Aviation;
using MCB.Data.Domain.Trips;
using MCB.Data.Domain.User;
using MCB.Data.Domain.WorldHeritages;
using System.Collections.Generic;

namespace MCB.Data.Domain.Geo
{
    public class Country
    {
        public Country()
        {
            Airports = new List<Airport>();
            UserCountries = new List<UserCountry>();
            CountryStops = new List<Stop>();
            WoldHeritageCountries = new List<WorldHeritageCountry>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public long Area { get; set; }

        public int? RegionId { get; set; }
        public Region Region { get; set; }

        public List<UserCountry> UserCountries { get; set; }
        public List<Stop> CountryStops { get; set; }
        public List<WorldHeritageCountry> WoldHeritageCountries { get; set; }
        public List<Airport> Airports { get; set; }
    }
}