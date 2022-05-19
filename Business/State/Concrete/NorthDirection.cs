using Business.Context;
using Business.State.Abstract;
using Core.ConstantVariables;

namespace Business.State.Concrete
{
    public class NorthDirection : RoverDirection
    {
        public NorthDirection(Point Coordinates, Plateau Area) : base(Coordinates, Area)
        {
            Direction = Directions.North;
        }

        public override RoverDirection TurnLeft()
        {
            return new WestDirection(Coordinates, Area);
        }

        public override RoverDirection TurnRight()
        {
            return new EastDirection(Coordinates, Area);
        }

        public override void Move()
        {
            if (IsDestinationInArea() && !IsThereAnyRoverInDestination())
                Coordinates.Y = Coordinates.Y + 1;
        }

        public override bool IsDestinationInArea()
        {
            return Coordinates.Y < Area.UpY;
        }

        public override bool IsThereAnyRoverInDestination()
        {
            return Area.CheckIsThereAnyRover(new Point(Coordinates.X, Coordinates.Y + 1));
        }

    }
}