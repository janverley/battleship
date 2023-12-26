namespace BattleShip.Data
{
    public class Row
    {
        private const int DefaultRowSize = 10;
        public int Index { get; }
        public string IndexText => "ABCDEFGHIJ"[Index].ToString();

        private Row(int index, int size)
        {
            Index = index;
            Size = size;
            cells = new List<Cell>();
        }

        private List<Cell> cells;
        
        public IEnumerable<Cell> Cells => cells;

        public static Row CreateBlanco(int index, int size = DefaultRowSize)
        {
            
            var result = new Row(index, size);

            for (int i = 0; i < size; i++)
            {
                result.cells.Add(new Cell(new Coordinate(i, index)));
            }

            return result;
        }

        public int Size { get; private set; }

        public Cell GetCell(Coordinate coordinate)
        {
            return cells[coordinate.X];
        }

        public int ShotsFired() => Cells.Count(c => c.IsShot);

        public int Hits() => Cells.Count(c => c.IsHit);
    }
}