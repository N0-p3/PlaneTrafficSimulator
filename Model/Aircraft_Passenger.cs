using System;
using System.Drawing;

namespace FlightSim.Model
{
    public class Aircraft_Passenger : Aircraft_Normal
    {
        //Data member
        private int _capacity;

        //Constructor
        public Aircraft_Passenger(int capacity, int speed, int loadingTime, int unLoadingTime) : base (speed, loadingTime, unLoadingTime)
        {
            _capacity = capacity;
            _trailColor = Color.Green;
        }
    }
}