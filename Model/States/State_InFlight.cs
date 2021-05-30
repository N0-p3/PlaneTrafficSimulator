﻿using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public abstract class State_InFlight : State
    {
        //Data member
        protected Client _client;
        
        //Constructor
        protected State_InFlight(Aircraft ac, Client client) : base(ac)
        {
            _client = client;
        }
    }
}