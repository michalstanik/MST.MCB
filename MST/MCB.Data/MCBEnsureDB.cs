using Microsoft.EntityFrameworkCore;

namespace MCB.Data
{
    public class MCBEnsureDB
    {
        private readonly MCBContext _context;

        public MCBEnsureDB(MCBContext context) => _context = context;

        public void EnsureDeletedAndRecreated()
        {
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();
        }

        public void EnsureCreatedAndMigrated()
        {
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
        }
    }
}
