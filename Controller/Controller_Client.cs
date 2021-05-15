using FlightSim.Model;

namespace FlightSim
{
    public class Controller_Client
    {
        //Data member
        private Controller_Simulation _contrSim;
        
        //Constructor
        public Controller_Client()
        {
            
        }
        
        //Functions
        public Client GenerateClient()
        {
            return _contrSim.CallToGenerateClient();
        }
    }
}