namespace FlightSim.Model.Clients
{
    public class Client_Cargo : Client_Normal
    {
        //Data member
        private double _tonsOfCargo;
        
        //Properties
        public override char Type => 'C';

        public double TonsOfCargo
        {
            get => _tonsOfCargo;
            set => _tonsOfCargo = value;
        }
        
        
        //Constructor
        public Client_Cargo(double tonsOfCargo, Airport destination) : base(destination.Position)
        {
            _tonsOfCargo = tonsOfCargo;
        }
    }
}