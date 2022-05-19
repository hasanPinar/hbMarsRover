using System;

namespace Business.Context
{
    public class RoverInfo
    {
        public Point Location
        {
            get;
            set;
        }
        public string Direction
        {
            get;
            set;
        }
        public RoverInfo()
        {

        }

        /// <summary>
        /// location and direction info of rover
        /// </summary>
        /// <param name="point"></param>
        public RoverInfo(string point)
        {
            var limits = point.Split(" ");

            int x = Convert.ToInt32(limits[0]);
            int y = Convert.ToInt32(limits[1]);
            Location = new Point(x, y);
            Direction = limits[2];
        }
    }
}