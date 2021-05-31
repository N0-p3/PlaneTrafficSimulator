using FlightSim.Model.Aircrafts;

namespace FlightSim.Model.Clients
{
    public abstract class Client_Special : Client
    {
        //Data members
        private Position _pos;             //The position of the Client
        protected Airport _nearestAirport; //The Client's nearest Airport that has an Aircraft that can help 

        //Property
        /*
         * Sends the position of the Client
         */
        public Position Position => _pos;
        
        //Constructor
        /*
         * Creates a Special Client according to it's position
         * pos : The position of the Special Client
         */
        protected Client_Special(Position pos)
        {
            _pos = pos;
            SendPosition();
        }
        
        //Function
        /*
         * Notifies the nearest Airport that can help the Client to send an Aircraft 
         */
        protected void SendPosition()
        {
            _nearestAirport.ReceivePosition(this);
        }
    }
}