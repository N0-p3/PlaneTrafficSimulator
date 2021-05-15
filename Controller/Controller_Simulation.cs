using FlightSim.Model;

namespace FlightSim
{
    public class Controller_Simulation
    {
        //Data member
        private Controller_Client _contrClient;
        private Scenario _modelScenario;
        
        //Constructor
        public Controller_Simulation()
        {
            
        }
        
        //Functions
        private void Gameloop()
        {
            
        }

        private void XmlReader()
        {
            
        }

        public Client CallToGenerateClient()
        {
            return _modelScenario.GenerateClient();
        }
    }
}