namespace FlightSim.Model.Clients
{
    public abstract class Client_Normal : Client
    {
        //Data member
        private Position _destination;

        //Properties
        public Position Destination => _destination;
        
        //Constructor
        public Client_Normal(Position destination)
        {
            _destination = destination;
        }
    }
}