using System.Collections.Generic;
using System.Drawing;
using FlightSim.Model.States;

namespace FlightSim.Model.Aircrafts
{
    public abstract class Aircraft : ISpecific
    {
        //Data member
        protected Color _trailColor;
        protected int _speed;         //In km/h
        protected int _maintenanceTime;
        protected Queue<State> _statesQueue;
        
        //Properties
        public int Speed => _speed;
        public int MaintenanceTime => _maintenanceTime;
        public abstract char Type { get; }

        public Queue<State> State => _statesQueue;

        //Constructor
        public Aircraft()
        {
            _statesQueue = new Queue<State>();
            _statesQueue.Enqueue(new State_Waiting(this));
        }
    }
}