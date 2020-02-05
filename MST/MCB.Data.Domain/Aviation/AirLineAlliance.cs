using System.Collections.Generic;

namespace MCB.Data.Domain.Aviation
{
    public class AirLineAlliance
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Airline> Airlines { get; set; }
    }
}