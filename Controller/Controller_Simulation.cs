using System;
using System.Threading;
using FlightSim.Model;

namespace FlightSim
{
    public class Controller_Simulation
    {
        //Data member
        private Scenario _modelScenario;
        
        //Constructor
        public Controller_Simulation()
        {
            _modelScenario = LoadXml();
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

        private Scenario LoadXml()
        {
            
        }

        private void CallToGenerateClient(char type)
        {
            _modelScenario.GenerateClient(type);
        }
    }
}