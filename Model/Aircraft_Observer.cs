﻿using System.Drawing;

namespace FlightSim.Model
{
    public class Aircraft_Observer : Aircraft_Special
    {
        //Constructor
        public Aircraft_Observer(int speed)
        {
            _speed = speed;
            _trailColor = Color.Gray;
        }
    }
}