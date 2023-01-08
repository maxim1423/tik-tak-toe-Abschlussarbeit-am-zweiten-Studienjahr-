using Lab2.GameAccounts;

namespace Lab2.Games
{
    class TrainingGame : Game
    {
        public TrainingGame(GameAccount player1, GameAccount player2) : base(player1, player2, 0)
        {
            gameType = Type.Training;
        }

        internal override int calcLosingPoints()
        {
            return 0;
        }

        internal override int calcWinningPoints()
        {
            return 0;
        }
    }
}
