using System.Drawing;
using FlightSim.Model.States;

namespace FlightSim.Model.Aircrafts
{
    public abstract class Aircraft
    {
        //Data member
        protected Color _trailColor;
        protected int _speed;         //In km/h
        protected int _maintenanceTime;
        private State _state;
        
        //Properties
        public int Speed => _speed;
        public int MaintenanceTime => _maintenanceTime;
        public abstract char Type { get; }

        public State State
        {
            get => _state;
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