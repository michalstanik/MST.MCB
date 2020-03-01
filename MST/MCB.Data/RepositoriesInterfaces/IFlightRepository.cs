using MCB.Data.Domain.Flights;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Data.RepositoriesInterfaces
{
    public interface IFlightRepository
    {
        Task<Flight> GetFlight(int flightId);
        Task<List<Flight>> GetFligtsForUser(string userId);
    }
}
