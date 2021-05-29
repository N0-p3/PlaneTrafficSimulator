﻿using System.Collections.Generic;

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
        
        public void LookForMatch()
        {
            //TODO : Implement
        }

        private void Match(Aircraft ac, Client client)
        {
            //TODO : Implement
        }

        private void BeginBoarding(Aircraft ac, Client_Normal client)
        {
            State_Boarding stateBoarding = new State_Boarding();
            ac.State = stateBoarding;
        }
    }
}