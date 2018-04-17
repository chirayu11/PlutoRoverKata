using System;

namespace Rover {
    public class ObstacleHitException : Exception
    {
        public ObstacleHitException(string message) : base(message)
        {
        }
    }
}