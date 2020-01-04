using MCB.Data.Domain.Aviation;
using MCB.Data.Domain.Trips;
using MCB.Data.Domain.User;
using System;
using System.Collections.Generic;

namespace MCB.Data.Domain.Flights
{
    public class Flight
    {
        public Flight()
        {
            UserFlights = new List<UserFlight>();
        }
        public int Id { get; set; }
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivialDate { get; set; }

        public Airport DepartureAirport { get; set; }

        public Airport ArrivalAirport { get; set; }

        public Trip Trip { get; set; }
        public int? TripId { get; set; }

        public FlightType FlightTypeAssessment { get; set; }

        public enum FlightType
        {
            Charter,
            Scheduled
        }

        public List<UserFlight> UserFlights { get; set; }

        public IEnumerable<TUser> Users()
        {
            var users = new List<TUser>();
            foreach (var join in UserFlights)
            {
                users.Add(join.TUser);
            }
            return users;
        }
    }
}
