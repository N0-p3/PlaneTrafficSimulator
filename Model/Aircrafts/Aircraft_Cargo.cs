using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_Cargo : Aircraft_Normal
    {
        //Data member
        private double _capacity; //The Aircraft's cargo capacity in tons
        
        //Property
        /*
         * Sends the type of the Aircraft in a char
         */
        public override char Type => 'C';
        
        /*
         * Sends the capacity of the Aircraft
         */
        public double Capacity => _capacity;
        
        //Constructor
        /*
         * Creates a Cargo Aircraft according to it's capacity, speed, maintenance time, loading time and unloading time
         * capacity        : The capacity in tons of the Cargo Aircraft
         * speed           : Speed of the Aircraft in km/h represented with an int
         * maintenanceTime : The time, in seconds, needed in order to do maintenance on said Aircraft
         * loadingTime     : The time, in seconds, needed in order to load the Aircraft in question
         * unloadingTime   : The time, in seconds, needed in order to unload the Aircraft in question 
         */
        public Aircraft_Cargo(double capacity, int speed, int maintenanceTime, int loadingTime, int unloadingTime) : base (speed, maintenanceTime, loadingTime, unloadingTime)
        {
            _capacity = capacity;
            _trailColor = Color.Blue;
        }
    }
}