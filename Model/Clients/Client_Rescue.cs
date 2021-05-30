using System;

namespace FlightSim.Model.Clients
{
    public class Client_Rescue : Client_Special
    {
        //Constructor
        public Client_Rescue()
        {
            _nearestAirport = FindNearestAirport('R');
        }
    }
}