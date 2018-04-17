namespace Rover {
    public class ObstacleAvoidCommand : IRoverCommand
    {
        private Terrain terrain;

        public ObstacleAvoidCommand(Terrain terrain) {
            this.terrain = terrain;
        }

        public void Execute(Rover rover)
        {
            
        }
    }
}