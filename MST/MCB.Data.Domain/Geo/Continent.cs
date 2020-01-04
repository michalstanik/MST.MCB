using System.Collections.Generic;

namespace MCB.Data.Domain.Geo
{
    public class Continent
    {
        public Continent()
        {
            Regions = new List<Region>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        //Reporting
        public int? CountryCount { get; set; }

        public List<Region> Regions { get; set; }
    }
}
