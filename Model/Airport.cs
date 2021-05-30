using System.Collections.Generic;
using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;
using FlightSim.Model.States;

namespace FlightSim.Model
{
    public delegate void RemoveAircraft(Aircraft ac);
    
    public class Airport
    {
        //Data members
        private RemoveAircraft _removeAircraft;
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
        public bool HasSpecific<T>(char type, List<T> list, out T found)
            where T : class, ISpecific
        {
            foreach (T item in list)
                if (item.Type == type)
                {
                    found = item;
                    return true;
                }

            found = null; 
            return false;
        }

        public void LookForMatch(char type, Client client, Aircraft ac)
        {
            if (client != null && HasSpecific(type, _aircrafts, out Aircraft aircraftFound))
                Match(aircraftFound, client);
            else if (ac != null && HasSpecific(type, _clients, out Client_Normal clientFound))
                Match(ac, clientFound);
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
            LookForMatch(client.Type, client, null);
        }
        
        public void AddAircraft(Aircraft ac)
        {
            _aircrafts.Add(ac);
            LookForMatch(ac.Type, null, ac);
        }

        public void AssignRemoveAircraftDelegate(RemoveAircraft removeAircraft)
        {
            _removeAircraft = removeAircraft;
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
            //Put the aircraft in the scenario
            RemoveAircraft(ac);
        }
        
        private void BeginFlight(Aircraft ac, Client client)
        {
            State flightState;

            if (ac.Type == 'R')
                flightState = new State_ComeBackFlight(ac, (Client_Special) client);
            else
                flightState = new State_ObserverFlight(ac, (Client_Special) client);
            
            ac.State = flightState;
            //Put the aircraft in the scenario
            RemoveAircraft(ac);
        }

        private void RemoveClient(Client_Normal client)
        {
            _clients.Remove(client);
        }

        private void RemoveAircraft(Aircraft ac)
        {
            _aircrafts.Remove(ac);
            _removeAircraft?.Invoke(ac);
        }
    }
}