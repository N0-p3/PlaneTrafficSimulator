namespace FlightSim.Model.Clients
{
    public class Client_Observer : Client_Special
    {
        //Property
        /*
         * Sends the type of the Client in a char
         */
        public override char Type => 'O';
        
        //Constructor
        /*
         * Creates an Observer Client according to it's position and it's nearest Airport
         * pos            : The position of the Client
         * nearestAirport : The nearest Airport that has an Airplane that can help with the situation
         */
        public Client_Observer(Position pos, Airport nearestAirport) : base(pos)
        {
            _nearestAirport = nearestAirport;
        }
    }
}