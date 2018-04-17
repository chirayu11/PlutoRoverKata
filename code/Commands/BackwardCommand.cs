namespace Rover {
    public class BackwardCommand : IRoverCommand
    {
        public void Execute(Rover rover)
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