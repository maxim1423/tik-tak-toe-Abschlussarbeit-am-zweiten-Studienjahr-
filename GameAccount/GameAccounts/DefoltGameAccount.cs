using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.GameAccounts
{
    class DefoltGameAccount : GameAccount
    {
        public DefoltGameAccount(string userName) : base(userName)
        {
        }

        protected override int calcLosingPoint(Game game)
        {
            return game.calcLosingPoints();
        }

        protected override int calcWinningPoint(Game game)
        {
            return game.calcWinningPoints();
        }
    }
}
