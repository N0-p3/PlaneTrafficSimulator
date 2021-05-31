using System;
using FlightSim.Model.Aircrafts;

namespace FlightSim.Model.States
{
    public delegate void Land(Aircraft ac, Position pos);
    
    public class State_OneWayFlight : State
    {
        //Data members
        private Land _land;
        private Position _destination;
        private Position _pos;
        private double _distanceCounterX;

        //Constructor
        public State_OneWayFlight(Aircraft ac, Position destination, Position pos, Land land = null) : base(ac)
        {
            _destination = destination;
            _pos = pos;
            _land = land;
        }
        
        //Functions
        public override void DoStateAction(int seconds)
        {
            if (seconds > 0)
                Travel(seconds, _destination);
        }
        
        private void Travel(int seconds, Position destination)
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
                _pos.PixX = destination.PixX;
                _pos.PixY = destination.PixY;
                _aircraft.State.Dequeue();
                _land?.Invoke(_aircraft, _pos);
            }
        }
    }
}