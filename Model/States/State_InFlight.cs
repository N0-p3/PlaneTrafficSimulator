using System;
using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public abstract class State_InFlight : State
    {
        //Data members
        protected Client _client;
        protected Position _pos;
        protected double _distanceCounterX;
        
        //Property
        public Position Position => _pos;
        
        //Constructor
        protected State_InFlight(Aircraft ac, Client client, Position pos) : base(ac)
        {
            _distanceCounterX = 0.0;
            _client = client;
            _pos = pos;
        }
        
        //Function
        protected virtual void Travel(int seconds, Position destination)
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
                int secondsLeft = (int)((_distanceCounterX - totalDistanceX) * 3600) / _aircraft.Speed;
                StartNextState(secondsLeft);
            }
        }

        protected abstract void StartNextState(int seconds);
    }
}