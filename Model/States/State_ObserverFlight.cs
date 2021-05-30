using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_ObserverFlight : State_InFlight
    {
        //Data member
        private Position _destination;
        
        //Constructor
        public State_ObserverFlight(Aircraft ac, Client_Special client, Position pos) : base(ac, client, pos)
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

        protected override void StartNextState(int seconds)
        {
            throw new System.NotImplementedException();
        }
    }
}