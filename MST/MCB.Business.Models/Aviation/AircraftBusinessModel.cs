namespace MCB.Business.Models.Aviation
{
    public class AircraftBusinessModel
    {
        public int Id { get; set; }
        public string TailNumber { get; set; }

        public AircraftModelBusinessModel AircraftModel { get; set; }
    }
}