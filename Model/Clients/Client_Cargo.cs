namespace FlightSim.Model.Clients
{
    public class Client_Cargo : Client_Normal
    {
        //Data member
        private double _tonsOfCargo; //The Client's amount of cargo in tons
        
        //Properties
        /*
         * Sends the type of the Client in a char
         */
        public override char Type => 'C';

        /*
         * Sends the amount of cargo of the Client in tons
         * Sets the amount of cargo of the Client in tons
         */
        public double TonsOfCargo
        {
            get => _tonsOfCargo;
            set => _tonsOfCargo = value;
        }

        //Constructor
        /*
         * Creates a Cargo Client according to it's tons of cargo and destination
         * tonsOfCargo : The Client's tons of Cargo
         * destination : The Client's destination
         */
        public Client_Cargo(double tonsOfCargo, Airport destination) : base(destination)
        {
            _tonsOfCargo = tonsOfCargo;
        }
    }
}