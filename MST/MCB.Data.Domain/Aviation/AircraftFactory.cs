using MCB.Data.Domain.Geo;
using System.Collections.Generic;

namespace MCB.Data.Domain.Aviation
{
    public class AircraftFactory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? AircraftFactoryCountryId { get; set; }
        public Country AircraftFactoryCountry { get; set; }

        public List<AircraftModel> AircraftModels { get; set; }
    }
}