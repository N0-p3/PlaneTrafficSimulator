using System;

namespace FlightSim.Model
{
    public abstract class Aircraft_Normal : Aircraft
    {  
        //Data members
        private int _loadingTime;
        private int _unLoadingTime;
        
        //Constructor
        public Aircraft_Normal(int speed, int loadingTime, int unLoadingTime)
        {
            _speed = speed;
            _loadingTime = loadingTime;
            _unLoadingTime = unLoadingTime;
        }
    }
}