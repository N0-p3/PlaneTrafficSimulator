namespace FlightSim.Model.Clients
{
    public class Client_Passenger : Client_Normal
    {
        //Data member
        private int _amountOfPassengers;
        
        //Properties
        public double AmountOfPassengers
        {
            get { return _amountOfPassengers; }
        }
        
        //Constructor
        public Client_Passenger(int amountOfPassengers, Airport destination) : base(destination)
        {
            _amountOfPassengers = amountOfPassengers;
        }
    }
}