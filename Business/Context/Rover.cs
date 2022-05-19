using Business.State.Abstract;
using Business.State.Concrete;
using Core.ConstantVariables;
using System;
using System.Linq;

namespace Business.Context
{
    public class Rover
    {
        private RoverDirection RoverState;

        public Rover(Point Coordinates, Plateau Area, string Direction)
        {
            CreateRover(Coordinates, Area, Direction);
        }

        public Rover(string RoverLocation, Plateau Area)
        {
            var pieces = RoverLocation.Split(" ");

            Point Coordinates = new Point(Convert.ToInt32(pieces[0]), Convert.ToInt32(pieces[1]));
            string Direction = pieces[2];

            CreateRover(Coordinates, Area, Direction);
        }

        /// <summary>
        /// create new rover on the plateau
        /// </summary>
        /// <param name="Coordinates">Location of the rover</param>
        /// <param name="Area">Plateau</param>
        /// <param name="Direction">Direction of the rover to be added</param>
        private void CreateRover(Point Coordinates, Plateau Area, string Direction)
        {
            switch (Direction)
            {
                case Directions.North:
                    RoverState = new NorthDirection(Coordinates, Area);
                    break;
                case Directions.South:
                    RoverState = new SouthDirection(Coordinates, Area);
                    break;
                case Directions.East:
                    RoverState = new EastDirection(Coordinates, Area);
                    break;
                case Directions.West:
                    RoverState = new WestDirection(Coordinates, Area);
                    break;
                default:
                    RoverState = new NorthDirection(Coordinates, Area);
                    break;
            }
        }

        /// <summary>
        /// turn left
        /// </summary>
        public void TurnLeft()
        {
            RoverState = RoverState.TurnLeft();
        }

        /// <summary>
        /// turn right
        /// </summary>
        public void TurnRight()
        {
            RoverState = RoverState.TurnRight();
        }

        /// <summary>
        /// move forward
        /// </summary>
        public void Move()
        {
            RoverState.Move();
        }

        /// <summary>
        /// is destination point in plateau
        /// </summary>
        /// <returns></returns>
        public bool IsDestinationInArea()
        {
            return RoverState.IsDestinationInArea();
        }

        /// <summary>
        /// is there any rover in destination point
        /// </summary>
        /// <returns></returns>
        public bool IsThereAnyRoverInDestination()
        {
            return RoverState.IsThereAnyRoverInDestination();
        }

        /// <summary>
        /// do commands
        /// </summary>
        /// <param name="commands">Commands</param>
        /// <returns></returns>
        public RoverInfo MoveRover(string commands)
        {

            foreach (var command in commands.ToList())
            {
                switch (command.ToString())
                {
                    case Movements.Move:
                        Move();
                        break;
                    case Movements.Left:
                        TurnLeft();
                        break;
                    case Movements.Right:
                        TurnRight();
                        break;
                }
            }

            return new RoverInfo()
            {
                Location = RoverState.Coordinates,
                Direction = RoverState.Direction
            };
        }

        /// <summary>
        /// get position of rover 
        /// </summary>
        /// <returns></returns>
        public string GetRoverInfo()
        {
            return RoverState.Coordinates.X + " " + RoverState.Coordinates.Y + " " + RoverState.Direction;
        }

    }
}