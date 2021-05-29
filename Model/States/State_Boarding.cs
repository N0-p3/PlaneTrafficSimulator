using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_Boarding : State
    {
        //Data members
        private int _boardingTime;
        private Client_Normal _client;

        //Constructor
        public State_Boarding(Aircraft_Normal ac, Client_Normal client) : base(ac)
        {
            _boardingTime = ac.LoadingTime;
            _client = client;
        }
        
        //Functions
        public override void DoStateAction(int seconds) //Board the plane
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }

        private void BeginFlightState()
        {
            State_OneWayFlight flightState = new State_OneWayFlight(_aircraft, _client);
            _aircraft.State = flightState;
        }
    }
}