using System;
using System.Collections.Generic;

namespace Rover
{
    public class RoverController
    {
        private Rover rover;
        private Terrain terrain;
        private IDictionary<char, IRoverCommand> commandLookup;

        public RoverController(Rover rover, Terrain terrain, IDictionary<char, IRoverCommand> commandLookup)
        {
            this.rover = rover;
            this.terrain = terrain;
            this.commandLookup = commandLookup;
        }

        public void Execute(string commands)
        {
            foreach (var command in commands)
            {
                if (! commandLookup.ContainsKey(command))
                {
                    var message = "Command not found. Supported commands: " + String.Join(",", commandLookup.Keys);
                    throw new CommandNotFoundException(message);
                }

                var previousX = rover.X;
                var previousY = rover.Y;


                commandLookup[command].Execute(rover);
                commandLookup['W'].Execute(rover); // wrap if necessary

                if (terrain.IsAnObstacle(rover.X, rover.Y))
                {
                    rover.X = previousX;
                    rover.Y = previousY;
                    throw new ObstacleHitException("You've hit an obstacle!");
                }
            }
        }
    }
}