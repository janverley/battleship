namespace BattleShip.Data
{
    public class Shooter : IShooter
    {
        private Coordinate? lastHit = null;

        public Coordinate? LastShot { get; private set; }

        public void Shoot(Board board)
        {
            while (true)
            {
                var coordinate = new Coordinate(-1,-1);

                if (lastHit != null )
                {
                    var up = lastHit.GoUp();
                    if (board.IsValidCoordinate(up)&& !board.IsShot(up) )
                    {
                        coordinate = up;
                    }
                    else
                    {
                        var right = lastHit.GoRight();
                        if (board.IsValidCoordinate(right)&& !board.IsShot(right) )
                        {
                            coordinate = right;
                        }
                        else
                        {
                            var down = lastHit.GoDown();
                            if (board.IsValidCoordinate(down)&& !board.IsShot(down) )
                            {
                                coordinate = down;
                            }
                            else
                            {
                                var left = lastHit.GoLeft();
                                if (board.IsValidCoordinate(left)&& !board.IsShot(left) )
                                {
                                    coordinate = left;
                                }
                            }
                        }
                    }
                }

                if (!board.IsValidCoordinate(coordinate))
                {
                    coordinate = board.RandomCoordinate();
                }

                if (!board.CellAt(coordinate).IsShot)
                {
                    board.Shoot(coordinate);
                    
                    LastShot = coordinate;
                    
                    if (board.IsHit(coordinate))
                    {
                        lastHit = coordinate;
                    }

                    break;
                }
            }
        }
    }
}