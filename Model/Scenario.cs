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
        private List<Airport> _airports;
        private List<Aircraft> _aircrafts;
        private List<Client_Special> _specialClients;

        //Constructor
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
        public void PassTime(int seconds)
        {
            //TODO : Implement
            foreach (Aircraft ac in _aircrafts)
            {
                ac.State.Peek().DoStateAction(seconds);
            }
        }
        
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
        
        protected Airport FindNearestAirport(char type, Position pos)
        {
            //TODO : Implement 
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

        private void addAircraft(Aircraft ac)
        {
            _aircrafts.Add(ac);
        }

        private void RemoveAircraft(Aircraft ac, Position pos)
        {
            _aircrafts.Remove(ac);
            _airports.Find(airport => airport.Position == pos).AddAircraft(ac);
        }
    }
}