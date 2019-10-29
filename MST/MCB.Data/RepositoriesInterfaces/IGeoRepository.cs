using MCB.Data.Domain.Geo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Data.RepositoriesInterfaces
{
    public interface IGeoRepository
    {
        Task<ICollection<Country>> GetCountriesForTrip(int tripId);
    }
}
