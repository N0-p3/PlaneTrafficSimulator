namespace FlightSim.Model.Clients
{
    public abstract class Client_Normal : Client
    {
        //Data member
        private Airport _destination; //The destination (which happens to be an Airport) of the Client

        //Properties
        /*
         * Sends the position of the destination (which happens to be the Airport)
         */
        public Position Destination => _destination.Position;
        
        /*
         * Sends the Airport (which happens to be the destination)
         */
        public Airport AirportDestination => _destination;
        
        //Constructor
        /*
         * Creates a Normal Client according to it's destination
         * destination : The Airport that is also it's destination
         */
        public Client_Normal(Airport destination)
        {
            _destination = destination;
        }
    }
}