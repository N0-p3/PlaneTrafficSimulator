namespace FlightSim.Model.Clients
{
    public class Client_Cargo : Client_Normal
    {
        //Data member
        private double _tonsOfCargo;
        
        //Properties
        public double TonsOfCargo
        {
            get { return _tonsOfCargo; }
        }
        
        //Constructor
        public Client_Cargo(double tonsOfCargo, Airport destination) : base(destination)
        {
            _tonsOfCargo = tonsOfCargo;
        }
    }
}