using System;
using FlightSim.Model.Clients;

namespace FlightSim.Model
{
    public class Client_Factory
    {
        //data member
        private static Client_Factory _factory; //Itself, the Client Factory

        //Functions
        /*
         * Sets the factory if not already done and returns the factory
         */
        public static Client_Factory GetFactory()
        {
            if (_factory == null)
                _factory = new Client_Factory();

            return _factory;
        }
        
        /*
         * Creates a Normal Client according to the type received and the airport received (which is it's destination).
         * type    : The type of the client
         * airport : The destination of the client 
         */
        public Client_Normal CreateNormalClient(char type, Airport airport)
        {
            Random r = new Random();
            switch (type)
            {
                case 'C':
                    return new Client_Cargo(r.Next(41), airport);
                
                default:
                    return new Client_Passenger(r.Next(81), airport);
            }
        }

        /*
         * Creates a Special Client according to the type received, the position and the airport received (which is it's
         * nearest Airport).
         * type    : The type of the client
         * airport : The nearest Airport containing an Aircraft that can help the client
         */
        public Client_Special CreateSpecialClient(char type, Position pos, Airport nearestAirport)
        {
            Random r = new Random();
            switch (type)
            {
                case 'F':
                    return new Client_Fire((byte) r.Next(6), pos, nearestAirport);
                
                case 'R':
                    return new Client_Rescue(pos, nearestAirport);
                
                default:
                    return new Client_Observer(pos, nearestAirport);
            }
        }
    }
}