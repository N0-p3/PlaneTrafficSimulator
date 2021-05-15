using System.Collections.Generic;

namespace FlightSim.Model
{
    public class Scenario
    {
        //Data members
        private Client_Factory _clientFactory;
        private List<Airport> _airports;
        private List<Aircraft> _aircrafts;
        private List<Client> _clients;
        
        //Properties
        public Client_Factory ClientFactory
        {
            get { return _clientFactory; }
        }
        
        //Constructor
        public Scenario(List<Airport> airports, List<Aircraft> aircrafts)
        {
            _airports = airports;
            _aircrafts = aircrafts;
            _clientFactory = Client_Factory.GetFactory();
            _clients = new List<Client>();
        }
        
        //Functions
        public Client GenerateClient()
        {
            return _clientFactory.CreateClient();
        }
    }
}