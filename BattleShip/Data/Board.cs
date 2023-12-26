namespace BattleShip.Data
{
    public class Board
    {
        private const int DefaultRowCount = 10;

        private Board(int rowCount)
        {
            RowCount = rowCount;
            rows = new List<Row>();
        }

        private int RowCount
        {
            get;
        }

        public IEnumerable<Row> Rows => rows;
        //public Coordinate? lastHit;
        //public Coordinate? LastShot { get; private set; }

        private readonly List<Row> rows;

        private Row GetRow(Coordinate coordinate)
        {
            return rows[coordinate.Y];
        }

        public static Board CreateBlanco(int rowCount = DefaultRowCount)
        {
            var result = new Board(rowCount);
            
            for (int i = 0; i < rowCount; i++)
            {
                result.rows.Add(Row.CreateBlanco(i));
            }

            return result;
        }

        private bool CanPlace(Boat boat)
        {
            foreach (var coordinate in boat.AllCoordinates)
            {
                if (!IsValidCoordinate(coordinate))
                {
                    return false;
                }
                if (IsOccupied(coordinate))
                {
                    return false;
                }
            }

            foreach (var coordinate in boat.AllCoordinatesAround)
            {
                if (IsValidCoordinate(coordinate) && IsOccupied(coordinate))
                {
                    return false;
                }
            }

            return true;
        }
        

        public bool Place(Boat boat)
        {
            if (!CanPlace(boat))
            {
                return false;
            }
            
            foreach (var coordinate in boat.AllCoordinates)
            {
                CellAt(coordinate).IsOccupied = true;
            }

            return true;
        }

        private bool IsOccupied(Coordinate coordinate)
        {
            return CellAt(coordinate).IsOccupied;
        }

        public Cell CellAt(Coordinate coordinate)
            => GetRow(coordinate).GetCell(coordinate);
        
        public Board Shoot(Coordinate coordinate)
        {
            CellAt(coordinate).Shoot();
            return this;
        }

        public int ShotsFired() => Rows.Sum(r => r.ShotsFired());
        public int Hits() => Rows.Sum(r => r.Hits());

        public bool IsValid()
        {
            var result = Rows.Sum(r => r.Cells.Count(c => c.IsOccupied)) == 17;
            
            return result;
        }

        public bool IsValidCoordinate(Coordinate coordinate)
        {
            return 0 <= coordinate.X && coordinate.X < Rows.First().Size &&
                   0 <= coordinate.Y && coordinate.Y < RowCount;
        }

        public bool IsShot(Coordinate coordinate)
        {
            return CellAt(coordinate).IsShot;
        }


        public Coordinate RandomCoordinate()
        {
            var random = new Random();
            return new Coordinate(random.Next(0, Rows.First().Size), random.Next(0, RowCount));
        }

        
        private bool RandomOrientation()
        {
            var random = new Random();
            return random.Next(100) > 50;
        }
        public Board Random()
        {
            PlaceRandomBoat(5);
            PlaceRandomBoat(4);
            PlaceRandomBoat(3);
            PlaceRandomBoat(3);
            PlaceRandomBoat(2);

            return this;
        }

        private void PlaceRandomBoat(int length)
        {
            while (true)
            {
                if (Place(new Boat(RandomCoordinate(), RandomOrientation(), length)))
                {
                    break;
                }
            }
        }

        public bool IsHit(Coordinate coordinate)
        {
            return CellAt(coordinate).IsHit;
        }
    }
}