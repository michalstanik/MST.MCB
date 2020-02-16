using MCB.Data.RepositoriesInterfaces;
using System.Linq;

namespace MCB.Data.Repositories
{
    public class StatsRepository : IStatsRepository
    {
        private readonly MCBContext _context;

        public StatsRepository(MCBContext context)
        {
            _context = context;
        }
        public int GetFlightsCountForUser(string userId)
        {
            return _context.UserFlight.Where(u => u.TUserId == userId).Select(t => t.Flight).Distinct().Count();
        }

        public long GetFlightsDistanceForUser(string userId)
        {
            return (long)_context.UserFlight.Where(u => u.TUserId == userId).Select(t => t.Flight).Select(f => f.Distance).Sum();
        }
    }
}
