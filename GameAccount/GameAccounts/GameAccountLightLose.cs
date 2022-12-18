using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.GameAccounts
{
    class GameAccountLightLose : GameAccount
    {
        public GameAccountLightLose(string userName) : base(userName)
        {
        }

        protected override int calcLosingPoint(Game game)
        {
            return game.calcLosingPoints()/2;
        }

        protected override int calcWinningPoint(Game game)
        {
            return game.calcWinningPoints();
        }
       
        
    }
}
