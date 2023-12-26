namespace BattleShip.Data
{
    public class Cell
    {
        public Cell(Coordinate coordinate)
        {
            Coordinate = coordinate;
            IsOccupied = false;
            hitState = HitState.Unknown;
        }
        public Coordinate Coordinate { get; }

        private HitState hitState;

        public bool IsOccupied { get; set; }

        public void Shoot()
        {
            hitState = IsOccupied ? HitState.Hit : HitState.Miss;
        }

        public bool IsShot => IsHit || IsMiss;
        public bool IsHit => hitState is HitState.Hit;
        public bool IsMiss => hitState is HitState.Miss;
    }
}