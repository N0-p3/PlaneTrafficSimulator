using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_RecurantFlight : State_InFlight
    {
        //Data members
        private Position _destination;
        private Airport _nearestWaterSource;
        private Airport _baseAirport;
        
        //Constructor
        public State_RecurantFlight(Aircraft ac, Client_Fire client, Airport baseAirport) : base(ac, client)
        {
            _destination = client.Position;
            _nearestWaterSource = FindNearestWaterSource(client.Position);
            _baseAirport = baseAirport;
        }

        //Functions
        public override void DoStateAction(int seconds)
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }
        
        private void BeginMaintenanceState()
        {
            _aircraft.State = new State_Maintenance(_aircraft);;
        }

        private Airport FindNearestWaterSource(Position clientPosition)
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }
    }
}