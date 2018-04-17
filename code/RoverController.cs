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
        }

        public Direction Direction()
        {
            return rover.Direction;
        }
    }
}