using System;
using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_RecurantFlight : State_InFlight
    {
        //Data members
        private Client_Fire _exactClient;
        private Position _destination;
        private Airport _nearestWaterSource;
        private Airport _baseAirport;
        
        //Constructor
        public State_RecurantFlight(Aircraft ac, Client_Fire client, Airport baseAirport, int seconds, Position pos) : base(ac, client, pos)
        {
            _exactClient = client;
            _destination = client.Position;
            _nearestWaterSource = FindNearestWaterSource(client.Position);
            _baseAirport = baseAirport;
        }

        //Functions
        public override void DoStateAction(int seconds)
        {
            while (_exactClient.Spread > 0)
            {
                if (seconds > 0)
                    Travel(seconds, _destination);
            }
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
                //TODO : Implement
                throw new NotImplementedException();
            }
        }

        private void BeginMaintenanceState()
        {
            _aircraft.State = new State_Maintenance(_aircraft);
        }

        private Airport FindNearestWaterSource(Position clientPosition)
        {
            //TODO : Implement
            throw new NotImplementedException();
        }

        protected override void StartNextState(int seconds)
        {
            if (_exactClient.Spread > 0)
            {
                //TODO : Implement
                throw new NotImplementedException();
            }
        }
    }
}