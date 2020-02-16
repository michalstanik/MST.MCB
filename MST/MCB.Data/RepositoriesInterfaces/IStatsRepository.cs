namespace MCB.Data.RepositoriesInterfaces
{
    public interface IStatsRepository
    {
        int GetFlightsCountForUser(string userId);
        long GetFlightsDistanceForUser(string userId);
        long GetFlightsTimeForUser(string userId);
        int GetTripsCountForUser(string userId);
        int GetCountriesForUser(string userId);
    }
}
