namespace FlightSim.Model.Clients
{
    public abstract class Client_Normal : Client
    {
        //Data member
        private Airport _destination;

        //Properties;
        public Airport Destination
        {
            get { return _destination; }
        }
        
        //Constructor
        public Client_Normal(Airport destination)
        {
            _destination = destination;
        }
    }
}