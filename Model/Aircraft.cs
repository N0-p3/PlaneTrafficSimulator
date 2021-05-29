using System.Drawing;

namespace FlightSim.Model
{
    public abstract class Aircraft
    {
        //Data member
        protected Color _trailColor;
        protected int _speed;         //In km/h
        protected int _maintenanceTime;
        private State _state;
        
        //Properties
        public int Speed
        {
            get { return _speed; }
        }
        
        public int MaintenanceTime
        {
            get { return _maintenanceTime; }
        }

        public State State {
            get
            { return _state; }
            set
            {
                if (value is State)
                    _state = value;
            } 
        }

        //Constructor
        public Aircraft()
        {
            _state = new State_Waiting(this);
        }
    }
}