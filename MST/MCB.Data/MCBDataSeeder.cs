using MCB.Data.Domain.Aviation;
using MCB.Data.Domain.Flights;
using MCB.Data.Domain.Geo;
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
        
        private List<AircraftModel> _createdAircraftModels;
        private List<AircraftFactory> _createdAircraftFactories;
        private List<Country> _createdCountries;
        private List<Airport> _createdAirports;
        private List<AirLineAlliance> _createdAirlineAlliances;
        private List<Airline> _createdAirlines;
        private List<Aircraft> _createdAircrafts;
        private List<Flight> _createdFlights;
        private List<TUser> _createdUsers;

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
            _context.Database.ExecuteSqlCommand("DELETE FROM Airline;");
            _context.Database.ExecuteSqlCommand("DELETE FROM AirLineAlliance;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Aircraft;");
            _context.Database.ExecuteSqlCommand("DELETE FROM AircraftModel;");
            _context.Database.ExecuteSqlCommand("DELETE FROM AircraftFactory;");
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

            //Dictonaries
            _createdCountries = _context.Country.ToList();
            _createdAirports = _context.Airport.ToList();

            //Created in DataSeeder
            _createdUsers = CreateUsers();
            _createdAirlineAlliances = CreateAirlineAlliance();
            _createdAirlines = CreateAirlines();
            _createdAircraftFactories = CreateAircraftFactories();
            _createdAircraftModels = CreateAircraftModel();
            _createdAircrafts = CreateAircrafts();
            _createdFlights = CreateFlights();

            var firstAsiaTrip = new Trip()
            {
                Name = "My First Asia Trip",
                TripManager = GetUser("Michał"),
                UserTrips = new List<UserTrip>()
                {
                    new UserTrip() { TUser = GetUser("Michał") }
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
                        Country = GetCountry("THA"),
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
                        Country = GetCountry("KHM"),
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
                        Country = GetCountry("VNM"),
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
                            new UserFlight() {TUser = GetUser("Michał") }
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
                            new UserFlight() {TUser = GetUser("Michał") }
                        }
                    }
                }
            };

            var azerbaijanTrip = new Trip()
            {
                Name = "My First Azerbaijan Trip",
                TripManager = GetUser("Michał"),
                UserTrips = new List<UserTrip>()
                {
                    new UserTrip() { TUser = GetUser("Michał")}
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
                        Country = GetCountry("AZE"),
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
                        Country = GetCountry("AZE"),
                        Latitude = 40.383333,
                        Longitude = 49.866667,
                        WorldHeritage = _context.WorldHeritage.Where(w => w.UnescoId == "958").FirstOrDefault()
                    }
                }
            };

            var threeAfricanCountriesTrip = new Trip()
            {
                Name = "Three African Countries Trip",
                TripManager = GetUser("Michał"),
                UserTrips = new List<UserTrip>()
                {
                    new UserTrip() { TUser = GetUser("Michał") }
                },
                Stops = new List<Stop>()
                {
                    new Stop()
                    {
                        Name = "Banjul",
                        Description = "First night in Banjul",
                        Order = 1,
                        Country = GetCountry("GMB"),
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
                        Country = GetCountry("GNB"),
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
                        Country = GetCountry("SEN"),
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
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 30,
                           Country = GetCountry("THA"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 70,
                           Country = GetCountry("KHM"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 40,
                           Country = GetCountry("VNM"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 90,
                           Country = GetCountry("AZE"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 60,
                           Country = GetCountry("MEX"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 60,
                           Country = GetCountry("GBR"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.BussinessTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 30,
                           Country = GetCountry("IND"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 60,
                           Country = GetCountry("CPV"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 40,
                           Country = GetCountry("GMB"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 30,
                           Country = GetCountry("SEN"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       },
                       new UserCountry()
                       {
                           TUser = GetUser("Michał"),
                           AreaLevelAssessment = 60,
                           Country = GetCountry("GNB"),
                           CountryKnowledgeType = UserCountry.CountryVisitType.RealTrip
                       }
                  );

            _context.SaveChanges();
        }

        private List<TUser> CreateUsers()
        {
            var users = new List<TUser>()
            {
                new TUser() { Id = "fec0a4d6-5830-4eb8-8024-272bd5d6d2bb", UserName = "Michał" },
                new TUser() { Id = "c3b7f625-c07f-4d7d-9be1-ddff8ff93b4d", UserName = "Aga" }
            };

            _context.AddRange(users);
            _context.SaveChanges();

            return users;
        }

        private List<Flight> CreateFlights()
        {
            var flights = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber = "P7 1754",
                    Aircraft = null,
                    Airline = GetAirline("LLC"),
                    DepartureAirport = GetAirport("WAW"),
                    DepartureDate = new DateTime(2015,8,29,3,0,0),
                    ScheduleDepartureDate = new DateTime(2015,8,29,3,0,0),
                    ArrivalAirport = GetAirport("KGS"),
                    ArrivialDate = new DateTime(2015,8,29,6,0,0),
                    ScheduleArrivialDate = new DateTime(2015,8,29,6,0,0),
                    Distance = 1775,
                    FlightTime = 2,
                    FlightTypeAssessment = Flight.FlightType.Charter,
                    UserFlights = new List<UserFlight>()
                    {
                        new UserFlight() { TUser = GetUser("Michał") }
                    }
                },
                new Flight()
                {
                    FlightNumber = "P7 1755",
                    Aircraft = null,
                    Airline = GetAirline("LLC"),
                    DepartureAirport = GetAirport("KGS"),
                    DepartureDate = new DateTime(2015,9,05,10,0,0),
                    ScheduleDepartureDate = new DateTime(2015,9,05,10,0,0),
                    ArrivalAirport = GetAirport("WAW"),
                    ArrivialDate = new DateTime(2015,9,05,12,0,0),
                    ScheduleArrivialDate = new DateTime(2015,9,05,12,0,0),
                    Distance = 1775,
                    FlightTime = 2,
                    FlightTypeAssessment = Flight.FlightType.Charter,
                    UserFlights = new List<UserFlight>()
                    {
                        new UserFlight() { TUser = GetUser("Michał") }
                    }
                }
            };

            _context.AddRange(flights);
            _context.SaveChanges();

            return flights;
        }

        private List<Aircraft> CreateAircrafts()
        {
            var aircrafts = new List<Aircraft>()
            {
                new Aircraft() { AircraftModel = GetAircraftModel(""), TailNumber = ""}
            };

            _context.AddRange(aircrafts);
            _context.SaveChanges();

            return aircrafts;
        }

        private List<AirLineAlliance> CreateAirlineAlliance()
        {
            var airlineAlliences = new List<AirLineAlliance>()
            {
                new AirLineAlliance() { Name = "SkyTeam"},
                new AirLineAlliance() { Name = "Star Alliance"}
            };

            _context.AddRange(airlineAlliences);
            _context.SaveChanges();

            return airlineAlliences;
        }

        private List<AircraftFactory> CreateAircraftFactories()
        {
            var aircraftFactories = new List<AircraftFactory>()
            {
                new AircraftFactory() {  Name = "Boeing", AircraftFactoryCountry = GetCountry("USA") },
                new AircraftFactory() { Name = "Airbus", AircraftFactoryCountry = GetCountry("FRA") },
                new AircraftFactory() { Name = "Embraer", AircraftFactoryCountry = GetCountry("BRA") },
                new AircraftFactory() { Name = "ATR", AircraftFactoryCountry = GetCountry("FRA") }
            };

            _context.AddRange(aircraftFactories);
            _context.SaveChanges();

            return aircraftFactories;
        }

        private List<AircraftModel> CreateAircraftModel()
        {
            AircraftFactory boeing = GetAircrafFactory("Boeing");
            AircraftFactory atr = GetAircrafFactory("ATR");
            AircraftFactory airbus = GetAircrafFactory("Airbus");
            AircraftFactory embraer = GetAircrafFactory("Embraer");

            var aircraftModels = new List<AircraftModel>()
            {
                new AircraftModel() { AircraftFactory = boeing, Model = "737-700" },
                new AircraftModel() { AircraftFactory = boeing, Model = "737-800" },
                new AircraftModel() { AircraftFactory = boeing, Model = "737 MAX 8" },
                new AircraftModel() { AircraftFactory = boeing, Model = "777-300ER" },
                new AircraftModel() { AircraftFactory = boeing, Model = "787-8" },
                new AircraftModel() { AircraftFactory = boeing, Model = "787-9" },

                new AircraftModel() { AircraftFactory = atr, Model = "72" },

                new AircraftModel() { AircraftFactory = airbus, Model = "A318" },
                new AircraftModel() { AircraftFactory = airbus, Model = "A320" },
                new AircraftModel() { AircraftFactory = airbus, Model = "A321" },
                new AircraftModel() { AircraftFactory = airbus, Model = "A330-200" },
                new AircraftModel() { AircraftFactory = airbus, Model = "A380-800" },

                new AircraftModel() { AircraftFactory = embraer, Model = "190" }
            };

            _context.AddRange(aircraftModels);
            _context.SaveChanges();

            return aircraftModels;
        }

        private List<Airline> CreateAirlines()
        {
            var airlines = new List<Airline>()
            {
                new Airline() {Name = "WizzAir", AirlineCountry = GetCountry("HUN"), IATA = "W6", ICAO = "WZZ"},
                new Airline() {Name = "Enter Air", AirlineCountry = GetCountry("POL"), IATA = "E4", ICAO = "ENT" },
                new Airline() {Name = "Ryanair", AirlineCountry = GetCountry("IRL"), IATA = "FR", ICAO = "RYR" },
                new Airline() {Name = "Emirates", AirlineCountry = GetCountry("ARE"), IATA = "EK", ICAO = "UAE"},
                new Airline() {Name = "Travel Service Poland", AirlineCountry = GetCountry("POL"), IATA = "3Z", ICAO = "TVP"},
                new Airline() {Name = "Small Planet", AirlineCountry = GetCountry("LTU"), IATA = "S5", ICAO = "LLC"},
                new Airline() {Name = "Binter", AirlineCountry = GetCountry("ESP"), IATA = "NT", ICAO = "IBB"},
                new Airline() {Name = "Volaris", AirlineCountry = GetCountry("MEX"), IATA = "Y4", ICAO = "VOI"},
                new Airline() {Name = "Air France", AirlineCountry = GetCountry("FRA"),IATA = "AF", ICAO = "AFR", AirLineAlliance = GetAirlineAlliance("SkyTeam")},
                new Airline() {Name = "KLM", AirlineCountry = GetCountry("NLD"), IATA = "KL", ICAO = "KLM", AirLineAlliance = GetAirlineAlliance("SkyTeam")},
                new Airline() {Name = "LOT", AirlineCountry = GetCountry("POL"), IATA = "LO", ICAO = "LOT", AirLineAlliance = GetAirlineAlliance("Star Alliance")},
                new Airline() {Name = "Turkish Airlines", AirlineCountry = GetCountry("TUR"), IATA = "TK", ICAO = "THY", AirLineAlliance = GetAirlineAlliance("Star Alliance")},
            };

            _context.AddRange(airlines);
            _context.SaveChanges();

            return airlines;
        }

        private TUser GetUser(string name)
        {
            return _createdUsers.Where(u => u.UserName == name).FirstOrDefault();
        }

        private Airport GetAirport(string iataCode)
        {
            return _createdAirports.Where(a => a.IATA == iataCode).FirstOrDefault();
        }

        private Aircraft GetAircraft(string tailNumber)
        {
            return _createdAircrafts.Where(a => a.TailNumber == tailNumber).FirstOrDefault();
        }

        private Airline GetAirline (string icaoCode)
        {
            return _createdAirlines.Where(a => a.ICAO == icaoCode).FirstOrDefault();
        }

        private AircraftModel GetAircraftModel (string model )
        {
            return _createdAircraftModels.Where(m => m.Model == model).FirstOrDefault();
        }

        private Country GetCountry(string alpha3Code)
        {
            return _createdCountries.Where(c => c.Alpha3Code == alpha3Code).FirstOrDefault();
        }

        private AircraftFactory GetAircrafFactory(string name)
        {
            return _createdAircraftFactories.Where(m => m.Name == name).FirstOrDefault();
        }

        private AirLineAlliance GetAirlineAlliance(string name)
        {
            return _createdAirlineAlliances.Where(a => a.Name == name).FirstOrDefault();
        }
    }
}
