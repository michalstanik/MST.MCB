using MCB.Business.Models.Aviation;

namespace MCB.Business.Models.Flights
{
    public class FlightModelFull : FlightModel
    {
        public AircraftBusinessModel Aircraft { get; set; }

        public AirlineModel Airline { get; set; }
    }
}
