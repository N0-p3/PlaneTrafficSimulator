﻿using System.Collections.Generic;
using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;
using FlightSim.Model.States;

namespace FlightSim.Model
{
    public delegate void RemoveAircraft(Aircraft ac);
    
    public class Airport
    {
        //Data members
        private RemoveAircraft _removeAircraftAction; //The delegate associated with removing an Aircraft from an Airport and giving it to the Scenario
        private Land _landAction;                     //The delegate associated with adding an Aircraft to the Airport and removing it from the Scenario 
        private string _name;                         //The name of the Airport
        private byte _traffic;                        //The amount of clients generated by the hour
        private Position _position;                   //The Position of the Airport
        private List<Aircraft> _aircrafts;            //Every Aircrafts in the Airport
        private List<Client_Normal> _clients;         //Every clients in the Airport
        
        //Properties
        /*
         * Sends the traffic of the Airport
         */
        public byte Traffic => _traffic;
        
        /*
         * Sends the Position of the Airport
         */
        public Position Position => _position;

        //Constructor
        /*
         * Creates the Airport according to it's name, position and list of Aircraft
         * name      : The name of the Airport
         * pos       : The Position of the Airport
         * aircrafts : Every Aircrafts in the Airport
         */
        public Airport(string name, Position pos, List<Aircraft> aircrafts)
        {
            _name = name;
            _position = pos;
            _aircrafts = aircrafts;
            _clients = new List<Client_Normal>();
        }
        
        //Function
        /*
         * Checks if the Airport has a specific Client or a specific Aircraft, if it does it sends a boolean warning the
         * caller that it did indeed have what the caller asked for and it also sends the item it found OR null if none
         * were found.
         * type  : The type of either Client of Aircraft represented in a char
         * list  : The list in which it should look for to search the element asked by the caller
         * found : The element found in the list, if it is null, it didn't find anything
         */
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

        /*
         * Looks for matches between it's Aircrafts and it's clients, if a match is found, it matches them together. This
         * function is called when we either add an Aircraft OR when we add a client.
         *
         * Why can client or ac be null?
         * because if we call the method when we add a new client, we'll give it a null as the Aircraft which will make it
         * look in it's Aircrafts and check if it has a fittable Aircraft for that new client and vice-versa.
         * 
         * type   : The type of either Client of Aircraft represented in a char
         * client : The client that needs to be matched
         * ac     : The Aircraft that needs to be matched
         */
        public void LookForMatch(char type, Client client, Aircraft ac)
        {
            if (client != null && HasSpecific(type, _aircrafts, out Aircraft aircraftFound) && aircraftFound.Type == client.Type)
                Match(aircraftFound, client);
            else if (ac != null && HasSpecific(type, _clients, out Client_Normal clientFound) && ac.Type == client.Type)
                Match(ac, clientFound);
        }

        /*
         * Adds a client and merges the new client with an old one if necessary, then it looks for a match with that new
         * client.
         * client : The client that we add to the Airport's list
         */
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
        
        /*
         * Adds an Aircraft to the Airport and looks for a match with that new Aircraft.
         * ac : The new Aircraft
         */
        public void AddAircraft(Aircraft ac)
        {
            _aircrafts.Add(ac);
            LookForMatch(ac.Type, null, ac);
        }

        /*
         * Assigns the remove Aircraft delegate to the Airport.
         * removeAircraft : The delegate to assign
         */
        public void AssignRemoveAircraftDelegate(RemoveAircraft removeAircraft)
        {
            _removeAircraftAction = removeAircraft;
        }

        /*
         * Assigns the land delegate to the Airport.
         * land : The delegate to assign
         */
        public void AssignLandDelegate(Land land)
        {
            _landAction = land;
        }

        /*
         * Receives a help call from a Special Client and matches the Client with an Aircraft according to the Client's
         * need.
         * client : The client sending the call
         */
        public void ReceivePosition(Client client)
        {
            Aircraft aircraft = _aircrafts.Find(ac => ac.Type == client.Type);
            Match(aircraft, client);
        }

