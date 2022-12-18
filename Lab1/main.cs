
using Lab2.Games;
using Lab2.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.GameAccountLib.GameAccounts;

namespace Lab2.Games
{
    class Lab2
    {
        public static void Main()
        {
            GameFactory factory = new GameFactory();
            GameAccount Max = new DefoltGameAccount("Max");
            GameAccount David = new GameAccountLightLose("David");
            GameAccount Roman = new GameAccountWinStreak("Roman");
            /*Max.WinWithValidation(factory.createNormalGame(Max, David, 7));
            David.LoseWithValidation(factory.createTrainingGame(David, Max));
            Roman.WinWithValidation(factory.createSafeLoseGame(Roman, Max, 100));
            David.LoseWithValidation(factory.createNormalGame(Max, David, 6));
            
            Roman.WinWithValidation(factory.createTrainingGame(David, Roman));
            Roman.WinWithValidation(factory.createSafeLoseGame(Max, Roman, 3));
            Max.LoseWithValidation(factory.createNormalGame(Roman, Max, 2));*/
            
            Roman.LoseWithValidation(factory.createNormalGame(Max, David,8));
            Roman.LoseWithValidation(factory.createNormalGame(Max, Roman, 100));
            //David.LoseWithValidation(factory.createSafeLoseGame(David, Roman, 5));
            Console.WriteLine(Max.currentRating + "\n" + David.currentRating + "\n" + Roman.currentRating);
         }
    }

}
