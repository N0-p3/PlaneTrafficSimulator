using System.Drawing;

namespace FlightSim.Model
{
    public class Aircraft_Rescue : Aircraft_Special
    {
        //Constructor
        public Aircraft_Rescue(int speed)
        {
            _speed = speed;
            _trailColor = Color.Red;
        }
    }
}