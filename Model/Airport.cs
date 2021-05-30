using System.Collections.Generic;
using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;
using FlightSim.Model.States;

namespace FlightSim.Model
{
    public class Airport
    {
        //Data members
        private string _name;
        private Position _position;
        private List<Aircraft> _aircrafts;
        private List<Client> _clients;

        //Constructor
        public Airport(string name, Position pos, List<Aircraft> aircrafts)
        {
            _name = name;
            _position = pos;
            _aircrafts = aircrafts;
            _clients = new List<Client>();
        }
        
        //Function
        public bool HasSpecificAircraft(char type)
        {
            foreach (Aircraft aircraft in _aircrafts)
                if (aircraft.Type == type)
                    return true;
            
            return false;
        }

        public void ReceivePosition(Aircraft ac, Client client)
        {
            Match(ac, client);
        }
        
        public void LookForMatch()
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }

        private void Match(Aircraft ac, Client client)
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }

        private void BeginBoarding(Aircraft ac, Client client)
        {
            ac.State = new State_Boarding(ac, client, this);
        }
        
        private void BeginFlight(Aircraft ac, Client client)
        {
            State flightState;

            if (ac.Type == 'R')
                flightState = new State_ComeBackFlight(ac, (Client_Special) client);
            else
                flightState = new State_ObserverFlight(ac, (Client_Special) client);
            
            ac.State = flightState;
        }
    }
}