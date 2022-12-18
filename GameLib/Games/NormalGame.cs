using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Games
{
    class NormalGame : Game
    {
        public override string TypeOfGame { get => TypeOfGame; set => TypeOfGame = "NormalGame"; }
        public NormalGame(GameAccount player1, GameAccount player2, int rating) : base(player1, player2, rating)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.rating = rating;
            gameIndex = gameIndexSeed++;
            DefoltGameAccount a = new DefoltGameAccount("s");
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
