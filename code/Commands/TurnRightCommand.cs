using System;

namespace Rover
{
    public class TurnRightCommand : IRoverCommand
    {
        public void Execute(Rover rover)
        {
            rover.Direction += 1;

            var numberOfDirections = Enum.GetNames(typeof(Direction)).Length;
            if ((int)rover.Direction >= numberOfDirections)
            {
                rover.Direction = (Direction) 0;
            }
        }
    }
}