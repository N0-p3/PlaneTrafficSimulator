namespace FlightSim.Model
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