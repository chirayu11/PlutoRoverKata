using System;
using System.Collections.Generic;

namespace Rover {
    public class Terrain
    {
        private int sizeX;
        private int sizeY;
        private HashSet<Tuple<int, int>> obstacles;

        public Terrain(int sizeX, int sizeY, IEnumerable<Tuple<int, int>> obstacles) {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.obstacles = new HashSet<Tuple<int, int>>(obstacles);
        }

        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }

        public bool IsAnObstacle(int x, int y) {
            return obstacles.Contains(Tuple.Create(x, y));
        }
    }
}