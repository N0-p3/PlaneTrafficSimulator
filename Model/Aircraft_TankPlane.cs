using System.Drawing;

namespace FlightSim.Model
{
    public class Aircraft_TankPlane : Aircraft_Special
    {
        //Constructor
        public Aircraft_TankPlane(int speed)
        {
            _speed = speed;
            _trailColor = Color.Yellow;
        }
    }
}