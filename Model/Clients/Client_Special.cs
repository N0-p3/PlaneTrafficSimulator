using System;
using System.Text.RegularExpressions;
using FlightSim.Model.Aircrafts;

namespace FlightSim.Model.Clients
{
    public abstract class Client_Special : Client
    {
        //Data members
        private Position _pos;
        protected Airport _nearestAirport;

        public Position Position => _pos;
        
        //Constructor
        protected Client_Special()
        {
            Random r = new Random();
            _pos = new Position(r.Next(1507), r.Next(766));
        }
        
        //Function
        protected Airport FindNearestAirport(char type)
        {
            //TODO : Implement 
            //Note : Don't forget to save the aircraft that you'll find in order to give
            //       it to SendPosition.
            throw new NotImplementedException();
        }

        protected void SendPosition(Aircraft ac)
        {
            _nearestAirport.ReceivePosition(ac, this);
        }
    }
}