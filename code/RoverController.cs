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

        public void Execute(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'F':
                        MoveForward();
                        break;
                    case 'B':
                        MoveBackward();
                        break;
                }
            }
        }

        public void MoveForward()
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

        public void MoveBackward()
        {
            switch (rover.Direction)
            {
                case Direction.North:
                    rover.Y -= 1;
                    break;
                case Direction.East:
                    rover.X -= 1;
                    break;
                case Direction.South:
                    rover.Y += 1;
                    break;
                case Direction.West:
                    rover.X += 1;
                    break;
            }
        }
    }
}