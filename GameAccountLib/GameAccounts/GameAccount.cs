using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Games;

namespace Lab2.GameAccounts
{
    public abstract class GameAccount
    {
        private string userName { get; set; }
        private static int startRating = 10;
        private int currentRating = startRating;
        public int CurrentRating { 
            get
            {
                return currentRating;
            } 
            private set
            {
                
                if (value<1)
                {
                    throw new InvalidOperationException(
                    "You can't play on this rating, because if you lose, your rating will be below than 1"
                    );
                }
                else
                {
                   currentRating = value; 
                }
            }
        }
        protected static List<Game> allGame = new List<Game>();
        private int GamesCount
        {
            get
            {
                return allGame.Count(g => g.player1.userName == userName || g.player2.userName == userName); ;
            }
            set
            {

            }
        }



        public GameAccount(String userName)
        {
            this.userName = userName;
            GamesCount = 0;
        }

        internal abstract int calcLosingPoint(Game game);

        internal abstract int calcWinningPoint(Game game);
        public void WinGame(Game game)
        {
            GameAccount opponent = defineOppNum(game);
            if (opponent == null) Console.WriteLine("There isn't the player from who the function was run in list of this game's players");
            else
            {
                try
                {
                opponent.CurrentRating -= opponent.calcLosingPoint(game);
                opponent.GamesCount++;
                GamesCount++;
                CurrentRating += calcWinningPoint(game);
                game.Winner = this.userName;
                allGame.Add(game);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("This game won't play, because it will result to non-positive loser's rating");
                }
            }
        }
        public void LoseGame(Game game)
        {
            GameAccount opponent = defineOppNum(game);
            if (opponent == null) Console.WriteLine("There isn't the player from who the function was run in list of this game's players. Game wasn't played");
            else
            {
                try
                {
                    CurrentRating -= calcLosingPoint(game);
                    opponent.GamesCount++;
                    opponent.CurrentRating += opponent.calcWinningPoint(game);
                    GamesCount++;
                    game.Winner = opponent.userName;
                    allGame.Add(game);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("This game won't play, because it will result to non-positive loser's rating");
                }
            }
        }
        private GameAccount defineOppNum(Game game)
        {
            if (userName == game.player1.userName)
            {
                return game.player2;
            }
            else if (userName == game.player2.userName)
            {
                return game.player1;
            }
            else return null;
        }
        public void getStats()
        {

            Console.WriteLine("Player's stats:\n\n"+"Player's name: "+ userName+ "   Count of games: " + GamesCount);
            foreach (var games in allGame)
            {
                if (games.player1.userName == this.userName)
                {
                    infoAboutGame(games);
                }
                else if (games.player2.userName == this.userName)
                {
                    infoAboutGame(games);
                }
            }
        }
        private void infoAboutGame(Game currentGame)
        {
            Console.WriteLine("Type of game:" + currentGame.GameType +"\nOpponent : " + defineOppNum(currentGame).userName + "\nGame's rating: " + currentGame.Rating
                        + "\nIndex of game: " + currentGame.gameIndex+ "\nWinner: "+ currentGame.Winner+"\n\n");

        }
    }
}
