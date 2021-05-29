using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_Unloading : State
    {
        //Data member
        private int _unloadingTime;
        
        //Constructor
        public State_Unloading(Aircraft_Normal ac, Client client) : base(ac)
        {
            _unloadingTime = ac.UnLoadingTime;
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