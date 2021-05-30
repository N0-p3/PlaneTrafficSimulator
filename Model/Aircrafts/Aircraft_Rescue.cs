﻿using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_Rescue : Aircraft_Special
    {
        //Property
        public override char Type => 'R';
        
        //Constructor
        public Aircraft_Rescue(int speed)
        {
            _speed = speed;
            _trailColor = Color.Red;
        }
    }
}