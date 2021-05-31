using System;
using System.Collections.Generic;
using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;
using static FlightSim.Model.Client_Factory;

namespace FlightSim.Model
{
    public class Scenario
    {
        //Data members
        private List<Airport> _airports;              //Every Airport in the scenario
        private List<Aircraft> _aircrafts;            //Every Aircraft in the scenario
        private List<Client_Special> _specialClients; //Every Special Clients in the scenario

        //Constructor
        /*
         * Creates the Scenario with a list of airports and aircrafts and assigns the delegate to every Airport
         * airports  : Every Airport in the scenario
         * aircrafts : Every Aircraft in the scenario
         */
        public Scenario(List<Airport> airports, List<Aircraft> aircrafts)
        {
            _airports = airports;
            _aircrafts = aircrafts;
            _specialClients = new List<Client_Special>();

            foreach (Airport airport in _airports)
            {
                airport.AssignRemoveAircraftDelegate(addAircraft);
                airport.AssignLandDelegate(RemoveAircraft);
            }
        }
        
        //Functions
        /*
         * Makes time go by by a certain amount of seconds.
         * seconds : The amount of time passing by (in seconds)
         */
        public void PassTime(int seconds)
        {
            //TODO : Implement
            foreach (Aircraft ac in _aircrafts)
            {
                ac.State.Peek().DoStateAction(seconds);
            }
        }
        
        /*
         * Generates a client based on the type received.
         * type : The type of client received
         */
        public void GenerateClient(char type)
        {
            Random r = new Random();

            if (type == 'F' || type == 'R' || type == 'O')
            {
                Position pos = new Position(r.Next(1507), r.Next(766));
                Airport airport = FindNearestAirport(type, pos);
                _specialClients.Add(GetFactory().CreateSpecialClient(type, pos, airport));
            }
            else
            {
                int clientSource;
                int clientDest = r.Next(_airports.Count - 1);

                do
                    clientSource = r.Next(_airports.Count - 1);
                while (clientSource == clientDest);

                _airports[clientSource].AddClient(GetFactory().CreateNormalClient(type, _airports[clientDest]));
            }
        }
        
        /*
         * Finds the nearest Airport that has a specfic Aircraft based on the type received.
         * type : The type of Aircraft received
         * pos  : The position of the Client
         */
        private Airport FindNearestAirport(char type, Position pos)
        {
            Airport closestAirport = _airports[0];
            double closest = pos.Distance(closestAirport.Position);
            
            foreach (Airport airport in _airports)
            {
                if (closest > airport.Position.Distance(pos))
                {
                    if (airport.HasSpecific(type, _aircrafts, out Aircraft found))
                    {
                        closestAirport = airport;
                        closest = airport.Position.Distance(pos);
                    }
                }
            }

            return closestAirport;
        }

        /*
         * Adds an Aircraft to the list of Aircrafts in the Scenario.
         * ac : The Aircraft being added
         */
        private void addAircraft(Aircraft ac)
        {
            _aircrafts.Add(ac);
        }

        /*
         * Removes an Aircraft off of the list of Aircrafts in the Scenario.
         * ac  : The Aircraft being removed
         * pos : The position of the Airport the Aircraft is on
         */
        private void RemoveAircraft(Aircraft ac, Position pos)
        {
            _aircrafts.Remove(ac);
            _airports.Find(airport => airport.Position == pos).AddAircraft(ac);
        }
    }
}