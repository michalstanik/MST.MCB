using System.Collections.Generic;

namespace MCB.Data.Domain.Geo
{
    public class Region
    {
        public Region()
        {
            Countries = new List<Country>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        //Reporting
        public int? CountriesCount { get; set; }
        public double MaxLongitude { get; set; }
        public double MinLongitude { get; set; }
        public double MaxLatitude { get; set; }
        public double MinLatitude { get; set; }

        public int? ContinentId { get; set; }
        public Continent Continent { get; set; }

        public List<Country> Countries { get; set; }
    }
}