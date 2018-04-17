using System;

namespace Rover
{
    public class RoverController
    {
        private Rover rover;

        public RoverController(Rover rover)
        {
            this.rover = rover;
        }

        public void Execute(string v)
        {
            switch (rover.Direction)
            {
                case Direction.North:
                    rover.Y += 1;
                    break;
                case Direction.East:
                    rover.X += 1;
                    break;
                case Direction.South:
                    rover.Y -= 1;
                    break;
                case Direction.West:
                    rover.X -= 1;
                    break;
            }
        }
    }
}