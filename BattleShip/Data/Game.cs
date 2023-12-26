namespace BattleShip.Data
{
    public class Game
    {
        public static Game NewGame()
        {
            return new Game
            (
             Board.CreateBlanco(), 
             Board.CreateBlanco().Random()
            );
        }

        private  Game(Board playerBoard, Board computerBoard)
        {
            PlayerBoard = playerBoard;
            ComputerBoard = computerBoard;
        }
        public Board PlayerBoard { get; }
        public Board ComputerBoard { get; }

        public int ShotsFired => ComputerBoard.ShotsFired();
        
        public GameState State {
            get
            {
                if (!PlayerBoard.IsValid())
                {
                    return GameState.Setup;
                }

                if (PlayerBoard.Hits() == 17)
                {
                    return GameState.Lost;
                }

                if (ComputerBoard.Hits() == 17)
                {
                    return GameState.Won;
                }

                return GameState.Playing;
            }
        }
    }

    public enum GameState
    {
        Setup,
        Playing,
        Won,
        Lost
    }
}