using System;
using System.Threading;
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
            _contrClient = new Controller_Client();
            _modelScenario = XmlReader();
        }
        
        //Functions
        private void Gameloop()
        {
            while (true)
            {
                long startTime = DateTime.Now.Ticks;
                
                //Operations

                long endTime = DateTime.Now.Ticks;
                long loopTime = endTime - startTime;
                Thread.Sleep(1000 - (int)loopTime);
            }
        }

        private Scenario XmlReader()
        {
            
        }

        public void CallToGenerateClient(char type)
        {
            _modelScenario.GenerateClient(type);
        }
    }
}