using System;
using System.Security.Claims;

namespace Avia1
{
    public class Ticket
    {
        public string FlightDestination { get; set; }
        public string Destination { get; set; }
        public string TripType { get; set; }
        public string Class { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime OrderTime { get; set; }
        public string Status { get; set; }
    }
   
}
