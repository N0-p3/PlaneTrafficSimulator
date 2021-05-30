using FlightSim.Model.Aircrafts;

namespace FlightSim.Model.States
{
    public class State_Maintenance : State
    {
        //Data member
        private int _maintenanceTime;
        
        //Constructor
        public State_Maintenance(Aircraft ac, int seconds) : base(ac)
        {
            _maintenanceTime = ac.MaintenanceTime;
            DoStateAction(seconds);
        }

        //Functions
        public override void DoStateAction(int seconds)
        {
            _maintenanceTime -= seconds;
            if (_maintenanceTime < 0)
                BeginWaitingState();
        }

        private void BeginWaitingState()
        {
            _aircraft.State = new State_Waiting(_aircraft);
        }
    }
}