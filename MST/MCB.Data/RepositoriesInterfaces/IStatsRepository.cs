namespace MCB.Data.RepositoriesInterfaces
{
    public interface IStatsRepository
    {
        int GetFlightsCountForUser(string userId);
        long GetFlightsDistanceForUser(string userId);
    }
}
