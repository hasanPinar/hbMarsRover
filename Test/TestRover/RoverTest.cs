using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ConstantVariables;
using Business.Context;
using System.Linq;

namespace Test.TestRover
{

    [TestFixture]
    public class RoverTest
    {
        [TestCase(1, 1, 0, 1, true)]
        [TestCase(5, 3, 5, 3, true)]
        [TestCase(3, 5, 4, 6, false)]
        [TestCase(5, 2, -5, 2, false)]
        public void Is_Rover_Point_In_Landing_Surface(int plateauLimitX, int plateauLimitY, int roverXCoordinate, int roverYCoordinate, bool expectedValue)
        {
            Point location = new Point(roverXCoordinate, roverYCoordinate);
            var plateau = new Plateau(plateauLimitX, plateauLimitY);
            var isValid = plateau.CheckInLandingSurface(location);
            Assert.AreEqual(expectedValue, isValid);
        }

        [TestCase(5, 5, 0, 1, 3, 2, false)]
        [TestCase(5, 5, 5, 3, 3, 5, false)]
        [TestCase(5, 5, 3, 2, 3, 2, true)]
        public void Is_There_Any_Rover_In_Landing_Surface_Point(int plateauLimitX, int plateauLimitY, int oldRoverXCoordinate, int oldRoverYCoordinate, int newRoverXCoordinate, int newRoverYCoordinate, bool expectedValue)
        {
            RoverInfo roverInfo = new RoverInfo()
            {
                Location = new Point(oldRoverXCoordinate, oldRoverYCoordinate)
            };

            var plateau = new Plateau(plateauLimitX, plateauLimitY);
            plateau.NonEmptyPoints.Add(roverInfo);

            Point newRoverLocation = new Point(newRoverXCoordinate, newRoverYCoordinate);

            var isValid = plateau.CheckIsThereAnyRover(newRoverLocation);
            Assert.AreEqual(expectedValue, isValid);
        }

        [TestCase(1, 1, 0, 1, Directions.North, false)]
        [TestCase(5, 3, 5, 3, Directions.East, false)]
        [TestCase(3, 5, 0, 0, Directions.West, false)]
        [TestCase(5, 2, 1, 1, Directions.South, true)]
        public void Is_Destinaion_Point_Of_Rover_In_Plateau(int plateauLimitX, int plateauLimitY, int roverXCoordinate, int roverYCoordinate, string direction, bool expectedValue)
        {
            var plateau = new Plateau(plateauLimitX, plateauLimitY);
            Rover rover = new Rover(new Point(roverXCoordinate, roverYCoordinate), plateau, direction);

            var isValid = rover.IsDestinationInArea();
            Assert.AreEqual(expectedValue, isValid);
        }

        [TestCase(5, 5, 0, 1, 3, 2, Directions.North, false)]
        [TestCase(5, 5, 5, 3, 3, 4, Directions.East, false)]
        [TestCase(5, 5, 2, 2, 3, 2, Directions.West, true)]
        [TestCase(5, 5, 3, 4, 3, 5, Directions.South, true)]
        public void Is_There_Any_Rover_In_Destinaion_Point_Of_Rover(int plateauLimitX, int plateauLimitY, int oldRoverXCoordinate, int oldRoverYCoordinate, int newRoverXCoordinate, int newRoverYCoordinate, string direction, bool expectedValue)
        {
            RoverInfo roverInfo = new RoverInfo()
            {
                Location = new Point(oldRoverXCoordinate, oldRoverYCoordinate)
            };

            var plateau = new Plateau(plateauLimitX, plateauLimitY);
            plateau.NonEmptyPoints.Add(roverInfo);

            Rover rover = new Rover(new Point(newRoverXCoordinate, newRoverYCoordinate), plateau, direction);

            var isValid = rover.IsThereAnyRoverInDestination();
            Assert.AreEqual(expectedValue, isValid);
        }

    }
}