using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_Unloading : State
    {
        //Data member
        private int _unloadingTime;
        
        //Constructor
        public State_Unloading(Aircraft_Normal ac, int seconds) : base(ac)
        {
            _unloadingTime = ac.UnLoadingTime;
            DoStateAction(seconds);
        }

        //Functions
        public override void DoStateAction(int seconds)
        {
            _unloadingTime -= seconds;
            if (_unloadingTime < 0)
                BeginMaintenanceState(System.Math.Abs(_unloadingTime));
        }

        private void BeginMaintenanceState(int seconds)
        {
            _aircraft.State = new State_Maintenance(_aircraft, seconds);
        }
    }
}