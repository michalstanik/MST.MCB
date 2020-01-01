using System.Linq;
using System.Threading.Tasks;

namespace MCB.Data
{
    public class MCBReportingSeeder
    {
        private readonly MCBContext _context;

        public MCBReportingSeeder(MCBContext context)
        {
            _context = context;
        }

        public void GenerateReportingForRegionsAndContinents()
        {
            foreach (var continent in _context.Continent.ToList())
            {
                int countriesCountInContinent = 0;

                foreach (var region in _context.Region.Where(r => r.ContinentId == continent.Id).ToList())
                {
                    var countriesCountInRegion = _context.Country.Where(c => c.RegionId == region.Id).Count();
                    region.CountriesCount = countriesCountInRegion;

                    countriesCountInContinent += countriesCountInRegion;
                    _context.SaveChanges();
                }

                continent.CountryCount = countriesCountInContinent;
                _context.SaveChanges();
            }
        }
    }
}
