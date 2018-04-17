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
                var turnLeftCommand = new TurnLeftCommand();

                switch (command)
                {
                    case 'F':
                        forwardCommand.Execute(rover);
                        break;
                    case 'B':
                        backwardCommand.Execute(rover);
                        break;
                    case 'L':
                        turnLeftCommand.Execute(rover);
                        break;
                }
            }
        }
    }
}