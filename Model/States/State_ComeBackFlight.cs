using System;
using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_ComeBackFlight : State_InFlight
    {
        //Data members
        private Position _destination;
        private Airport _baseAirport;
        
        //Constructor
        public State_ComeBackFlight(Aircraft ac, Client_Special client, Position pos) : base(ac, client, pos)
        {
            _destination = client.Position;
        }
        
        //Functions
        public override void DoStateAction(int seconds)
        {
            if (seconds > 0)
                Travel(seconds, _destination);
        }
        
        protected override void Travel(int seconds, Position destination)
        {
            double kmSecond = _aircraft.Speed / 3600.0;
            double distance = kmSecond * seconds;
             
            //Getting the total distance in x and y (a and b on a rectangular triangle)
            double totalDistanceX = destination.PixX - _pos.PixX;
            double totalDistanceY = destination.PixY - _pos.PixY;
             
            //Calculating the hypotenuse
            double totalDistance = Math.Sqrt(Math.Pow(totalDistanceX, 2.0) + Math.Pow(totalDistanceY, 2.0));
             
            //Calculating the new coordinates according to the Ratio
            double distanceRatio = distance / totalDistance;
            double distX = distanceRatio * totalDistanceX;
            _pos.PixX += distX;
            _pos.PixY += distanceRatio * totalDistanceY;
            _distanceCounterX += distX;
            
            //Checks if we arrived at destination
            if (_distanceCounterX >= totalDistanceX)
            {
                _destination = _baseAirport.Position;
            }
        }
        
        private void BeginMaintenanceState()
        {
            State_Maintenance maintenanceState = new State_Maintenance(_aircraft);
            _aircraft.State = maintenanceState;
        }

        protected override void StartNextState(int seconds)
        {
            throw new System.NotImplementedException();
        }
    }
}