using Business.Context;
using Business.State.Abstract;
using Core.ConstantVariables;

namespace Business.State.Concrete
{
    public class SouthDirection : RoverDirection
    {
        public SouthDirection(Point Coordinates, Plateau Area) : base(Coordinates, Area)
        {
            Direction = Directions.South;
        }

        public override RoverDirection TurnLeft()
        {
            return new EastDirection(Coordinates, Area);
        }

        public override RoverDirection TurnRight()
        {
            return new WestDirection(Coordinates, Area);
        }

        public override void Move()
        {
            if (IsDestinationInArea() && !IsThereAnyRoverInDestination())
                Coordinates.Y = Coordinates.Y - 1;
        }

        public override bool IsDestinationInArea()
        {
            return Coordinates.Y > Area.DownY;
        }

        public override bool IsThereAnyRoverInDestination()
        {
            return Area.CheckIsThereAnyRover(new Point(Coordinates.X, Coordinates.Y - 1));
        }
    }
}