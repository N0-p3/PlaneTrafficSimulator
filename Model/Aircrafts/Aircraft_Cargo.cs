using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_Cargo : Aircraft_Normal
    {
        //Data member
        private double _capacity; //In tons
        
        //Property
        public override char Type => 'C';

        //Constructor
        public Aircraft_Cargo(double capacity, int speed, int maintenanceTime, int loadingTime, int unloadingTime) : base (speed, maintenanceTime, loadingTime, unloadingTime)
        {
            _capacity = capacity;
            _trailColor = Color.Blue;
        }
    }
}