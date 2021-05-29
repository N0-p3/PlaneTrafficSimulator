using System;

namespace FlightSim.Model
{
    public abstract class Client_Special : Client
    {
        //Data member
        private Position _pos;
        private Airport _nearestAirport;
        
        //Properties
        public Airport NearestAirport
        {
            get { return _nearestAirport; }
        }
        
        public Position Position
        {
            get { return _pos; }
        }
        
        //Constructor
        protected Client_Special()
        {
            Random r = new Random();
            _pos = new Position(r.Next(1507), r.Next(766));
            _nearestAirport = FindNearestAirport();
        }
        
        //Function
        private Airport FindNearestAirport()
        {
            //TODO : Implement
            throw new System.NotImplementedException();
        }
    }
}