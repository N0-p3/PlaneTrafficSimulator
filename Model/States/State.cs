using FlightSim.Model.Aircrafts;

namespace FlightSim.Model.States
{
    public abstract class State
    {
        //Data member
        protected Aircraft _aircraft;
        
        //Constructor
        protected State(Aircraft ac)
        {
            _aircraft = ac;
        }

        //Function
        public abstract void DoStateAction(int seconds);
    }
}