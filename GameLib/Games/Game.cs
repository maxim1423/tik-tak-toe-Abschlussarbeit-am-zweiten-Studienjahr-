using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public abstract class Game
    {
        public string Winner { get; set; }
        public abstract string TypeOfGame { get; set; }
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int rating { get; set; }
        public int gameIndex { get; set; }
        protected static int gameIndexSeed = 123321;

        public Game(GameAccount player1, GameAccount player2, int rating)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.rating = rating;
            gameIndex = gameIndexSeed++;
        }

        protected abstract int calcWinningPoints();

        protected abstract int calcLosingPoints();
    }
}
