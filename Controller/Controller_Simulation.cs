using System;
using System.Threading;
using FlightSim.Model;

namespace FlightSim
{
    public class Controller_Simulation
    {
        //Data member
        private Scenario _modelScenario;
        private int _secondsPerTicks;
        
        //Constructor
        public Controller_Simulation()
        {
            _modelScenario = LoadXml();
            _secondsPerTicks = 15;
        }
        
        //Functions
        public void IncrementSecondsPerTick()
        {
            if(_secondsPerTicks <= 25)
                _secondsPerTicks += 5;
        }
        
        public void DecrementSecondsPerTick()
        {
            if(_secondsPerTicks > 10)
                _secondsPerTicks -= 5;
        }
        
        public Scenario LoadXml()
        {
            
        }
        
        private void Gameloop()
        {
            while (true)
            {
                long startTime = DateTime.Now.Ticks;
                
                //Operations
                _modelScenario.PassTime(_secondsPerTicks);

                long endTime = DateTime.Now.Ticks;
                long loopTime = endTime - startTime;
                Thread.Sleep(1000 - (int)loopTime);
            }
        }

        private void CallToGenerateClient(char type)
        {
            _modelScenario.GenerateClient(type);
        }
    }
}