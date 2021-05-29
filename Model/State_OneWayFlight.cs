﻿namespace FlightSim.Model
{
    public class State_OneWayFlight : State_InFlight
    {
        //Data member
        private Airport _destination;
        
        //Constructor
        public State_OneWayFlight(Aircraft ac, Client_Normal client) : base(ac, client)
        {
            _destination = client.Destination;
        }
        
        //Functions
        public override void DoStateAction(int seconds)
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }

        private void BeginUnloadingState()
        {
            State_Unloading unloadingState = new State_Unloading((Aircraft_Normal)_aircraft, _client);
            _aircraft.State = unloadingState;
        }
    }
}