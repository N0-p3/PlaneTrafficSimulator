namespace FlightSim.Model.Clients
{
    public class Client_Passenger : Client_Normal
    {
        //Data member
        private int _amountOfPassengers;
        
        //Properties
        public override char Type => 'P';

        public int AmountOfPassengers
        {
            get => _amountOfPassengers;
            set => _amountOfPassengers = value;
        }

        //Constructor
        public Client_Passenger(int amountOfPassengers, Airport destination) : base(destination.Position)
        {
            _amountOfPassengers = amountOfPassengers;
        }
    }
}