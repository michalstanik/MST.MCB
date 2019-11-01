using MCB.Data.Domain.Geo;
using MCB.Data.Domain.WorldHeritages;
using MCB.Data.LoadData;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
        public async Task Seed()
        {
            _context.Database.Migrate();

            await SeedCountries();
            await SeedWroldHeritage();
        }

        private async Task SeedWroldHeritage()
        {
            if (_context.WorldHeritage.Count() != 0) return;

            XmlSerializer deserializer = new XmlSerializer(typeof(Rows));

            TextReader textReader = new StreamReader(@"C:/Users/michal.stanik/Source/Repos/michalstanik/MCB/MCB/MCB.Data/LoadData/WorldHeritage.xml");
            Rows worldHeritage;

            worldHeritage = (Rows)deserializer.Deserialize(textReader);

            var worldHeritageList = new List<WorldHeritage>();
            var listOfLinkedEntities = new List<WorldHeritageCountry>();

            foreach (var item in worldHeritage.Row)
            {
                var listOfCountries = item.Iso_code.ToUpper().Split(',').ToList();

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

                        if (listOfCountries.Count() == listOfCountriesFromDb.Count())
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
            await _context.SaveChangesAsync();

            textReader.Close();
        }

        private async Task SeedCountries()
        {
            if (_context.Country.Count() != 0) return;

            //TODO: PROD: Below source should be relative
            using (StreamReader r = new StreamReader("C:/Users/michal.stanik/Source/Repos/michalstanik/MCB/MCB/MCB.Data/LoadData/countries.json"))
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
                    await _context.SaveChangesAsync();
                }
            }

        }
    }
}