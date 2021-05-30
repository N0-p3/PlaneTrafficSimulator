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
        private byte _traffic;
        private Position _position;
        private List<Aircraft> _aircrafts;
        private List<Client_Normal> _clients;
        
        //Property
        public byte Traffic => _traffic;

        //Constructor
        public Airport(string name, Position pos, List<Aircraft> aircrafts)
        {
            _name = name;
            _position = pos;
            _aircrafts = aircrafts;
            _clients = new List<Client_Normal>();
        }
        
        //Function
        public bool HasSpecificAircraft(char type)
        {
            foreach (Aircraft aircraft in _aircrafts)
                if (aircraft.Type == type)
                    return true;
            
            return false;
        }

        public void LookForMatch()
        {
            if (HasSpecificAircraft())
            {
                
            }
        }

        public void AddClient(Client_Normal client)
        {
            Client_Normal clientToMerge = null;

            foreach (Client_Normal clientLoop in _clients)
                if (clientLoop.Destination == client.Destination)
                    clientToMerge = clientLoop;


            if (clientToMerge != null && clientToMerge.Type == client.Type)
            {
                if (client.Type == 'P')
                    _clients.Add(Client.MergePassengerClient((Client_Passenger)clientToMerge, (Client_Passenger)client));
                else
                    _clients.Add(Client.MergeCargoClient((Client_Cargo)clientToMerge, (Client_Cargo)client));
            }
            else
                _clients.Add(client);
            LookForMatch();
        }
        
        public void AddAircraft(Aircraft ac)
        {
            _aircrafts.Add(ac);
        }

        public void ReceivePosition(Aircraft ac, Client client)
        {
            Match(ac, client);
        }

        private void Match(Aircraft ac, Client client)
        {
            if (ac.Type == 'P' || ac.Type == 'C' || ac.Type == 'T')
                BeginBoarding(ac, client);
            else
                BeginFlight(ac, client);
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

        private void RemoveClient(Client_Normal client)
        {
            _clients.Remove(client);
        }

        private void RemoveAircraft(Aircraft ac)
        {
            _aircrafts.Remove(ac);
        }
    }
}