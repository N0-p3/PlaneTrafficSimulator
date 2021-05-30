using System;

namespace FlightSim.Model.Clients
{
    public class Client_Observer : Client_Special
    {
        //Property
        public override char Type => 'O';
        
        //Constructor
        public Client_Observer()
        {
            _nearestAirport = FindNearestAirport('O');
        }
    }
}