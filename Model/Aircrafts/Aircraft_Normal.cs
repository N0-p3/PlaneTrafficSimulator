namespace FlightSim.Model.Aircrafts
{
    public abstract class Aircraft_Normal : Aircraft
    {  
        //Data members
        private int _loadingTime;
        private int _unLoadingTime;

        //Properties
        public int LoadingTime => _loadingTime;

        public int UnLoadingTime => _unLoadingTime;

        //Constructor
        public Aircraft_Normal(int speed, int maintenanceTime, int loadingTime, int unLoadingTime)
        {
            _speed = speed;
            _maintenanceTime = maintenanceTime;
            _loadingTime = loadingTime;
            _unLoadingTime = unLoadingTime;
        }
    }
}