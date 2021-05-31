namespace FlightSim.Model.Clients
{
    public class Client_Passenger : Client_Normal
    {
        //Data member
        private int _amountOfPassengers; //The amount of passengers the Client has
        
        //Properties
        /*
         * Sends the type of the Client in a char
         */
        public override char Type => 'P';

        /*
         * Sends the amount of passengers the Client has
         * Sets the amount of passengers the Client has
         */
        public int AmountOfPassengers
        {
            get => _amountOfPassengers;
            set => _amountOfPassengers = value;
        }

        //Constructor
        /*
         * Creates a Passenger Client according to it's amount of passenger and destination
         * amountOfPassenger : The amount of passengers the Client will have
         * destination       : The Client's destination
         */
        public Client_Passenger(int amountOfPassengers, Airport destination) : base(destination)
        {
            _amountOfPassengers = amountOfPassengers;
        }
    }
}