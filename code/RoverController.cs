using System;

namespace Rover
{
    public class RoverController
    {
        private Direction direction;

        public RoverController(Direction direction)
        {
            this.direction = direction;
        }

        public void Execute(string v)
        {
        }

        public Direction GetDirection()
        {
            return direction;
        }
    }
}