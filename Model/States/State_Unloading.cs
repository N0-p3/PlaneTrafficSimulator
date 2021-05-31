using FlightSim.Model.Aircrafts;

namespace FlightSim.Model.States
{
    public class State_Unloading : State
    {
        //Data member
        private int _unloadingTime;
        
        //Constructor
        public State_Unloading(Aircraft_Normal ac) : base(ac)
        {
            _unloadingTime = ac.UnLoadingTime;
        }

        //Functions
        public override void DoStateAction(int seconds)
        {
            _unloadingTime -= seconds;
            if (_unloadingTime < 0)
                _aircraft.State.Dequeue();
        }
    }
}