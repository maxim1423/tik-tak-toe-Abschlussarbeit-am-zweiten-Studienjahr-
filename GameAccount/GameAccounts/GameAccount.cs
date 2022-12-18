using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.GameAccounts
{
    public abstract class GameAccount
    {
        private string userName { get; set; }
        private static int startRating = 10;
        private int currentRating = startRating;
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

        protected abstract int calcLosingPoint(Game game);

        protected abstract int calcWinningPoint(Game game);

        protected  void LoseValidation(Game game,GameAccount player)
        {
            if (currentRating <= player.calcLosingPoint(game))
            {
                throw new InvalidOperationException(
                    "You can't play on this rating, because if you lose, your rating will be below than 1"
                    );
            }
            if (game.rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game.rating),
                    "You can't play on negative rating");
            }
        }

        protected void WinValidation(Game game,GameAccount hisOpponent)
        {
            if (hisOpponent.currentRating <= hisOpponent.calcLosingPoint(game))
            {
                throw new InvalidOperationException(
                    "We can't play on this rating,because if  your opponent lose, his rating will be below than 1"
                    );
            }
            if (game.rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game.rating),
                    "You can't play on negative rating");
            }
        }

        public void WinWithValidation(Game game)
        {
            GameAccount opponent = defineOppNum(game);
            if (opponent == null) Console.WriteLine("There isn't the player from who the function was run in list of this game's players");
            else
            {
                WinValidation(game, opponent);

                opponent.GamesCount++;
                opponent.currentRating -= opponent.calcLosingPoint(game);
                GamesCount++;
                currentRating += calcWinningPoint(game);
                game.Winner = this.userName;
                allGame.Add(game);
            }
        }
        public void LoseWithValidation(Game game)
        {
            GameAccount opponent = defineOppNum(game);
            if (opponent == null) Console.WriteLine("There isn't the player from who the function was run in list of this game's players. Game wasn't played");
            else
            {
                LoseValidation(game, this);
                opponent.GamesCount++;
                opponent.currentRating+=opponent.calcWinningPoint(game);
                GamesCount++;
                currentRating -= calcLosingPoint(game);
                game.Winner = opponent.userName;
                allGame.Add(game);
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
            Console.WriteLine("Count of games: " + GamesCount);
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
                Console.WriteLine("\n");
            }
        }
        private void infoAboutGame(Game currentGame)
        {
            Console.WriteLine("Type of game:" + currentGame.TypeOfGame + "Opponent : " + currentGame.player2.userName + "\nGame's rating: " + currentGame.rating
                        + "\nIndex of game: " + currentGame.gameIndex+ "\n ");
        }
    }
}
