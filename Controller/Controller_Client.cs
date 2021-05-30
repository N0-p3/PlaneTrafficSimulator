using System;
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
        public void GenerateClient()
        {
            Random r = new Random();
            char type;
            
            //Deciding what type of Client will be generated
            int random = r.Next(5);

            switch (random)
            {
                case 0:
                    type = 'F';
                    break;
                case 1:
                    type = 'R';
                    break;
                case 2:
                    type = 'O';
                    break;
                case 3:
                    type = 'C';
                    break;
                default:
                    type = 'P';
                    break; 
            }
            
            _contrSim.CallToGenerateClient(type);
        }
    }
}