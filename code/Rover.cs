using System;

namespace Rover
{
    public class Rover
    {
        private int x;
        private int y;
        private Direction direction;

        public Rover(int startX, int startY, Direction direction)
        {
            this.X = startX;
            this.y = startY;
            this.Direction = direction;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Direction Direction { get => direction; set => direction = value; }
    }
}