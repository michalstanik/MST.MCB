using MCB.Data;
using MCB.Data.Domain.Flights;
using MCB.Data.Domain.Geo;
using MCB.Data.Domain.Trips;
using MCB.Data.Domain.User;
using MCB.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Tests.Data
{
    public class TripRepostoryTests
    {
        private readonly ITestOutputHelper _output;

        public TripRepostoryTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task GetTrip_TripNotExists_EmptyTrip()
        {
            var dbOptions = DbSettingHellper.GetDbOptions(_output);
            //Arrange
            using (var context = new MCBContext(dbOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var trip1 = new Trip()
                {
                    Id = 8,
                    Name = "Trip 1",
                    Stops = new List<Stop>()
                    {
                      new Stop() { Name = "Stop 1", CountryId = 5, Country = new Country{ Id = 5, Name = "Poland" } },
                      new Stop() { Name = "Stop 2", CountryId = 5, Country = new Country{ Id = 5, Name = "Poland" } }
                    }
                };

                context.Add(trip1);
                await context.SaveChangesAsync();
            }

            using (var context = new MCBContext(dbOptions))
            {
                var tripRepository = new TripRepository(context);

                // Act
                var trip = await tripRepository.GetTrip(10);

                // Assert
                Assert.Null(trip);
            }
        }

        [Fact]
        public async Task GetTrip_TripWithoutContryAndWorldHeritage_OneTripReturned()
        {
            var dbOptions = DbSettingHellper.GetDbOptions(_output);
            //Arrange
            using (var context = new MCBContext(dbOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var trip1 = new Trip()
                {
                    Id = 8,
                    Name = "Trip 1",
                    Stops = new List<Stop>()
                    {
                      new Stop() { Name = "Stop 1" },
                      new Stop() { Name = "Stop 2" }
                    }
                };

                context.Add(trip1);
                await context.SaveChangesAsync();
            }

            using (var context = new MCBContext(dbOptions))
            {
                var tripRepository = new TripRepository(context);

                // Act
                var trip = await tripRepository.GetTrip(8, true);

                // Assert
                Assert.NotNull(trip);
                Assert.Equal(2, trip.Stops.Count());
            }
        }

        [Fact]
        public async Task GetTrip_TripWithFlightsOnly_OneTripReturnedWithFlights()
        {
            var dbOptions = DbSettingHellper.GetDbOptions(_output);
            //Arrange
            using (var context = new MCBContext(dbOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var trip1 = new Trip()
                {
                    Id = 8,
                    Name = "Trip 1",
                    Flights = new List<Flight>()
                    {
                        new Flight(){ Id = 1, TripId = 8, FlightNumber = "EZ1245" },
                        new Flight(){ Id = 2, TripId = 8, FlightNumber = "EZ1246" },
                        new Flight(){ Id = 3, TripId = 8, FlightNumber = "EZ1247" },
                    }
                };

                context.Add(trip1);
                await context.SaveChangesAsync();
            }

            using (var context = new MCBContext(dbOptions))
            {
                var tripRepository = new TripRepository(context);

                // Act
                var trip = await tripRepository.GetTrip(8, false, false, true);

                // Assert
                Assert.NotNull(trip);
                Assert.NotEmpty(trip.Flights);
            }
        }

        [Fact]
        public async Task GetTrip_TripWithFlightsOnly_OneTripReturnedWithoutFlights()
        {
            var dbOptions = DbSettingHellper.GetDbOptions(_output);
            //Arrange
            using (var context = new MCBContext(dbOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var trip1 = new Trip()
                {
                    Id = 8,
                    Name = "Trip 1",
                    Flights = new List<Flight>()
                    {
                        new Flight(){ Id = 1, TripId = 8, FlightNumber = "EZ1245" },
                        new Flight(){ Id = 2, TripId = 8, FlightNumber = "EZ1246" },
                        new Flight(){ Id = 3, TripId = 8, FlightNumber = "EZ1247" },
                    }
                };

                context.Add(trip1);
                await context.SaveChangesAsync();
            }

            using (var context = new MCBContext(dbOptions))
            {
                var tripRepository = new TripRepository(context);

                // Act
                var trip = await tripRepository.GetTrip(8, false, false, false);

                // Assert
                Assert.NotNull(trip);
                Assert.Empty(trip.Flights);
            }
        }
        
        [Fact]
        public async Task GetTripsByUser_TripWithoutFlights_ListOfOneTripReturned()
        {
            var dbOptions = DbSettingHellper.GetDbOptions(_output);
            //Arrange
            using (var context = new MCBContext(dbOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var user1 = new TUser()
                {
                    Id = "fec0a4d6-5830-4eb8-8024-272bd5d6d2bb",
                    UserName = "User1"
                };
                context.Add(user1);
                await context.SaveChangesAsync();

                var trip1 = new Trip()
                {
                    Id = 8,
                    Name = "Trip 1",
                    UserTrips = new List<UserTrip>()
                    {
                        new UserTrip(){ TripId = 8, TUser = user1 }
                    }
                };

                context.Add(trip1);
                await context.SaveChangesAsync();
            }

            using (var context = new MCBContext(dbOptions))
            {
                var tripRepository = new TripRepository(context);

                // Act
                var trip = await tripRepository.GetTripsByUser("fec0a4d6-5830-4eb8-8024-272bd5d6d2bb", true, true, true);

                // Assert
                Assert.NotNull(trip);
                Assert.Empty(trip.FirstOrDefault().Flights);
            }
        }
    }
}
