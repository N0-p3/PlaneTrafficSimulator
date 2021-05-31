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
        
        //Properties
        public byte Traffic => _traffic;
        public Position Position => _position;

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
            switch (ac.Type)
            {
                case 'P':
                case 'C':
                    ac.State.Enqueue(new State_Boarding(ac));
                    ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Normal)client).Destination, _position));
                    ac.State.Enqueue(new State_Unloading((Aircraft_Normal)ac));
                    ac.State.Enqueue(new State_Maintenance(ac));
                    ac.State.Enqueue(new State_Waiting(ac));
                    break;
                case 'F':
                    ac.State.Enqueue(new State_Boarding(ac));
                    int spread = ((Client_Fire) client).Spread;
                    while (spread > 0)
                    {
                        ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Special) client).Position, _position));
                        ac.State.Enqueue(new State_OneWayFlight(ac, _position, ((Client_Special) client).Position));
                        spread--;
                    }
                    ac.State.Enqueue(new State_Maintenance(ac));
                    ac.State.Enqueue(new State_Waiting(ac));
                    break;
            }
            
            ac.State.Dequeue();
            RemoveAircraft(ac);
        }
        
        private void BeginFlight(Aircraft ac, Client client)
        {
            switch (ac.Type)
            {
                case 'O':
                    ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Special) client).Position, _position));
                    ac.State.Enqueue(new State_Maintenance(ac));
                    ac.State.Enqueue(new State_OneWayFlight(ac, _position, ((Client_Special) client).Position));
                    ac.State.Enqueue(new State_Maintenance(ac));
                    ac.State.Enqueue(new State_Waiting(ac));
                    break;
                case 'R':
                    ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Special) client).Position, _position));
                    ac.State.Enqueue(new State_OneWayFlight(ac, _position, ((Client_Special) client).Position));
                    break;
            }
            
            ac.State.Dequeue();
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