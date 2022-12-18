using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Games
{
    class NormalGame : Game
    {
        public NormalGame(GameAccount player1, GameAccount player2, int rating) : base(player1, player2, rating)
        {
            GameType = Types.Normal;
        }

        

        internal override int calcLosingPoints()
        {
            return Rating;
        }

        internal override int calcWinningPoints()
        {
            return Rating;
        }
    }
}
