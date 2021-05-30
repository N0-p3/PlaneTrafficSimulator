using System;
using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_OneWayFlight : State_InFlight
    {
        //Data member
        private Airport _destination;

        //Constructor
        public State_OneWayFlight(Aircraft ac, Client_Normal client, int seconds, Position pos) : base(ac, client, pos)
        {
            _destination = client.Destination;
            DoStateAction(seconds);
        }
        
        //Functions
        public override void DoStateAction(int seconds)
        {
            if (seconds > 0)
                Travel(seconds, _destination.Position);
        }

        private void BeginUnloadingState(int seconds)
        {
            _aircraft.State = new State_Unloading((Aircraft_Normal)_aircraft, seconds);
        }

        protected override void StartNextState(int seconds)
        {
            BeginUnloadingState(seconds);
        }
    }
}