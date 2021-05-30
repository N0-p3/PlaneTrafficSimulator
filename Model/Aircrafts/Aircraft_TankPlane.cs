using System.Drawing;

namespace FlightSim.Model.Aircrafts
{
    public class Aircraft_TankPlane : Aircraft_Special
    {
        //Data members
        private int _loadingTime;
        private int _unLoadingTime;

        //Properties
        public int LoadingTime => _loadingTime;
        public int UnLoadingTime => _unLoadingTime;
        public override char Type => 'T';
        
        //Constructor
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