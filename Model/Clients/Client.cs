namespace FlightSim.Model.Clients
{
    public abstract class Client : ISpecific
    {
        //Property
        /*
         * Sends the type of the Client in a char format
         */
        public abstract char Type { get; }
        
        //Function
        /*
         * Merges two Passenger Clients together
         * first  : The first Passenger Client to be merged
         * second : The second Passenger Client to be merged
         */
        public static Client_Passenger MergePassengerClient(Client_Passenger first, Client_Passenger second)
        {
            first.AmountOfPassengers += second.AmountOfPassengers;
            return first;
        }
        
        /*
         * Splits two Passenger Clients
         * client   : The Passenger Client to be split
         * capacity : The max amount of passenger the Aircraft can hold
         */
        public static Client_Passenger[] SplitPassengerClient(Client_Passenger client, int capacity)
        {
            Client_Passenger[] tab = new Client_Passenger[2];

            tab[0] = new Client_Passenger(capacity, client.AirportDestination);
            tab[1] = new Client_Passenger(client.AmountOfPassengers - capacity, client.AirportDestination);

            return tab;
        }
        
        /*
         * Merges two Cargo Clients together
         * first  : The first Cargo Client to be merged
         * second : The second Cargo Client to be merged
         */
        public static Client_Cargo MergeCargoClient(Client_Cargo first, Client_Cargo second)
        {
            first.TonsOfCargo += second.TonsOfCargo;
            return first;
        }

        /*
         * Splits two Cargo Clients
         * client   : The Cargo Client to be split
         * capacity : The max amount of tons the Aircraft can hold
         */
        public static Client_Cargo[] SplitCargoClient(Client_Cargo client, double capacity)
        {
            Client_Cargo[] tab = new Client_Cargo[2];

            tab[0] = new Client_Cargo(capacity, client.AirportDestination);
            tab[1] = new Client_Cargo(client.TonsOfCargo - capacity, client.AirportDestination);

            return tab;
        }
    }
}