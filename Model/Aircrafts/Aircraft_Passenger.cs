using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_Passenger : Aircraft_Normal
    {
        //Data member
        private int _capacity; //The Aircraft's passenger capacity in amount of persons
        
        //Property
        /*
         * Sends the type of the Aircraft in a char
         */
        public override char Type => 'P';
        
        /*
         * Sends the capacity of the Aircraft
         */
        public int Capacity => _capacity;

        //Constructor
        /*
         * Creates a Passenger Aircraft according to it's capacity, speed, maintenance time, loading time and unloading time
         * capacity        : The capacity in amount of persons of the Passenger Aircraft
         * speed           : Speed of the Aircraft in km/h represented with an int
         * maintenanceTime : The time, in seconds, needed in order to do maintenance on said Aircraft
         * loadingTime     : The time, in seconds, needed in order to load the Aircraft in question
         * unloadingTime   : The time, in seconds, needed in order to unload the Aircraft in question 
         */
        public Aircraft_Passenger(int capacity, int speed, int maintenanceTime, int loadingTime, int unloadingTime) : base (speed, maintenanceTime, loadingTime, unloadingTime)
        {
            _capacity = capacity;
            _trailColor = Color.Green;
        }
    }
}