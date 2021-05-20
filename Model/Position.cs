using System;

namespace FlightSim.Model
{
    public class Position
    {
        //Data member
        private int[] _pixelCoords;
        
        //Properties
        public int Pix_X
        { get { return _pixelCoords[0]; } }
        
        public int Pix_Y
        { get { return _pixelCoords[1]; } }

        //Constructor
        public Position(int x, int y)
        {
            _pixelCoords[0] = x;
            _pixelCoords[1] = y;
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
                slice = max - coordinate / (max / 15);
            else
                slice = coordinate - midPoint / (max / 15);

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