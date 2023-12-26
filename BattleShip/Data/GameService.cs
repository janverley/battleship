namespace BattleShip.Data
{
    public class GameService
    {
        private readonly IShooter shooter;

        public GameService(IShooter shooter)
        {
            this.shooter = shooter;
        }
        private Game game = Game.NewGame();

        public Task<Game> NewGame()
        {
            game = Game.NewGame();
            return Task.FromResult(game);
        }

        public Game Shoot(Coordinate coordinate)
        {
            game.ComputerBoard.Shoot(coordinate);
            return game;
        }

        public Game Place(Coordinate topLeft, int length, bool isHorizontal)
        {
            game.PlayerBoard.Place(new Boat(topLeft, isHorizontal, length));
            
            return game;
        }

        public IShooter Shooter => shooter;

        public Game ComputerShoots()
        {
            shooter.Shoot(game.PlayerBoard);
            
            return game;
        }

        public Task<Game> Random()
        {
            game.PlayerBoard.Random();
            return Task.FromResult(game);
        }
    }
}