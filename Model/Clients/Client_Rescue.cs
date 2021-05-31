using System;

namespace FlightSim.Model.Clients
{
    public class Client_Rescue : Client_Special
    {
        //Property
        public override char Type => 'R';
        
        //Constructor
        public Client_Rescue(Position pos, Airport nearestAirport) : base(pos)
        {
            _nearestAirport = nearestAirport;
        }
    }
}