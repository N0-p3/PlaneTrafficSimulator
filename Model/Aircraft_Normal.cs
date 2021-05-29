namespace FlightSim.Model
{
    public abstract class Aircraft_Normal : Aircraft
    {  
        //Data members
        private int _loadingTimePerUnit;
        private int _unLoadingTimePerUnit;

        //Properties
        public int LoadingTime
        {
            get { return _loadingTimePerUnit; }
        }

        //Constructor
        public Aircraft_Normal(int speed, int loadingTime, int unLoadingTime)
        {
            _speed = speed;
            _loadingTimePerUnit = loadingTime;
            _unLoadingTimePerUnit = unLoadingTime;
        }
    }
}