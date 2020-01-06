using MCB.Data.Domain.Aviation;
using MCB.Data.Domain.Geo;
using MCB.Data.Domain.WorldHeritages;
using MCB.Data.LoadData;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using static MCB.Data.LoadData.CountriesModel;

namespace MCB.Data
{
    public class MCBDictionarySeeder
    {
        private readonly MCBContext _context;
        public MCBDictionarySeeder(MCBContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            _context.Database.Migrate();

            SeedCountries();
            SeedWroldHeritage();
            SeedAirports();
        }

        private void SeedAirports()
        {
            if (_context.Airport.Any()) return;

            var airportsFilePath = Path.Combine(AppContext.BaseDirectory, "LoadData\\airports.dat.txt");

            using (var reader = new StreamReader(airportsFilePath))
            {
                var listOfAirports = new List<Airport>();
                var countriesDictonary = new Dictionary<int, string>();
                foreach (var country in _context.Country.ToList())
                {
                    countriesDictonary.Add(country.Id, country.Name);
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Replace("\"", "");
                    var values = line.Split(',');

                    var airport = new Airport()
                    {
                        AirportId = values[0],
                        Name = values[1],
                        City = values[2],
                        CountryName = values[3],
                        IATA = values[4],
                        ICAO = values[5]
                        //TODO: Fix an convert issue for airport latitude and longitude
                        //Latitude = Convert.ToInt64(values[6]),
                        //Longitude = Convert.ToInt64(values[7])
                    };

                    switch (values[3])
                    {
                        case "Reunion":
                            values[3] = "Réunion";
                            break;
                        case "Burma":
                            values[3] = "Myanmar";
                            break;
                        case "Congo (Brazzaville)":
                            values[3] = "DR Congo";
                            break;
                        case "Congo (Kinshasa)":
                            values[3] = "DR Congo";
                            break;
                        case "Czech Republic":
                            values[3] = "Czechia";
                            break;
                    }

                    var countryId = countriesDictonary.Where(c => c.Value == values[3]).Select(c => c.Key).FirstOrDefault();
                    if (countryId != 0)
                    {
                        airport.CountryId = countryId;
                    }

                    listOfAirports.Add(airport);
                }
                _context.AddRange(listOfAirports);
                _context.SaveChanges();
            }
        }

        private void SeedWroldHeritage()
        {
            if (_context.WorldHeritage.Any()) return;

            XmlSerializer deserializer = new XmlSerializer(typeof(Rows));

            var worldHeritageFilePath = Path.Combine(AppContext.BaseDirectory, "LoadData\\WorldHeritage.xml");

            TextReader textReader = new StreamReader(worldHeritageFilePath);
            Rows worldHeritage;

            worldHeritage = (Rows)deserializer.Deserialize(textReader);

            var worldHeritageList = new List<WorldHeritage>();
            var listOfLinkedEntities = new List<WorldHeritageCountry>();

            foreach (var item in worldHeritage.Row)
            {
                var listOfCountries = item.Iso_code.ToUpper(CultureInfo.CurrentCulture).Split(',').ToList();

                var newWorldHeritage = new WorldHeritage()
                {
                    UnescoId = item.Id_number,
                    ImageUrl = item.Image_url,
                    IsoCodes = item.Iso_code,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Location = item.Location,
                    Region = item.Region
                };

                var listOfCountriesFromDb = new List<Country>();

                foreach (var country in listOfCountries)
                {
                    var countryFromDb = _context.Country.Where(c => c.Alpha2Code == country).FirstOrDefault();

                    if (countryFromDb != null)
                    {
                        listOfCountriesFromDb.Add(countryFromDb);

                        if (listOfCountries.Count == listOfCountriesFromDb.Count)
                        {
                            foreach (var countryToIclude in listOfCountriesFromDb)
                            {
                                listOfLinkedEntities.Add(new WorldHeritageCountry { Country = countryToIclude, WorldHeritage = newWorldHeritage });
                            }
                        }
                    }
                }

                worldHeritageList.Add(newWorldHeritage);
            }

            _context.AddRange(worldHeritageList);
            _context.AddRange(listOfLinkedEntities);
            _context.SaveChanges();

            textReader.Close();
        }

        private void SeedCountries()
        {
            if (_context.Country.Any()) return;

            var countriesFilePath = Path.Combine(AppContext.BaseDirectory, "LoadData\\countries.json");

            using (StreamReader r = new StreamReader(countriesFilePath))
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                string json = r.ReadToEnd();
                List<CountriesDataModel> items = JsonConvert.DeserializeObject<List<CountriesDataModel>>(json, settings);
                foreach (var item in items)
                {
                    var continent = new Continent();

                    var existingContinent = _context.Continent.Where(c => c.Name == item.region).FirstOrDefault();

                    if (existingContinent == null)
                    {
                        continent = new Continent() { Name = item.region };
                        _context.Add(continent);
                        _context.SaveChanges();
                    }
                    else
                    {
                        continent = existingContinent;
                    }

                    var region = new Region();
                    var existingRegion = _context.Region.Where(rg => rg.Name == item.subregion).FirstOrDefault();

                    if (existingRegion == null)
                    {
                        region = new Region() { Name = item.subregion, Continent = continent };
                        _context.Add(region);
                        _context.SaveChanges();
                    }
                    else
                    {
                        region = existingRegion;
                    }

                    var newCountry = new Country()
                    {
                        Name = item.name.common,
                        OfficialName = item.name.official,
                        Alpha2Code = item.cca2,
                        Alpha3Code = item.cca3,
                        Area = item.area,
                        Region = region
                    };
                    _context.Add(newCountry);
                    _context.SaveChanges();
                }
            }

        }
    }
}