using System;
using System.Drawing;

namespace FlightSim.Model
{
    public class Aircraft_Passenger : Aircraft_Normal
    {
        //Data member
        private int _capacity;

        //Constructor
        public Aircraft_Passenger()
        {
            Random r = new Random();

            _capacity = r.Next(80, 140);
            _trailColor = Color.Green;
        }
    }
}