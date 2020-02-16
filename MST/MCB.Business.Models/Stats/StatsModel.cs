namespace MCB.Business.Models.Stats
{
    public class StatsModel
    {
        public StatsModel()
        {
            TripsStats = new TripsStatsModel();
            FlightsStats = new FlightsStatsModel();
            CountriesStats = new CountriesStatsModel();
        }
        public TripsStatsModel TripsStats { get; set; }  
        public FlightsStatsModel FlightsStats { get; set; }
        public CountriesStatsModel CountriesStats { get; set; }
    }
}
