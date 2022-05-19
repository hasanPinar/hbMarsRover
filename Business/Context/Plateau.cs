using Core.CoreFunctions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Context
{
    public class Plateau
    {
        public List<RoverInfo> NonEmptyPoints
        {
            get;
            set;
        }
        public int leftX
        {
            get;
            set;
        }
        public int RightX
        {
            get;
            set;
        }
        public int UpY
        {
            get;
            set;
        }
        public int DownY
        {
            get;
            set;
        }
        private bool IsSizeValid
        {
            get;
            set;
        }

        public Plateau(int LimitX, int LimitY)
        {
            CreatePlateau(LimitX, LimitY);
        }

        public Plateau(Limit limit)
        {
            CreatePlateau(limit.LimitX, limit.LimitY);
        }

        /// <summary>
        /// create new plateau
        /// </summary>
        /// <param name="LimitX">x size</param>
        /// <param name="LimitY">y size</param>
        private void CreatePlateau(int LimitX, int LimitY)
        {
            IsSizeValid = !(LimitX == 0 && LimitY == 0);
            NonEmptyPoints = new List<RoverInfo>();
            leftX = Math.Min(0, LimitX);
            DownY = Math.Min(0, LimitY);
            RightX = Math.Max(0, LimitX);
            UpY = Math.Max(0, LimitY);
        }

        /// <summary>
        /// size of plateau is valid
        /// </summary>
        /// <returns></returns>
        public bool CheckIsSizeValid() //alan uygun mu
        {
            return IsSizeValid;
        }

        /// <summary>
        /// is there any rover in point of landing surface 
        /// </summary>
        /// <param name="NewRoverPosition">Location of the rover to be added</param>
        /// <returns></returns>
        public bool CheckIsThereAnyRover(Point NewRoverPosition) //başka araç var mı
        {
            return NonEmptyPoints.Select(q => q.Location).ToList().Any(q => q.X == NewRoverPosition.X && q.Y == NewRoverPosition.Y);
        }

        /// <summary>
        /// is location of rover in landing surface
        /// </summary>
        /// <param name="NewRoverPosition">Location of the rover to be added</param>
        /// <returns></returns>
        public bool CheckInLandingSurface(Point NewRoverPosition) //iniş alanı içerisinde mi
        {
            return CoreFunction.Between(NewRoverPosition.X, leftX, RightX) && CoreFunction.Between(NewRoverPosition.Y, DownY, UpY);
        }
    }
}