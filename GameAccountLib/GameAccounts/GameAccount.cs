using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab2.GameAccounts
{
    public  class GameAccount
    {
        private const int startRating = 10;
        public string userName { get; set; }
        
        private int currentRating;
        public int CurrentRating { 
            get 
            {
                currentRating = startRating;
                foreach( Game game in allGame)
                {
                    if (game.player1.userName == userName||game.player2.userName==userName)
                    {
                        if (game.Winner == userName)
                        {
                            currentRating += game.calcWinningPoints();
                        }
                        else
                        {
                            currentRating -= game.calcLosingPoints();
                        }
                    }
                }
                return currentRating;
            }
            set {currentRating = value; } }
        public static List<Game> allGame = new List<Game>();

        public static List<GameAccount> gamers = new List<GameAccount>();
       
        public GameAccount(String userName)
        {
            CurrentRating = startRating;
            this.userName = userName;
        }


       
    }
}
