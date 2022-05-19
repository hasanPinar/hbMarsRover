using Business.Context;
using Business.State.Abstract;
using Core.ConstantVariables;

namespace Business.State.Concrete
{
    public class EastDirection : RoverDirection
    {
        public EastDirection(Point Coordinates, Plateau Area) : base(Coordinates, Area)
        {
            Direction = Directions.East;
        }

        public override RoverDirection TurnLeft()
        {
            return new NorthDirection(Coordinates, Area);
        }

        public override RoverDirection TurnRight()
        {
            return new SouthDirection(Coordinates, Area);
        }

        public override void Move()
        {
            if (IsDestinationInArea() && !IsThereAnyRoverInDestination())
                Coordinates.X = Coordinates.X + 1;
        }

        public override bool IsDestinationInArea()
        {
            return Coordinates.X < Area.RightX;
        }

        public override bool IsThereAnyRoverInDestination()
        {
            return Area.CheckIsThereAnyRover(new Point(Coordinates.X + 1, Coordinates.Y));
        }
    }
}