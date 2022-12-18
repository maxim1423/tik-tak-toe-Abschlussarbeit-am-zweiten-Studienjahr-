using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Games
{
    class TrainingGame : Game
    {
        public TrainingGame(GameAccount player1, GameAccount player2) : base(player1, player2, 0)
        {
            GameType = Types.Training;
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
