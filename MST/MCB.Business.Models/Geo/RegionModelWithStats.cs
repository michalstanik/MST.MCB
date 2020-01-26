namespace MCB.Business.Models.Geo
{
    public class RegionModelWithStats : RegionModel
    {
        public int StatsCountryCount { get; set; }
        public int VisitedCountryCount { get; set; }
        public int CountriesCount { get; set; }
        public double MaxLongitude { get; set; }
        public double MinLongitude { get; set; }
        public double MaxLatitude { get; set; }
        public double MinLatitude { get; set; }
    }
}