using Core.ConstantVariables;

namespace Core.CoreFunctions
{
    public static class CoreFunction
    {
        public static bool Between(int num, int lower, int upper)
        {
            return lower <= num && num <= upper;
        }

        public static bool IsPlateauLimitValid(string value)
        {
            var limits = value.Split(" ");
            if (limits.Length == 2)
            {
                int limitX = 0;
                int limitY = 0;
                return int.TryParse(limits[0], out limitX) &&
                  int.TryParse(limits[1], out limitY) && (limitX != 0 || limitY != 0);
            }
            return false;
        }

        public static bool IsLocationAndDirectionValid(string value)
        {
            var pieces = value.Split(" ");
            if (pieces.Length == 3)
            {
                return int.TryParse(pieces[0], out int limitX) &&
                  int.TryParse(pieces[1], out int limitY) &&
                  (pieces[2] == Directions.East || pieces[2] == Directions.North || pieces[2] == Directions.South || pieces[2] == Directions.West);
            }
            return false;
        }
    }
}