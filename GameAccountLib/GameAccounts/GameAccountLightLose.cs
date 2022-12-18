using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.GameAccounts
{
    public class GameAccountLightLose : GameAccount
    {
        public GameAccountLightLose(string userName) : base(userName)
        {
        }

        internal override int calcLosingPoint(Game game)
        {
            return game.calcLosingPoints()/2;
        }

        internal override int calcWinningPoint(Game game)
        {
            return game.calcWinningPoints();
        }
       
        
    }
}
