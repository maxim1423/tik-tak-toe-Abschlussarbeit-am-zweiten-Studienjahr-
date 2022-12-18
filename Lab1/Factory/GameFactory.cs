using System;
using System.Collections.Generic;
using System.Text;
using Lab2.GameAccounts;
using Lab2.Games;

namespace Lab2.Factory
{
    class GameFactory
    {
        public Game createNormalGame(GameAccount player1, GameAccount player2, int rating)
        {
            return new NormalGame(player1, player2, rating);
        }
        public Game createSafeLoseGame(GameAccount player1, GameAccount player2, int rating)
        {
            return new SafeLoseGame(player1, player2, rating);
        }
        public Game createTrainingGame(GameAccount player1, GameAccount player2)
        {
            return new TrainingGame(player1, player2);
        }
    }
}
