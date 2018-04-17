using System;

namespace Rover
{
    public class TurnLeftCommand : IRoverCommand
    {
        public void Execute(Rover rover)
        {
            rover.Direction -= 1;

            if (rover.Direction < 0)
            {
                var numberOfDirections = Enum.GetNames(typeof(Direction)).Length;
                rover.Direction = (Direction) numberOfDirections - 1;
            }
        }
    }
}