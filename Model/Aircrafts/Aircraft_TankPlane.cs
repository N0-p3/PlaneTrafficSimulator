using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_TankPlane : Aircraft
    {
        //Data members
        private int _loadingTime;   //The Aircraft's loading time for it's water supply
        private int _unLoadingTime; //The Aircraft's unloading time for it's water supply

        //Properties
        /*
         * Sends the Aircraft's water loading time
         */
        public int LoadingTime => _loadingTime;
        
        /*
         * Sends the Aircraft's water unloading time
         */
        public int UnLoadingTime => _unLoadingTime;
        
        /*
         * Sends the type of the Aircraft in a char
         */
        public override char Type => 'F';
        
        //Constructor
        /*
         * Creates a Tank Plane Aircraft according to it's speed, maintenance time, loading time and unloading time
         * speed           : Speed of the Aircraft in km/h represented with an int
         * maintenanceTime : The time, in seconds, needed in order to do maintenance on said Aircraft
         * loadingTime     : The time, in seconds, needed in order to load the Aircraft in question with water
         * unloadingTime   : The time, in seconds, needed in order to unload the Aircraft's water
         */
        public Aircraft_TankPlane(int speed, int maintenanceTime, int loadingTime, int unLoadingTime)
        {
            _speed = speed;
            _maintenanceTime = maintenanceTime;
            _trailColor = Color.Yellow;
            _loadingTime = loadingTime;
            _unLoadingTime = unLoadingTime;
        }
    }
}