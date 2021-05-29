using FlightSim.Model.Clients;

namespace FlightSim.Model
{
    public class Client_Factory
    {
        //data member
        private static Client_Factory _factory = null;
        
        //Constructor
        private Client_Factory() {}
        
        //Functions
        public static Client_Factory GetFactory()
        {
            if (_factory is null)
            {
                _factory = new Client_Factory();
            }

            return _factory;
        }
        
        public Client CreateClient(string type)
        {
            switch (type)
            {
                case "f":
                    return new Client_Fire();
                
                case "r":
                    return new Client_Rescue();
                
                case "o":
                    return new Client_Observer();
                
                case "c":
                    return new Client_Cargo();
                
                default:
                    return new Client_Passenger();
            }
        }
    }
}