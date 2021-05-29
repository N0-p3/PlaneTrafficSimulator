﻿namespace FlightSim.Model
{
    public class State_ComeBackFlight : State_InFlight
    {
        //Data member
        private Position _destination;
        
        //Constructor
        public State_ComeBackFlight(Aircraft ac, Client_Special client) : base(ac, client)
        {
            _destination = client.Position;
        }
        
        //Functions
        public override void DoStateAction(int seconds)
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }
        
        private void BeginMaintenanceState()
        {
            State_Maintenance maintenanceState = new State_Maintenance(_aircraft);
            _aircraft.State = maintenanceState;
        }
    }
}