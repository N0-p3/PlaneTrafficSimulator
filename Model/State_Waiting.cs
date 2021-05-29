namespace FlightSim.Model
{
    public class State_Waiting : State
    {
        //Constructor
        public State_Waiting(Aircraft ac) : base(ac) {}
        
        //Function
        public override void DoStateAction(int seconds) {}
    }
}