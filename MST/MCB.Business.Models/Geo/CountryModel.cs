namespace MCB.Business.Models.Geo
{
    public class CountryModel
    {
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public long Area { get; set; }
        public string RegionName { get; set; }
        public string RegionContinentName { get; set; }
    }
}
