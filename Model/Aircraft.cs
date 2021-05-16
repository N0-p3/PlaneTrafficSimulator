using System.Drawing;

namespace FlightSim.Model
{
    public abstract class Aircraft
    {
        //Data member
        protected Color _trailColor;
        protected int _speed; //In km/h
        private State _state;
        
        //Constructor
        public Aircraft()
        {
            _state = new State_Waiting();
        }
    }
}