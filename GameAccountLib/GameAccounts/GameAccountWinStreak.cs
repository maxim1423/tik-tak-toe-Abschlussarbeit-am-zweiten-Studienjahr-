using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.GameAccounts
{
    public class GameAccountWinStreak : GameAccount
    {
        public int countWinsOnStreak = 0;
        public GameAccountWinStreak(string userName) : base(userName)
        {
        }

        internal override int calcLosingPoint(Game game)
        {
            countWinsOnStreak = 0;
            return game.calcLosingPoints();
        }

        internal override int calcWinningPoint(Game game)
        {
            countWinsOnStreak++;
            return countWinsOnStreak >= 3 ? game.calcWinningPoints() * 2 : game.calcWinningPoints();
        }

       
    }
}
