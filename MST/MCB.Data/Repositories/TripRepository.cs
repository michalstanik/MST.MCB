using MCB.Data.Domain.Trips;
using MCB.Data.Domain.User;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Data.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly MCBContext _context;

        public TripRepository(MCBContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task AddTrip(Trip tripEntity)
        {
            await _context.AddAsync(tripEntity);
        }

        public async Task AddUserToTheTrip(int tripId, string userId)
        {
            var trip = await _context.Trip.Where(t => t.Id == tripId).FirstOrDefaultAsync();
            var user = await _context.TUser.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (trip != null && user != null)
            {
                var tripUser = new UserTrip()
                {
                    Trip = trip,
                    TUser = user
                };
                await _context.AddAsync(tripUser);
            }
            else
            {
                throw new Exception("Trip or user are not exists");
            }



        }

        public async Task<bool> CheckUserPermissionsForTrip(int tripId, string userId)
        {
            var trip = await _context.Trip
                .Include(c => c.UserTrips)
                    .ThenInclude(pc => pc.TUser)
                .Where(t => t.Id == tripId)
                .FirstOrDefaultAsync();

            if (trip != null)
            {
                foreach (var user in trip.Users())
                {
                    if (user.Id == userId) return true;
                }
            }
            return false;
        }

        public async Task<Trip> GetTrip(int tripId, bool includeStops = false, bool includeUsers = false)
        {
            IQueryable<Trip> query = _context.Trip.Where(t => t.Id == tripId);

            query = IncludeTripProperties(query, includeStops, includeUsers);

            return await query.FirstOrDefaultAsync();

        }

        public async Task<List<Trip>> GetTripsByUser(string userId, bool includeStops, bool includeUsers, bool includeFlights = false)
        {
            var query = from tu in _context.UserTrip
                        join u in _context.TUser on tu.TUserId equals userId
                        join t in _context.Trip on tu.TripId equals t.Id
                        select t;

            query = IncludeTripProperties(query, includeStops, includeUsers, includeFlights);

            return await query.ToListAsync();
        }

        public IQueryable<Trip> IncludeTripProperties(IQueryable<Trip> query, bool includeStops, bool includeUsers, bool includeFlights = false)
        {
            if (includeStops && !includeUsers && !includeFlights)
            {
                query = query
                    .Include(c => c.Stops)
                        .ThenInclude(c => c.Country)
                        .ThenInclude(r => r.Region)
                        .ThenInclude(e => e.Continent)
                    .Include(e => e.Stops)
                        .ThenInclude(e => e.WorldHeritage);
            }
            else if (!includeStops && includeUsers && !includeFlights)
            {
                query = query.Include(c => c.UserTrips)
                    .ThenInclude(pc => pc.TUser);
            }
            else if (includeStops && includeUsers && !includeFlights)
            {
                query = query
                    .Include(c => c.Stops)
                        .ThenInclude(c => c.Country)
                        .ThenInclude(r => r.Region)
                        .ThenInclude(e => e.Continent)
                    .Include(e => e.Stops)
                        .ThenInclude(e => e.WorldHeritage)
                    .Include(c => c.UserTrips)
                        .ThenInclude(pc => pc.TUser);
            }
            else if (includeStops && includeUsers && includeFlights)
            {
                query = query
                    .Include(c => c.Stops)
                        .ThenInclude(c => c.Country)
                        .ThenInclude(r => r.Region)
                        .ThenInclude(e => e.Continent)
                    .Include(e => e.Stops)
                        .ThenInclude(e => e.WorldHeritage)
                    .Include(c => c.UserTrips)
                        .ThenInclude(pc => pc.TUser)
                    .Include(f => f.Flights)
                        .ThenInclude(a => a.DepartureAirport)
                    .Include(g => g.Flights)
                        .ThenInclude(b => b.ArrivalAirport);
            }
            return query;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
