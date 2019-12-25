using MCB.Data.Domain.Geo;
using System.Threading.Tasks;

namespace MCB.Data.RepositoriesInterfaces
{
    public interface IRegionRepository
    {
        Task<Region> GetRegion(int regionId);
    }
}
