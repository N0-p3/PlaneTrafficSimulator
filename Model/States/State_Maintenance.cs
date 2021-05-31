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
            _maintenanceTime -= seconds;
            if (_maintenanceTime < 0)
                _aircraft.State.Dequeue();
        }
    }
}