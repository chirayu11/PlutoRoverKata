namespace Rover {
    public class WrapCommand : IRoverCommand
    {
        private Terrain terrain;

        public WrapCommand(Terrain terrain) {
            this.terrain = terrain;
        }
        public void Execute(Rover rover)
        {
            if (rover.X >= terrain.SizeX)
                rover.X = 0;

            if (rover.X < 0)
                rover.X = terrain.SizeX - 1;

            if (rover.Y >= terrain.SizeY)
                rover.Y = 0;

            if (rover.Y < 0)
                rover.Y = terrain.SizeY - 1;
        }
    }
}