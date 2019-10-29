using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCB.Data.Domain.Geo;
using MCB.Data.Domain.Trips;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MCB.Data.Repositories
{
    public class GeoRepository : IGeoRepository
    {
        private readonly MCBContext _context;

        public GeoRepository(MCBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Country>> GetCountriesForTrip(int tripId)
        {
            var query = _context.Trip.Where(t => t.Id == tripId);

            var results = await ReturnCountriesBasedOnTripQuery(query);

            return results;
        }

        private async Task<ICollection<Country>> ReturnCountriesBasedOnTripQuery(IQueryable<Trip> inputQuery)
        {
            var listOfTripsWithGraph = inputQuery
                .Include(i => i.Stops)
                    .ThenInclude(c => c.Country)
                    .ThenInclude(r => r.Region)
                    .ThenInclude(c => c.Continent);

            await listOfTripsWithGraph.ToListAsync();

            var listOfCountriesToReturn = new List<Country>();

            foreach (var trip in listOfTripsWithGraph)
            {
                var listOfCountries = trip.Stops
                    .Where(v => v.CountryId != null)
                    .Select(c => c.Country).Distinct().ToList();

                foreach (var country in listOfCountries)
                {
                    if (listOfCountriesToReturn.Where(c => c.Id == country.Id).Count() == 0)
                    {
                        listOfCountriesToReturn.Add(country);
                    }
                }
            }

            return listOfCountriesToReturn;
        }
    }
}