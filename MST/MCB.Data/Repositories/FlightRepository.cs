using MCB.Business.CoreHelper.Paging;
using MCB.Business.CoreHelper.ResourceParameters;
using MCB.Data.Domain.Flights;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Data.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly MCBContext _context;

        public FlightRepository(MCBContext context)
        {
            _context = context;
        }

        public async Task<Flight> GetFlight(int flightId)
        {
            IQueryable<Flight> query = _context.Flight.Where(t => t.Id == flightId);

            query = query
                .Include(r => r.Trip)
                .Include(b => b.ArrivalAirport)
                .Include(c => c.DepartureAirport)
                .Include(a => a.Aircraft)
                    .ThenInclude(a => a.AircraftModel)
                    .ThenInclude(a => a.AircraftFactory)
                    .ThenInclude(a => a.AircraftFactoryCountry)
                .Include(ar => ar.Airline)
                    .ThenInclude(ar => ar.AirLineAlliance)
                .Include(ab => ab.Airline)
                    .ThenInclude(ab => ab.AirlineCountry)
                .Include(uf => uf.UserFlights);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PagedList<Flight>> GetFligtsForUser(string userId, FlightsResourceParameters flightsResourceParameters)
        {
            IQueryable<Flight> query = _context.UserFlight.Where(uf => uf.TUserId == userId).Select(f => f.Flight);

            query =  query
                .Include(r => r.Trip)
                .Include(b => b.ArrivalAirport)
                .Include(c => c.DepartureAirport)
                .Include(a => a.Aircraft)
                    .ThenInclude(a => a.AircraftModel)
                    .ThenInclude(a => a.AircraftFactory)
                    .ThenInclude(a => a.AircraftFactoryCountry)
                .Include(ar => ar.Airline)
                    .ThenInclude(ar => ar.AirLineAlliance)
                .Include(ab => ab.Airline)
                    .ThenInclude(ab => ab.AirlineCountry);

            return PagedList<Flight>.Create(query, flightsResourceParameters.PageNumber, flightsResourceParameters.PageSize);
        }
    }
}