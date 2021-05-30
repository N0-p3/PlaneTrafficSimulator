using System;

namespace FlightSim.Model.Clients
{
    public class Client_Observer : Client_Special
    {
        //Constructor
        public Client_Observer()
        {
            _nearestAirport = FindNearestAirport('O');
        }
    }
}