namespace Rover {
    public class Terrain
    {
        private int sizeX;
        private int sizeY;

        public Terrain(int sizeX, int sizeY) {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }
    }
}