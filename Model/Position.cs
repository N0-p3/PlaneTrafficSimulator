using System;

namespace FlightSim.Model
{
    public class Position
    {
        //Data member
        private double[] _pixelCoords;
        
        //Properties
        public double PixX
        {
            get => _pixelCoords[0];
            set => _pixelCoords[0] = value;
        }

        public double PixY
        {
            get => _pixelCoords[1];
            set => _pixelCoords[1] = value;
        }

        //Constructor
        public Position(int x, int y)
        {
            _pixelCoords = new double[] {x, y};
        }

        public override string ToString()
        {
            return CalculateCoordinate(753.0,_pixelCoords[0], 180, "O", "E") 
                   + " " + CalculateCoordinate(382.5, _pixelCoords[1], 90, "N", "S");
        }

        private string CalculateCoordinate(double midPoint, double coordinate, double max, string direction1, string direction2)
        {
            double slice;
            
            if (coordinate < midPoint)
                slice = (((midPoint * 2 - 2 * coordinate + coordinate) - midPoint) * max) / midPoint;
            else if (coordinate > midPoint)
                slice = ((coordinate - midPoint) * max) / midPoint;
            else
                slice = 0.0;

            int exactSlice = Convert.ToInt32(Math.Floor(slice));
            double decimalOfSlice = slice - Math.Truncate(slice);

            //Calculating the minutes and seconds
            int minutes = Convert.ToInt32(Math.Floor(decimalOfSlice * 60));
            double seconds = (decimalOfSlice * 60 - Math.Truncate(decimalOfSlice * 60)) * 60;

            seconds = Math.Truncate(seconds * 100) / 100;
            
            string coordinates = exactSlice + "°" + minutes + "'" + seconds + "\"" + (coordinate < midPoint ? direction1  : direction2 );

            return coordinates;
        }
    }
}