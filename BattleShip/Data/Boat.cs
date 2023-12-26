namespace BattleShip.Data
{
    public class Boat
    {
        public Boat(Coordinate topLeft, bool isHorizontal, int length)
        {
            TopLeft = topLeft;
            IsHorizontal = isHorizontal;
            Length = length;
        }

        private Coordinate TopLeft { get; }
        private bool IsHorizontal { get; }

        private int Length { get; }

        public IEnumerable<Coordinate> AllCoordinates {
            get
            {
                for (var i = 0; i < Length; i++)
                {
                    if (IsHorizontal)
                    {
                        yield return TopLeft.GoRight(i);
                    }
                    else
                    {
                        yield return TopLeft.GoDown(i);
                    }
                }

            }
        }
        
        public IEnumerable<Coordinate> AllCoordinatesAround {
            get
            {
                foreach (var coordinate in AllCoordinates)
                {
                    yield return coordinate.GoUp();
                    yield return coordinate.GoRight();
                    yield return coordinate.GoDown();
                    yield return coordinate.GoLeft();
                }
            }
        }
    }
}