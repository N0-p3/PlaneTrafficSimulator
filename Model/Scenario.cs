using System.Collections.Generic;
using static FlightSim.Model.Client_Factory;

namespace FlightSim.Model
{
    public class Scenario
    {
        //Data members
        private List<Airport> _airports;
        private List<Aircraft> _aircrafts;
        private List<Client> _clients;

        //Constructor
        public Scenario(List<Airport> airports, List<Aircraft> aircrafts)
        {
            _airports = airports;
            _aircrafts = aircrafts;
            _clients = new List<Client>();
        }
        
        //Functions
        public void LookForMatch()
        {
            //TODO : Implement observer/observable
            
            foreach (Airport airport in _airports)
            {
                airport.LookForMatch();
            }
        }

        public void PassTime(int seconds)
        {
            //TODO : Implement
        }
        
        public void GenerateClient(string type)
        {
            _clients.Add(GetFactory().CreateClient(type));
        }
    }
}