using MCB.Data.Domain.Geo;

namespace MCB.Data.Domain.WorldHeritages
{
    public class WorldHeritageCountry
    {
        public int WorldHeritageId { get; set; }
        public WorldHeritage WorldHeritage { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}