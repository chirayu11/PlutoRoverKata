using System;

namespace Rover
{
    public class RoverController
    {
        private Rover rover;
        private Terrain terrain;

        public RoverController(Rover rover, Terrain terrain)
        {
            this.rover = rover;
            this.terrain = terrain;
        }

        public void Execute(string commands)
        {
            foreach (var command in commands)
            {
                var previousX = rover.X;
                var previousY = rover.Y;

                var forwardCommand = new ForwardCommand();
                var backwardCommand = new BackwardCommand();
                var turnLeftCommand = new TurnLeftCommand();
                var turnRightCommand = new TurnRightCommand();
                var wrapCommand = new WrapCommand(terrain);

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
                    case 'R':
                        turnRightCommand.Execute(rover);
                        break;
                }
                wrapCommand.Execute(rover);
                
                if (terrain.IsAnObstacle(rover.X, rover.Y)) {
                    rover.X = previousX;
                    rover.Y = previousY;
                }
            }
        }
    }
}