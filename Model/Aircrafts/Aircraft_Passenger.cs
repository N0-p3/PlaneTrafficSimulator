using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_Passenger : Aircraft_Normal
    {
        //Data member
        private int _capacity;
        
        //Property
        public override char Type => 'P';

        //Constructor
        public Aircraft_Passenger(int capacity, int speed, int maintenanceTime, int loadingTime, int unloadingTime) : base (speed, maintenanceTime, loadingTime, unloadingTime)
        {
            _capacity = capacity;
            _trailColor = Color.Green;
        }
    }
}