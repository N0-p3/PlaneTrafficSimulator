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
            string type;
            
            //Deciding what type of Client will be generated
            int random = r.Next(5);

            switch (random)
            {
                case 0:
                    type = "f";
                    break;
                case 1:
                    type = "r";
                    break;
                case 2:
                    type = "o";
                    break;
                case 3:
                    type = "c";
                    break;
                default:
                    type = "p";
                    break; 
            }
            
            _contrSim.CallToGenerateClient(type);
        }
    }
}