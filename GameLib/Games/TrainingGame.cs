using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Games
{
    class TrainingGame : Game
    {
        public override string TypeOfGame { get => TypeOfGame; set => TypeOfGame = "TrainingGame"; }
        public TrainingGame(GameAccount player1, GameAccount player2) : base(player1, player2, 0)
        {
        }

        protected override int calcLosingPoints()
        {
            return rating;
        }

        protected override int calcWinningPoints()
        {
            return rating;
        }
    }
}
