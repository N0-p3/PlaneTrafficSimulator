using FlightSim.Model.Aircrafts;

namespace FlightSim.Model.Clients
{
    public abstract class Client_Special : Client
    {
        //Data members
        private Position _pos;
        protected Airport _nearestAirport;

        public Position Position => _pos;
        
        //Constructor
        protected Client_Special(Position pos)
        {
            _pos = pos;
        }
        
        //Function
        protected void SendPosition(Aircraft ac)
        {
            _nearestAirport.ReceivePosition(ac, this);
        }
    }
}