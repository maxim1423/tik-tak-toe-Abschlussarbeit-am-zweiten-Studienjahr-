using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public abstract class Game
    {

        internal enum Types { 
        Normal,
        SafeLose,
        Training
        }
        internal string Winner;
        internal Types GameType { get; set; }
        internal GameAccount player1 { get; set; }
        internal GameAccount player2 { get; set; }
        private int rating;
        internal int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                if (rating < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Rating),
                        "You can't play on negative rating");
                }
            }
        }
        internal int gameIndex { get; set; }
        protected static int gameIndexSeed = 123321;

        public Game(GameAccount player1, GameAccount player2, int rating)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.Rating = rating;
            gameIndex = gameIndexSeed++;
        }

        internal abstract int calcWinningPoints();

        internal abstract int calcLosingPoints();
    }
}
