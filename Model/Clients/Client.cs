namespace FlightSim.Model.Clients
{
    public abstract class Client : ISpecific
    {
        //Property
        public abstract char Type { get; }
        
        //Function
        public static Client_Passenger MergePassengerClient(Client_Passenger first, Client_Passenger second)
        {
            first.AmountOfPassengers += second.AmountOfPassengers;
            return first;
        }
        
        public static Client_Cargo MergeCargoClient(Client_Cargo first, Client_Cargo second)
        {
            first.TonsOfCargo += second.TonsOfCargo;
            return first;
        }
    }
}