using Business.Context;

namespace Business.State.Abstract
{
    public abstract class RoverDirection
    {
        public Plateau Area
        {
            get;
            set;
        }
        public Point Coordinates
        {
            get;
            set;
        }
        public string Direction
        {
            get;
            set;
        }
        public RoverDirection(Point Coordinates, Plateau Area)
        {
            this.Coordinates = Coordinates;
            this.Area = Area;
        }
        public abstract RoverDirection TurnLeft();
        public abstract RoverDirection TurnRight();
        public abstract void Move();
        public abstract bool IsDestinationInArea();
        public abstract bool IsThereAnyRoverInDestination();
    }
}