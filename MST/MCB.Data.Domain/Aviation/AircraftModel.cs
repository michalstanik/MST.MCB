using System.Collections.Generic;

namespace MCB.Data.Domain.Aviation
{
    public class AircraftModel
    {
        //Fields
        public int Id { get; set; }
        public string Model { get; set; }

        //FKs
        public int? AircraftFactoryId { get; set; }
        public AircraftFactory AircraftFactory { get; set; }

        //Navigation Properties
        public List<Aircraft> Aircrafts { get; set; }
    }
}