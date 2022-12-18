using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Games
{
    class SafeLoseGame : Game
    {
        public override string TypeOfGame { get => TypeOfGame; set => TypeOfGame = "SafeLoseGame"; }
        public SafeLoseGame(GameAccount player1, GameAccount player2, int rating) : base(player1, player2, rating)
        {
        }

        public override int calcLosingPoints()
        {
            return 0;
        }

        public override int calcWinningPoints()
        {
            return rating;
        }
    }
}
