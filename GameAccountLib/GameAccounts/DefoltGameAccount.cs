using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.GameAccounts
{
    public class DefoltGameAccount : GameAccount
    {
        public DefoltGameAccount(string userName) : base(userName)
        {
        }

        internal override int calcLosingPoint(Game game)
        {
            return game.calcLosingPoints();
        }

        internal override int calcWinningPoint(Game game)
        {
            return game.calcWinningPoints();
        }
    }
}
