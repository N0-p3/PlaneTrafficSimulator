using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_Observer : Aircraft_Special
    {
        //Property
        public override char Type => 'O';
        
        //Constructor
        public Aircraft_Observer(int speed)
        {
            _speed = speed;
            _trailColor = Color.Gray;
        }
    }
}