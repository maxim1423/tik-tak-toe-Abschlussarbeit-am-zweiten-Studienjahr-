using Lab2.GameAccounts;
using System;

namespace Lab2
{
    public abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public String Winner { get; set; } 
        
        protected int rating;
        public int Rating
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
                    throw new Exception("You can't play on negative rating");
                }
                if(calcLosingPoints() >= player1.CurrentRating || calcLosingPoints() >= player2.CurrentRating)
                {
                    throw new Exception("Player don't have enough rating");
                }
            }
        }
        public enum Type
        {
            Normal,
            SafeLose,
            Training
        }
        public Type gameType { protected set; get; } 
       
        
        
        public int gameIndex { get; private set; }
        protected static int gameIndexSeed = 123321;

        internal abstract int calcLosingPoints();

        internal abstract int calcWinningPoints();

        public Game(GameAccount player1, GameAccount player2, int rating)
        {
            this.player1 = player1;
            this.player2 = player2;
            Rating = rating;
            gameIndex = gameIndexSeed++;
        }
        public Game() { }
    }
}
