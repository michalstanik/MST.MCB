using MCB.Data;
using MCB.Data.Domain.Geo;
using MCB.Data.Domain.Trips;
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
    }
}
