using FlightSim.Model.Aircrafts;
using FlightSim.Model.Clients;

namespace FlightSim.Model.States
{
    public class State_Boarding : State
    {
        //Data members
        private int _boardingTime;

        //Constructor
        public State_Boarding(Aircraft ac) : base(ac)
        {
            if (ac.Type == 'P' || ac.Type == 'C')
                _boardingTime = ((Aircraft_Normal) ac).LoadingTime;
            else
                _boardingTime = ((Aircraft_TankPlane) ac).LoadingTime;
        }
        
        //Functions
        public override void DoStateAction(int seconds)
        {
            _boardingTime -= seconds;
            if (_boardingTime < 0)
                _aircraft.State.Dequeue();
        }
    }
}