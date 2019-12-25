namespace MCB.Business.Models.Geo
{
    public class RegionModel : RegionAbstractBase
    {
        public int Id { get; set; }
        public ContinentModel Continent { get; set; }
    }
}
