using MCB.Business.CoreHelper.Paging;
using MCB.Business.CoreHelper.ResourceParameters;
using MCB.Data.Domain.Flights;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Data.RepositoriesInterfaces
{
    public interface IFlightRepository
    {
        Task<Flight> GetFlight(int flightId);
        Task<PagedList<Flight>> GetFligtsForUser(string userId, FlightsResourceParameters flightsResourceParameters);
    }
}
