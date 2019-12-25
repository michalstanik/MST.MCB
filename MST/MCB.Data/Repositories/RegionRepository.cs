using MCB.Data.Domain.Geo;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Data.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly MCBContext _context;

        public RegionRepository(MCBContext context)
        {
            _context = context;
        }

        public async Task<Region> GetRegion(int regionId)
        {
            IQueryable<Region> query = _context.Region.Where(t => t.Id == regionId);

            query = query.Include(r => r.Continent).Include(c => c.Countries);

            return await query.FirstOrDefaultAsync();
        }
    }
}
