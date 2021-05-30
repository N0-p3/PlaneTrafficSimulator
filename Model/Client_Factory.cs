using System;
using FlightSim.Model.Clients;

namespace FlightSim.Model
{
    public class Client_Factory
    {
        //data member
        private static Client_Factory _factory = null;
        
        //Constructor
        private Client_Factory() {}
        
        //Functions
        public static Client_Factory GetFactory()
        {
            if (_factory is null)
            {
                _factory = new Client_Factory();
            }

            return _factory;
        }
        
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

        public Client_Special CreateSpecialClient(char type)
        {
            Random r = new Random();
            switch (type)
            {
                case 'F':
                    return new Client_Fire((byte) r.Next(6));
                
                case 'R':
                    return new Client_Rescue();
                
                default:
                    return new Client_Observer();
            }
        }
    }
}