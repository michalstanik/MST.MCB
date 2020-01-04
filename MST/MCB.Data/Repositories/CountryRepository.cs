using MCB.Data.Domain.Geo;
using MCB.Data.Domain.Trips;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly MCBContext _context;

        public CountryRepository(MCBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Country>> GetCountriesForTrip(int tripId)
        {
            var query = _context.Trip.Where(t => t.Id == tripId);

            var results = await ReturnCountriesBasedOnTripQuery(query);

            return results;
        }

        public async Task<ICollection<Continent>> GetContinents(bool includeRegions = false, bool includeCountries = false)
        {
            IQueryable<Continent> query = _context.Continent;

            if (includeRegions)
            {
                query = query.Include(t => t.Regions);
            }

            if (includeCountries)
            {
                query = query.Include(t => t.Regions).ThenInclude(c => c.Countries);
            }

            return await query.ToListAsync();
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
                    if (!listOfCountriesToReturn.Where(c => c.Id == country.Id).Any())
                    {
                        listOfCountriesToReturn.Add(country);
                    }
                }
            }

            return listOfCountriesToReturn;
        }

        public async Task<ICollection<Country>> GetCountiresWithAssesmentForUser(string userId)
        {
            var query = await _context.UserCountry.Where(u => u.TUserId == userId).ToListAsync();

            var listofCountriesToBeReturned = new List<Country>();

            foreach (var cntry in query)
            {
                var tempCountry = _context.Country
                    .Include(r => r.Region)
                    .Where(c => c.Id == cntry.CountryId).SingleOrDefault();

                if (tempCountry != null && !listofCountriesToBeReturned.Where(d => d.Id == cntry.CountryId).Any())
                {
                    listofCountriesToBeReturned.Add(tempCountry);
                }
            }

            return listofCountriesToBeReturned;
        }

        public async Task<Dictionary<string, long>> GetCountireAssesmentForUser(string userId)
        {
            Dictionary<string, long> countriesTobereturned = new Dictionary<string, long>();

            return countriesTobereturned = await _context.UserCountry
                .Where(a => a.TUser.Id == userId)
                .Select(a => new
                {
                    a.Country.Alpha2Code,
                    a.AreaLevelAssessment
                })
                .ToDictionaryAsync(p => p.Alpha2Code, p => p.AreaLevelAssessment);
        }
    }
}