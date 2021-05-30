using FlightSim.Model.Aircrafts;

namespace FlightSim.Model.States
{
    public class State_Maintenance : State
    {
        //Data member
        private int _maintenanceTime;
        
        //Constructor
        public State_Maintenance(Aircraft ac) : base(ac)
        {
            _maintenanceTime = ac.MaintenanceTime;
        }

        //Functions
        public override void DoStateAction(int seconds)
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }

        private void BeginWaitingState()
        {
            _aircraft.State = new State_Waiting(_aircraft);
        }
    }
}