using MCB.Data.Domain.Admin;
using MCB.Data.Domain.Aviation;
using MCB.Data.Domain.Flights;
using MCB.Data.Domain.Geo;
using MCB.Data.Domain.Trips;
using MCB.Data.Domain.User;
using MCB.Data.Domain.WorldHeritages;
using Microsoft.EntityFrameworkCore;

namespace MCB.Data
{
    public class MCBContext : DbContext
    {
        public MCBContext(DbContextOptions<MCBContext> options) : base(options)
        {

        }

        //GeoEntites
        public DbSet<Country> Country { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Continent> Continent { get; set; }

        //User
        public DbSet<TUser> TUser { get; set; }
        public DbSet<UserCountry> UserCountry { get; set; }
        public DbSet<UserTrip> UserTrip { get; set; }

        //Trip
        public DbSet<Trip> Trip { get; set; }
        public DbSet<Stop> Stop { get; set; }

        //WorldHeritage
        public DbSet<WorldHeritage> WorldHeritage { get; set; }
        public DbSet<WorldHeritageCountry> WorldHeritageCountry { get; set; }

        //Aviation
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<AircraftFactory> AircraftFactory { get; set; }
        public DbSet<AircraftModel> AircraftModel { get; set; }
        public DbSet<Airline> Airline { get; set; }
        public DbSet<AirLineAlliance> AirLineAlliance { get; set; }

        //Flights
        public DbSet<Flight> Flight { get; set; }

        //Admin
        public DbSet<Log> Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UserCountry
            modelBuilder.Entity<UserCountry>().Property(uc => uc.CountryKnowledgeType).HasConversion<string>();
            modelBuilder.Entity<UserCountry>().HasKey(uc => new { uc.CountryId, uc.TUserId });

            //UserTrip
            modelBuilder.Entity<UserTrip>().HasKey(ut => new { ut.TripId, ut.TUserId });

            //UserFLigts
            modelBuilder.Entity<UserFlight>().HasKey(uf => new { uf.FlightId, uf.TUserId });

            //WorldHeritage
            modelBuilder.Entity<WorldHeritageCountry>().HasKey(s => new { s.WorldHeritageId, s.CountryId });

            //Flight
            modelBuilder.Entity<Flight>().Property(f => f.FlightTypeAssessment).HasConversion<string>();
        }
    }
}
