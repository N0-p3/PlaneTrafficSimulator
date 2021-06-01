using System;
using System.Threading;
using System.Windows.Forms;
using FlightSim.Model;

namespace FlightSim
{
    public class Controller_Simulation
    {
        //Data member
        private Scenario _modelScenario;         //The simulation Model (the scenario to be exact)
        private View_Simulation _viewSimulation; //The simulation Form
        private int _secondsPerTicks;            //The speed of the simulation
        
        //Constructor
        /*
         * Creates a new Controller_Simulation
         */
        public Controller_Simulation()
        {
            _modelScenario = null;
            _viewSimulation = new View_Simulation(this);
            _secondsPerTicks = 15;
            Application.Run(_viewSimulation);
        }
        
        //Functions
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Controller_Simulation();
        }
        
        /*
         * Increment the speed of the simulation by 5 seconds per tick.
         */
        public void IncrementSecondsPerTick()
        {
            if(_secondsPerTicks <= 25)
                _secondsPerTicks += 5;
        }
        
        /*
         * Decrement the speed of the simulation by 5 seconds per tick.
         */
        public void DecrementSecondsPerTick()
        {
            if(_secondsPerTicks > 10)
                _secondsPerTicks -= 5;
        }
        
        /*
         * Loads the scenario.
         */
        public Scenario LoadXml(string file)
        {
            throw new NotImplementedException();
        }
        
        /*
         * The loop of the simulation which loops, does operations and then sleeps for the rest of the second (IRL second)
         * it was called.
         */
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

        /*
         * Calls the scenario to Generate a client.
         */
        private void CallToGenerateClient(char type)
        {
            _modelScenario.GenerateClient(type);
        }
    }
}