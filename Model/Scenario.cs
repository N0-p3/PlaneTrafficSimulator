﻿using System;
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
        }
        
        //Functions
        public void LookForMatch()
        {
            //TODO : Implement observer/observable
        }

        public void PassTime(int seconds)
        {
            //TODO : Implement
        }
        
        public void GenerateClient(char type)
        {
            Random r = new Random();
            
            if (type == 'F' || type == 'R' || type == 'O')
                _specialClients.Add(GetFactory().CreateSpecialClient(type));
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
    }
}