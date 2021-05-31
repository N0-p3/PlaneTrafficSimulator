using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_Observer : Aircraft
    {
        //Property
        /*
         * Sends the type of the Aircraft in a char
         */
        public override char Type => 'O';
        
        //Constructor
        /*
         * Creates an Observer Aircraft according to it's speed and it's maintenance time
         * speed           : Speed of the Aircraft in km/h represented with an int
         * maintenanceTime : The time, in seconds, needed in order to do maintenance on said Aircraft
         */
        public Aircraft_Observer(int speed, int maintenanceTime)
        {
            _speed = speed;
            _trailColor = Color.Gray;
            _maintenanceTime = maintenanceTime;
        }
    }
}