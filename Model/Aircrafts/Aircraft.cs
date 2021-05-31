using System.Collections.Generic;
using System.Drawing;
using FlightSim.Model.States;

namespace FlightSim.Model.Aircrafts
{
    public abstract class Aircraft : ISpecific
    {
        //Data member
        protected Color _trailColor;         //The Aircraft's trail Color
        protected int _speed;                //The Aircraft's speed in km/h
        protected int _maintenanceTime;      //The Aircraft's maintenance time in seconds
        private Queue<State> _statesQueue; //The Aircraft's States in a Queue
        
        //Properties
        /*
         * Sends the speed of the Aircraft in km/h
         */
        public int Speed => _speed;
        
        /*
         * Sends the maintenance time of the Aircraft in seconds
         */
        public int MaintenanceTime => _maintenanceTime;
        
        /*
         * Sends the type of the Aircraft in a char format
         */
        public abstract char Type { get; }

        /*
         * Sends the Queue of States of the Aircraft in question 
         */
        public Queue<State> State => _statesQueue;

        //Constructor
        /*
         * Creates an Aircraft, sets his State to Waiting
         */
        public Aircraft()
        {
            _statesQueue = new Queue<State>();
            _statesQueue.Enqueue(new State_Waiting(this));
        }
    }
}