using System;

namespace FlightSim.Model
{
    public class Position
    {
        //Data member
        private double[] _pixelCoords; //An array of double containing the x,y coordinates
        
        //Properties
        /*
         * Sends the X coordinate in pixel (as a double)
         * Sets the X coordinate (as a double)
         */
        public double PixX
        {
            get => _pixelCoords[0];
            set => _pixelCoords[0] = value;
        }

        /*
         * Sends the Y coordinate in pixel (as a double)
         * Sets the Y coordinate (as a double)
         */
        public double PixY
        {
            get => _pixelCoords[1];
            set => _pixelCoords[1] = value;
        }

        //Constructor
        /*
         * Creates the Position object with the two x and y coordinate received
         * x : the x coordinate
         * y : the y coordinate
         */
        public Position(int x, int y)
        {
            _pixelCoords = new double[] {x, y};
        }

        //Functions
        /*
         * Sends the coordinates in a geographical format (in a string).
         */
        public override string ToString()
        {
            return CalculateCoordinate(753.0,_pixelCoords[0], 180, "O", "E") 
                   + " " + CalculateCoordinate(382.5, _pixelCoords[1], 90, "N", "S");
        }

        /*
         * Calculates the distance between the caller's Position and the Position given.
         * dest : the destination
         */
        public double Distance(Position dest)
        {
            double distX = dest.PixX - PixX;
            double distY = dest.PixY - PixY;

            return Math.Sqrt(Math.Pow(distX, 2.0) + Math.Pow(distY, 2.0));
        }

        /*
         * Calculates one set of coordinates along an axis with the help of a midpoint, the coordinate, the maximum and
         * both directions that the axis is on.
         * midPoint   : The middle point of the axis
         * coordinate : The coordinate (which will be somewhere along the axis)
         * max        : The maximum of degrees allowed on the axis
         * direction1 : The direction at the beginning of the axis
         * direction2 : The direction at the end of axis 
         */
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