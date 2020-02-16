namespace MCB.Business.Models.Stats
{
    public class StatsModel
    {
        public StatsModel()
        {
            TripsStats = new TripsStatsModel();
            FlightsStats = new FlightsStatsModel();
        }
        public TripsStatsModel TripsStats { get; set; }  
        public FlightsStatsModel FlightsStats { get; set; }
    }
}
