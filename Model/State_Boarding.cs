namespace FlightSim.Model
{
    public class State_Boarding : State
    {
        //Data members
        private int _boardingTime;
        private Client_Normal _client;

        //Constructor
        public State_Boarding(int loadingTime, Client_Normal client)
        {
            _boardingTime = loadingTime;
            _client = client;
        }
        
        //Functions
        public void BoardAircraft(int seconds)
        {
            //TODO : Implement
        }

        private void BeginFlightState()
        {
            //TODO : Implement
        }
    }
}