using System;

namespace FlightSim.Model.Clients
{
    public class Client_Fire : Client_Special
    {
        //Data member
        private byte _spread;
        
        //Property
        public byte Spread => _spread;
        public override char Type => 'F';

        //Constructor
        public Client_Fire(byte spread)
        {
            _spread = spread;
            _nearestAirport = FindNearestAirport('T');
        }
    }
}