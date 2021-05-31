namespace FlightSim.Model.Aircrafts
{
    public abstract class Aircraft_Normal : Aircraft
    {  
        //Data members
        private int _loadingTime;   //The Aircraft's loading time (or boarding time if you prefer)
        private int _unLoadingTime; //The Aircraft's unloading time (or disembarking time if you prefer)

        //Properties
        /*
         * Sends the loading time of the Aircraft
         */
        public int LoadingTime => _loadingTime;

        /*
         * Send the unloading time of the Aircraft
         */
        public int UnLoadingTime => _unLoadingTime;

        //Constructor
        /*
         * Creates a Normal Aircraft according to it's speed, maintenance time, loading time and unloading time
         * speed           : Speed of the Aircraft in km/h represented with an int
         * maintenanceTime : The time, in seconds, needed in order to do maintenance on said Aircraft
         * loadingTime     : The time, in seconds, needed in order to load the Aircraft in question
         * unloadingTime   : The time, in seconds, needed in order to unload the Aircraft in question 
         */
        public Aircraft_Normal(int speed, int maintenanceTime, int loadingTime, int unLoadingTime)
        {
            _speed = speed;
            _maintenanceTime = maintenanceTime;
            _loadingTime = loadingTime;
            _unLoadingTime = unLoadingTime;
        }
    }
}