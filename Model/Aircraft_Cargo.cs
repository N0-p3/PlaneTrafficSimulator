using System;
using System.Drawing;

namespace FlightSim.Model
{
    public class Aircraft_Cargo : Aircraft_Normal
    {
        //Data member
        private double _capacity; //In tons

        //Constructor
        public Aircraft_Cargo()
        {
            Random r = new Random();

            _capacity = r.NextDouble() * 27.5 + 12.5; //Generates between 12.5 and 40
            _trailColor = Color.Blue;
        }
    }
}