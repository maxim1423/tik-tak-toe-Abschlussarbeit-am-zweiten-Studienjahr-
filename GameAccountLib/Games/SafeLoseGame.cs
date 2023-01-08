using Lab2.GameAccounts;

namespace Lab2.Games
{
    class SafeLoseGame : Game
    {

        public SafeLoseGame(GameAccount player1, GameAccount player2, int rating) : base(player1, player2, rating)
        {
            gameType = Type.SafeLose;
        }

        internal override int calcLosingPoints()
        {
            return 0;
        }

        internal override int calcWinningPoints()
        {
            return Rating;
        }
    }
}
