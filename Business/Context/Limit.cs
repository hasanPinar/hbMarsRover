using System;

namespace Business.Context
{
    public class Limit
    {
        public int LimitX
        {
            get;
            set;
        }
        public int LimitY
        {
            get;
            set;
        }

        public Limit(int limitX, int limitY)
        {
            CreateLimit(limitX, limitY);
        }

        public Limit(string limit)
        {
            var limits = limit.Split(" ");
            CreateLimit(Convert.ToInt32(limits[0]), Convert.ToInt32(limits[1]));
        }

        /// <summary>
        /// create limit for plateau
        /// </summary>
        /// <param name="limitX">x size</param>
        /// <param name="limitY">y size</param>
        private void CreateLimit(int limitX, int limitY)
        {
            LimitX = limitX;
            LimitY = limitY;
        }
    }
}