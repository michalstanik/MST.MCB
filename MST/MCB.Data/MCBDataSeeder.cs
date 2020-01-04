using MCB.Data.Domain.Flights;
using MCB.Data.Domain.Trips;
using MCB.Data.Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCB.Data
{
    public class MCBDataSeeder
    {
        private readonly MCBContext _context;

        public MCBDataSeeder(MCBContext context)
        {
            _context = context;
        }

        public void DeleteData()
        {
            _context.Database.ExecuteSqlCommand("DELETE FROM WorldHeritageCountry;");
            _context.Database.ExecuteSqlCommand("DELETE FROM UserTrip;");
            _context.Database.ExecuteSqlCommand("DELETE FROM UserCountry;");
            _context.Database.ExecuteSqlCommand("DELETE FROM UserFlight;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Stop;");
            _context.Database.ExecuteSqlCommand("DELETE From Flight;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Airport;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Country;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Region;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Continent;");
            _context.Database.ExecuteSqlCommand("DELETE FROM WorldHeritage;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Trip;");
            _context.Database.ExecuteSqlCommand("DELETE FROM TUser;");
        }

        public void Seed()
        {
            if (_context.Trip.Any()) return;

            var firstUser = new TUser() { Id = "fec0a4d6-5830-4eb8-8024-272bd5d6d2bb", UserName = "Michał" };
            var secondUser = new TUser() { Id = "c3b7f625-c07f-4d7d-9be1-ddff8ff93b4d", UserName = "Aga" };

            var countryAzerbaijan = _context.Country.Where(c => c.Alpha3Code == "AZE").FirstOrDefault();
            var countryMexico = _context.Country.Where(c => c.Alpha3Code == "MEX").FirstOrDefault();
            var countryThailand = _context.Country.Where(c => c.Alpha3Code == "THA").FirstOrDefault();
            var countryCambodia = _context.Country.Where(c => c.Alpha3Code == "KHM").FirstOrDefault();
            var countryVietnam = _context.Country.Where(c => c.Alpha3Code == "VNM").FirstOrDefault();
            var countryUK = _context.Country.Where(c => c.Alpha3Code == "GBR").FirstOrDefault();
            var countryIndia = _context.Country.Where(c => c.Alpha3Code == "IND").FirstOrDefault();
            var countryCaboVerde = _context.Country.Where(c => c.Alpha3Code == "CPV").FirstOrDefault();
            var countryGambia = _context.Country.Where(c => c.Alpha3Code == "GMB").FirstOrDefault();
            var countrySenegal = _context.Country.Where(c => c.Alpha3Code == "SEN").FirstOrDefault();
            var countryGuineaBissau = _context.Country.Where(c => c.Alpha3Code == "GNB").FirstOrDefault();

            var firstAsiaTrip = new Trip()
            {
                Name = "My First Asia Trip",
                TripManager = firstUser,
                UserTrips = new List<UserTrip>()
                {
                    new UserTrip() { TUser = firstUser }
                },
                Stops = new List<Stop>()
                {
                    new Stop()
                    {
                        Name = "Bangok",
                        Description = "First Day in Bangok",
                        Order = 1,
                        Arrival = new DateTime(2016, 10, 31),
                        Departure = new DateTime(2016, 11, 1),
                        Country = countryThailand,
                        Latitude = 00.000000,
                        Longitude = 00.000000,
                    },
                    new Stop()
                    {
                        Name = "Cambodia",
                        Description = "First Day in Cambodia",
                        Order = 1,
                        Arrival = new DateTime(2016, 11, 2),
                        Departure = new DateTime(2016, 11, 4),
                        Country = countryCambodia,
                        Latitude = 00.000000,
                        Longitude = 00.000000,
                    },
                    new Stop()
                    {
                        Name = "Vietnam",
                        Description = "First Day in Vietnam",
                        Order = 1,
                        Arrival = new DateTime(2016, 11, 7),
                        Departure = new DateTime(2016, 11, 14),
                        Country = countryVietnam,
                        Latitude = 00.000000,
                        Longitude = 00.000000,
                    }
                },
                Flights = new List<Flight>()
                {
                    new Flight()
                    {
                        DepartureAirport = _context.Airport.Where(s => s.IATA == "WAW").FirstOrDefault(),
                        ArrivalAirport = _context.Airport.Where(s => s.IATA == "DXB").FirstOrDefault(),
                        DepartureDate = new DateTime(2016,10,31,13,25,00),
                        ArrivialDate = new DateTime(2016,10,31,22,5,00),
                        FlightNumber = "EK180",
                        FlightTypeAssessment = Flight.FlightType.Scheduled,
                        UserFlights = new List<UserFlight>()
                        {
                            new UserFlight() {TUser = firstUser }
                        }
                    },
                    new Flight()
                    {
                        DepartureAirport = _context.Airport.Where(s => s.IATA == "DXB").FirstOrDefault(),
                        ArrivalAirport = _context.Airport.Where(s => s.IATA == "BKK").FirstOrDefault(),
                        DepartureDate = new DateTime(2016,11,1,9,32,00),
                        ArrivialDate = new DateTime(2016,11,1,18,15,00),
                        FlightNumber = "EK418",
                        FlightTypeAssessment = Flight.FlightType.Scheduled,
                        UserFlights = new List<UserFlight>()
                        {
                            new UserFlight() {TUser = firstUser }
                        }
                    }
                }
            };

            var azerbaijanTrip = new Trip()
            {
                Name = "My First Azerbaijan Trip",
                TripManager = firstUser,
                UserTrips = new List<UserTrip>()
                {
                    new UserTrip() { TUser = firstUser}
                },
                Stops = new List<Stop>()
                {
                    new Stop()
                    {
                        Name = "Baku",
                        Description = "First Day in Baku",
                        Order = 1,
                        Arrival = new DateTime(2019, 5, 1),
                        Departure = new DateTime(2019, 5, 2),
                        Country = countryAzerbaijan,
                        Latitude = 40.383333,
                        Longitude = 49.866667,
                        WorldHeritage = _context.WorldHeritage.Where(w => w.UnescoId == "1076").FirstOrDefault()
                    },
                    new Stop()
                    {
                        Name = "Apsheron",
                        Description = "Second Day in Baku",
                        Order = 2,
                        Arrival = new DateTime(2019, 5, 2),
                        Departure = new DateTime(2019, 5, 3),
                        Country = countryAzerbaijan,
                        Latitude = 40.383333,
                        Longitude = 49.866667,
                        WorldHeritage = _context.WorldHeritage.Where(w => w.UnescoId == "958").FirstOrDefault()
                    }
                }
            };

            var threeAfricanCountriesTrip = new Trip()
            {
                Name = "Three African Countries Trip",
                TripManager = firstUser,
                UserTrips = new List<UserTrip>()
                {
                    new UserTrip() { TUser = firstUser }
                },
                Stops = new List<Stop>()
                {
                    new Stop()
                    {
                        Name = "Banjul",
                        Description = "First night in Banjul",
                        Order = 1,
                        Country = countryGambia,
                        Arrival = new DateTime(2019,12,13),
                        Departure = new DateTime(2019,12,14),
                        Latitude = 13.466667,
                        Longitude = -16.6
                    },
                    new Stop()
                    {
                        Name = "Bubaque",
                        Description = "Archipel des Bijagos, Bubaque Island",
                        Order = 2,
                        Country = countryGuineaBissau,
                        Arrival = new DateTime(2019,12,14),
                        Departure = new DateTime(2019,12,16),
                        Latitude = 11.283333,
                        Longitude = -15.833333
                    },
                    new Stop()
                    {
                        Name = "Cap Skirring",
                        Description = "Cap Skirring",
                        Order = 3,
                        Country = countrySenegal,
                        Arrival = new DateTime(2019,12,17),
                        Departure = new DateTime(2019,12,19),
                        Latitude = 12.389444,
                        Longitude = -16.738333
                    }
                }
            };


            _context.AddRange(azerbaijanTrip, firstAsiaTrip, threeAfricanCountriesTrip);
            _context.SaveChanges();

            _context.UserCountry.AddRange(
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 30,
                           Country = countryThailand,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 70,
                           Country = countryCambodia,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 40,
                           Country = countryVietnam,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 90,
                           Country = countryAzerbaijan,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 60,
                           Country = countryMexico,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 60,
                           Country = countryUK,
                           CountryKnowledgeType = UserCountry.CountryVisitType.BussinessTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 30,
                           Country = countryIndia,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 60,
                           Country = countryCaboVerde,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 40,
                           Country = countryGambia,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 30,
                           Country = countrySenegal,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = firstUser,
                           AreaLevelAssessment = 60,
                           Country = countryGuineaBissau,
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       }
                  );

            //_context.SaveChanges();
        }
    }
}
