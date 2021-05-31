namespace FlightSim.Model.Clients
{
    public class Client_Rescue : Client_Special
    {
        //Property
        /*
         * Sends the type of the Client in a char
         */
        public override char Type => 'R';
        
        //Constructor
        /*
         * Creates a Rescue Client according to it's position and it's nearest Airport
         * pos            : The position of the Client
         * nearestAirport : The Client's nearest Airport that has an Aircraft that can help
         */
        public Client_Rescue(Position pos, Airport nearestAirport) : base(pos)
        {
            _nearestAirport = nearestAirport;
        }
    }
}