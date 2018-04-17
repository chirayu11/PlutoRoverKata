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
                var forwardCommand = new ForwardCommand();
                var backwardCommand = new BackwardCommand();
                switch (command)
                {
                    case 'F':
                        forwardCommand.Execute(rover);
                        break;
                    case 'B':
                        backwardCommand.Execute(rover);
                        break;
                }
            }
        }
    }
}