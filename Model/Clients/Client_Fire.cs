namespace FlightSim.Model.Clients
{
    public class Client_Fire : Client_Special
    {
        //Data member
        private byte _spread; //The Client's fire spread
        
        //Property
        /*
         * Sends the spread of the Client
         */
        public byte Spread => _spread;
        
        /*
         * Sends the type of the Client in a char
         */
        public override char Type => 'F';

        //Constructor
        /*
         * Creates a Fire Client according to it's spread, position and the nearest Airport
         * spread         : The spread of the Fire Client
         * pos            : The position of the Client
         * nearestAirport : The nearest Airport that has an Airplane that can help with the situation
         */
        public Client_Fire(byte spread, Position pos, Airport nearestAirport) : base(pos)
        {
            _spread = spread;
            _nearestAirport = nearestAirport;
        }
    }
}