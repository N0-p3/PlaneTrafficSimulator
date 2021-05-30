﻿using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_Boarding : State
    {
        //Data members
        private int _boardingTime;
        private Airport _baseAirport;
        private Client _client;

        //Constructor
        public State_Boarding(Aircraft ac, Client client, Airport baseAirport) : base(ac)
        {
            if (ac.Type == 'P' || ac.Type == 'C')
                _boardingTime = ((Aircraft_Normal) ac).LoadingTime;
            else
                _boardingTime = ((Aircraft_TankPlane) ac).LoadingTime;
            
            _client = client;
            _baseAirport = baseAirport;
        }
        
        //Functions
        public override void DoStateAction(int seconds)
        {
            _boardingTime -= seconds;
            if (_boardingTime < 0)
                BeginFlightState(System.Math.Abs(_boardingTime));
        }

        private void BeginFlightState(int seconds)
        {
            State flightState;
            
            if (_aircraft.Type == 'P' || _aircraft.Type == 'C')
                flightState = new State_OneWayFlight(_aircraft, (Client_Normal)_client, seconds, _baseAirport.Position);
            else
                flightState = new State_RecurantFlight(_aircraft, (Client_Fire)_client, _baseAirport, seconds, _baseAirport.Position);
            
            _aircraft.State = flightState;
        }
    }
}