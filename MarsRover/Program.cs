using Business.Context;
using Core.CoreFunctions;
using MarsRover.UI;
using System;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleTextColor.NormalText("Enter the plateau limits.");
            var plateauLimits = Console.ReadLine();

            while (!CoreFunction.IsPlateauLimitValid(plateauLimits))
            {
                ConsoleTextColor.WarningText("The plateau limits are not valid, please try again.");
                plateauLimits = Console.ReadLine();
            }

            Plateau plateau = new Plateau(new Limit(plateauLimits));

            string positionAndDirection = "";
            do
            {
                ConsoleTextColor.NormalText("Enter location of the rover on the plateau. For exit \"Q\" ");
                positionAndDirection = Console.ReadLine();

                if (CoreFunction.IsLocationAndDirectionValid(positionAndDirection))
                {
                    var pieces = positionAndDirection.Split(" ");
                    Point roverPoint = new Point(Convert.ToInt32(pieces[0]), Convert.ToInt32(pieces[1]));

                    if (plateau.CheckInLandingSurface(roverPoint))
                    {
                        if (!plateau.CheckIsThereAnyRover(roverPoint))
                        {
                            Rover rover = new Rover(positionAndDirection, plateau);

                            ConsoleTextColor.NormalText("Enter the command for the rover..");
                            var commands = Console.ReadLine();

                            plateau.NonEmptyPoints.Add(rover.MoveRover(commands));
                        }
                        else
                        {
                            ConsoleTextColor.ErrorText("There is already a rover in the selected point.");
                        }
                    }
                    else
                    {
                        ConsoleTextColor.ErrorText("Selected point not in landing surface");
                    }
                }
                else if (positionAndDirection.ToUpper() != "Q")
                {
                    ConsoleTextColor.WarningText("Locate Rover is not valid, please try again.");
                }

            } while (positionAndDirection.ToUpper() != "Q");

            ConsoleTextColor.NormalText("");

            foreach (var item in plateau.NonEmptyPoints)
            {
                ConsoleTextColor.InfoText(item.Location.X + " " + item.Location.Y + " " + item.Direction);
            }
            ConsoleTextColor.NormalText("");
        }

    }
}