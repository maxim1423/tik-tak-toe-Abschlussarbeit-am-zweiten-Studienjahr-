using System;
using System.Collections.Generic;

namespace Lab1
{
    
    class Game
    {
        public String player1;
        public String player2;
        public int rating;
        public int gameIndex;
        private static int gameIndexSeed = 123321;
        public bool isWin;

        public Game(String yourName, String opponentName, int rating, bool result)
        {
            player1 = yourName;
            player2 = opponentName;
            this.rating = rating;
            isWin = result;
            gameIndex = gameIndexSeed++;
        }

    }
    public class GameAccount
    {
        private string userName;
        private static int startRating = 10;
        private int currentRating = startRating;
        private int gamesCount;
        private static List<Game> allGame = new List<Game>();
        public int CurrentRating
        {
            get
            {
                int rating = startRating;
                foreach (var games in allGame)
                {
                    if (games.player1 == this.userName)
                    {
                        if (games.isWin)
                        {
                            rating += games.rating;
                        }
                        else
                        {
                            rating -= games.rating;
                        }
                    }
                    if (games.player2 == this.userName)
                    {
                        if (games.isWin)
                        {
                            rating -= games.rating;
                        }
                        else
                        {
                            rating += games.rating;
                        }
                    }
                }
                return rating;
            }
        }
        public GameAccount(String userName)
        {
            this.userName = userName;
            gamesCount = 0;
        }

        public void LoseGame(GameAccount gamer, int rating)
        {
            gamesCount++;
            gamer.gamesCount++;
            if (CurrentRating <= rating)
            {
                throw new InvalidOperationException(
                    "You can't play on this rating, because if you lose, your rating will be below than 1"
                    );
            }
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating),
                    "You can't play on negative rating");
            }

            allGame.Add(new Game(this.userName, gamer.userName, rating, false));

        }



        public void WinGame(GameAccount gamer, int rating)
        {
            gamesCount++;
            gamer.gamesCount++;
            if (gamer.CurrentRating <= rating)
            {
                throw new InvalidOperationException(
                    "We can't play on this rating, if because your opponent lose, his rating will be below than 1"
                    );
            }
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating),
                    "You can't play on negative rating");
            }
            allGame.Add(new Game(this.userName, gamer.userName, rating, true));
        }
        public void getStats()
        {
            Console.WriteLine("Count of games: " + gamesCount);
            foreach (var games in allGame)
            {
                if (games.player1 == this.userName)
                {
                    infoAboutGame(games);
                }
                else if (games.player2 == this.userName)
                {
                    infoAboutGame(games);
                }
                Console.WriteLine("\n");
            }
        }
        private void infoAboutGame(Game currentGame)
        {
            Console.WriteLine("Opponent : " + currentGame.player2 + "\nGame's rating: " + currentGame.rating
                        + "\nIndex of game: " + currentGame.gameIndex);
            if (currentGame.isWin)
            {
                Console.WriteLine("Result: win ");
            }
            else
            {
                Console.WriteLine("Result: lose");
            }
        }

    }
    class Lab1
    {
        public static void Main()
        {
            GameAccount firstG = new GameAccount("Max");
            GameAccount secondG = new GameAccount("Danil");
            firstG.WinGame(secondG, 4);
            firstG.LoseGame(secondG, 4);
            secondG.LoseGame(firstG, 7);
            secondG.WinGame(firstG, 4);
            firstG.LoseGame(secondG, 2);
            firstG.getStats();
            secondG.getStats();
        }
    }

}
