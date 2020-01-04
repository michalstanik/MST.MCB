using MCB.Data;
using MCB.Data.Domain.Geo;
using MCB.Data.Domain.Trips;
using MCB.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Tests.Data
{
    public class CountryRepositoryTests
    {
        private readonly ITestOutputHelper _output;

        public CountryRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task GetCountriesForTrip_TripNotExists_EmptyListOfCountries()
        {
            var dbOptions = DbSettingHellper.GetDbOptions(_output);
            //Arrange
            using (var context = new MCBContext(dbOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                context.Add(new Trip()
                {
                    Id = 8,
                    Name = "Trip 1"
                });
                await context.SaveChangesAsync();

            }

            using (var context = new MCBContext(dbOptions))
            {
                var geoRepository = new CountryRepository(context);

                // Act
                var countries = await geoRepository.GetCountriesForTrip(9);

                // Assert
                Assert.Empty(countries);
            }
        }

        [Fact]
        public async Task GetCountriesForTrip_TripWithNoStops_EmptyListOfCountries()
        {
            var dbOptions = DbSettingHellper.GetDbOptions(_output);
            //Arrange
            using (var context = new MCBContext(dbOptions))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                context.Add(new Trip()
                {
                    Id = 8,
                    Name = "Trip 1"
                });
                await context.SaveChangesAsync();

            }

            using (var context = new MCBContext(dbOptions))
            {
                var geoRepository = new CountryRepository(context);

                // Act
                var countries = await geoRepository.GetCountriesForTrip(8);

                // Assert
                Assert.Empty(countries);
            }
        }

        [Fact]
        public async Task GetCountriesForTrip_TripWithOneStops_ListOfOneCountry()
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
                      new Stop() { Name = "Stop 2", CountryId = 5, Country = new Country{ Id = 5, Name = "Poland" } }
                    }
                };

                context.Add(trip1);
                await context.SaveChangesAsync();

            }

            using (var context = new MCBContext(dbOptions))
            {
                var geoRepository = new CountryRepository(context);

                // Act
                var countries = await geoRepository.GetCountriesForTrip(8);

                // Assert
                Assert.Single(countries);
            }
        }

        [Fact]
        public async Task GetCountriesForTrip_TripWithTwoStopsAndOneCountry_ListOfOneCountry()
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
                var geoRepository = new CountryRepository(context);

                // Act
                var countries = await geoRepository.GetCountriesForTrip(8);

                // Assert
                Assert.Single(countries);
            }
        }
    }
}
