using System;
using System.Drawing;

namespace FlightSim.Model
{
    public class Aircraft_Cargo : Aircraft_Normal
    {
        //Data member
        private double _capacity; //In tons

        //Constructor
        public Aircraft_Cargo(double capacity, int speed, int loadingTime, int UnloadingTime) : base (speed, loadingTime, UnloadingTime)
        {
            _capacity = capacity;
            _trailColor = Color.Blue;
        }
    }
}