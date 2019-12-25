namespace MCB.Business.Models.Geo
{
    public class RegionModelWithStats : RegionModel
    {
        public int StatsCountryCount { get; set; }
        public int VisitedCountryCount { get; set; }
        public int CountriesCount { get; set; }
    }
}