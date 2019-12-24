using MCB.Data.Domain.Flights;
using System.Threading.Tasks;

namespace MCB.Data.RepositoriesInterfaces
{
    public interface IFlightRepository
    {
        Task<Flight> GetFlight(int flightId);
        Task<bool> CheckUserPermissionsForFlight(int flightId, string userId);
    }
}
