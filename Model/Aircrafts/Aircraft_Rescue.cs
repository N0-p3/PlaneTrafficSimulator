using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_Rescue : Aircraft
    {
        //Property
        /*
         * Sends the type of the Aircraft in a char
         */
        public override char Type => 'R';
        
        //Constructor
        /*
         * Creates a Rescue Aircraft according to it's speed and it's maintenance time
         * speed           : Speed of the Aircraft in km/h represented with an int
         * maintenanceTime : The time, in seconds, needed in order to do maintenance on said Aircraft
         */
        public Aircraft_Rescue(int speed, int maintenanceTime)
        {
            _speed = speed;
            _trailColor = Color.Red;
            _maintenanceTime = maintenanceTime;
        }
    }
}