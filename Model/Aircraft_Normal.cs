using System;

namespace FlightSim.Model
{
    public abstract class Aircraft_Normal : Aircraft
    {  
        //Data members
        private int _loadingTime;
        private int _unLoadingTime;
        
        //Constructor
        public Aircraft_Normal()
        {
            Random r = new Random();
            
            _speed = r.Next(880, 925);
            _loadingTime = 
        }
    }
}