        /*
         * Matches an Aircraft with a Client.
         * ac     : The Aircraft that needs to be matched with the client
         * client : The client that needs to be matched with the Aircraft
         */
        private void Match(Aircraft ac, Client client)
        {
            if (ac.Type == 'P' || ac.Type == 'C' || ac.Type == 'T')
            {
                if (ac.Type == 'P' && ((Aircraft_Passenger)ac).Capacity >= ((Client_Passenger)client).AmountOfPassengers)
                    BeginBoarding(ac, client);
                else if (ac.Type == 'P' && ((Aircraft_Passenger) ac).Capacity < ((Client_Passenger) client).AmountOfPassengers)
                {
                    Client_Passenger[] clientTab = Client.SplitPassengerClient(((Client_Passenger) client), ((Aircraft_Passenger) ac).Capacity);
                    BeginBoarding(ac, clientTab[0]);
                    AddClient(clientTab[1]);
                }
                else if (ac.Type == 'C' && ((Aircraft_Cargo) ac).Capacity >= ((Client_Cargo) client).TonsOfCargo)
                    BeginBoarding(ac, client);
                else if (ac.Type == 'C' && ((Aircraft_Cargo) ac).Capacity < ((Client_Cargo) client).TonsOfCargo)
                {
                    Client_Cargo[] clientTab = Client.SplitCargoClient(((Client_Cargo) client), ((Aircraft_Cargo) ac).Capacity);
                    BeginBoarding(ac, clientTab[0]);
                    AddClient(clientTab[1]);
                }
                else
                    BeginBoarding(ac, client);
            }
            else
                BeginFlight(ac, client);
        }

        /*
         * Starts the Boarding State of an Aircraft (and also gives it all of it's future action after the boarding until
         * it is back to waiting).
         * ac     : The Aircraft that will begin the Boarding State
         * client : The client that the Aircraft will fly with OR fly to
         */
        private void BeginBoarding(Aircraft ac, Client client)
        {
            switch (ac.Type)
            {
                case 'P':
                case 'C':
                    ac.State.Enqueue(new State_Boarding(ac));
                    ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Normal)client).Destination, _position, _landAction));
                    ac.State.Enqueue(new State_Unloading((Aircraft_Normal)ac));
                    ac.State.Enqueue(new State_Maintenance(ac));
                    ac.State.Enqueue(new State_Waiting(ac));
                    RemoveClient(((Client_Normal)client));
                    break;
                case 'F':
                    ac.State.Enqueue(new State_Boarding(ac));
                    int spread = ((Client_Fire) client).Spread;
                    while (spread > 1)
                    {
                        ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Special) client).Position, _position));
                        ac.State.Enqueue(new State_OneWayFlight(ac, _position, ((Client_Special) client).Position));
                        spread--;
                    }
                    ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Special) client).Position, _position));
                    ac.State.Enqueue(new State_OneWayFlight(ac, _position, ((Client_Special) client).Position, _landAction));
                    ac.State.Enqueue(new State_Maintenance(ac));
                    ac.State.Enqueue(new State_Waiting(ac));
                    break;
            }
            
            ac.State.Dequeue();
            RemoveAircraft(ac);
        }
        
        /*
         * Starts the flying State of an Aircraft (and also gives it all of it's future action after the boarding until
         * it is back to waiting).
         * ac     : The Aircraft that will begin the Flying State
         * client : The client that the Aircraft will fly to
         */
        private void BeginFlight(Aircraft ac, Client client)
        {
            switch (ac.Type)
            {
                case 'O':
                    ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Special) client).Position, _position));
                    ac.State.Enqueue(new State_Maintenance(ac)); //This is temporary, I will change it to another flight state if I have the time, if not well he'll just wait there and come back
                    ac.State.Enqueue(new State_OneWayFlight(ac, _position, ((Client_Special) client).Position, _landAction));
                    ac.State.Enqueue(new State_Maintenance(ac));
                    ac.State.Enqueue(new State_Waiting(ac));
                    break;
                case 'R':
                    ac.State.Enqueue(new State_OneWayFlight(ac, ((Client_Special) client).Position, _position));
                    ac.State.Enqueue(new State_OneWayFlight(ac, _position, ((Client_Special) client).Position, _landAction));
                    break;
            }
            
            ac.State.Dequeue();
            RemoveAircraft(ac);
        }

        /*
         * Removes the Normal Client from the Airport.
         * client : Client that needs to be removed
         */
        private void RemoveClient(Client_Normal client)
        {
            _clients.Remove(client);
        }

        /*
         * Removes the Aircraft from the Airport.
         * ac : Aircraft that needs to be removed
         */
        private void RemoveAircraft(Aircraft ac)
        {
            _aircrafts.Remove(ac);
            _removeAircraftAction?.Invoke(ac);
        }
    }
}