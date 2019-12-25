using MCB.Data.Domain.Geo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Data.RepositoriesInterfaces
{
    public interface ICountryRepository
    {
        Task<ICollection<Country>> GetCountriesForTrip(int tripId);
        Task<ICollection<Country>> GetCountiresWithAssesmentForUser(string userId);
        Task<ICollection<Continent>> GetContinents(bool includeRegions, bool includeCountries);
        Task<Dictionary<string, long>> GetCountireAssesmentForUser(string userId);
    }
}
