namespace BattleShip.Data
{
    public interface IShooter
    {
        void Shoot(Board board);

        Coordinate? LastShot { get; }
    }
}