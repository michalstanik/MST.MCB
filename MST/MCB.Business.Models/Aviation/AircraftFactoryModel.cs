using MCB.Business.Models.Geo;

namespace MCB.Business.Models.Aviation
{
    public class AircraftFactoryModel
    {
        public string Name { get; set; }
        public CountryModel AircraftFactoryCountry { get; set; }
    }
}