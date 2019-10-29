namespace MCB.Business.Models.WorldHeritages
{
    public class WorldHeritageModel 
    {
        public int Id { get; set; }
        public string UnescoId { get; set; }
        public string ImageUrl { get; set; }
        public string IsoCodes { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Location { get; set; }
        public string Region { get; set; }
    }
}
