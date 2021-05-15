namespace FlightSim.Model
{
    public class Client_Factory
    {
        //data member
        private static Client_Factory _factory = null;
        
        //Constructor
        private Client_Factory() {}
        
        //Functions
        public Client CreateClient()
        {
            //Logique de création de clients
        }

        public static Client_Factory GetFactory()
        {
            if (_factory is null)
            {
                _factory = new Client_Factory();
            }

            return _factory;
        }
    }
}