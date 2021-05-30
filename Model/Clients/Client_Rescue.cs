using System;

namespace FlightSim.Model.Clients
{
    public class Client_Rescue : Client_Special
    {
        //Property
        public override char Type => 'R';
        
        //Constructor
        public Client_Rescue()
        {
            _nearestAirport = FindNearestAirport('R');
        }
    }
}