namespace BattleShip.Data
{
    public record Coordinate(int X, int Y)
    {
        public int X = X;
        public int Y = Y;

        public Coordinate GoLeft(int i = 1)
        {
            return this with { X = this.X - i };
        }
        public Coordinate GoRight(int i = 1)
        {
            return this with { X = this.X + i };
        }
        public Coordinate GoUp(int i = 1)
        {
            return this with { Y = this.Y - i };
        }
        public Coordinate GoDown(int i = 1)
        {
            return this with { Y = this.Y + i };
        }
    }
}