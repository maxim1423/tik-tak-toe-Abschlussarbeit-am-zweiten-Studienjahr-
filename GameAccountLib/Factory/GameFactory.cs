using Lab2;
using Lab2.GameAccounts;
using Lab2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAccountLib.Factory
{
    public class GameFactory
    {
        public Game createGame(GameAccount player1,GameAccount player2, int rating,string Type)
        {
            if (Type == "Normal")
            {
                return new NormalGame(player1, player2, rating);
            }
            else if (Type == "SafeLose")
            {
                return new SafeLoseGame(player1, player2, rating);
            }
            else
            {
                return new TrainingGame(player1, player2);
            }
        }

    }
}
