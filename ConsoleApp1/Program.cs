using System;
using Lab2.Factory;
using Lab2.GameAccounts;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFactory factory = new GameFactory();
            GameAccount Max = new DefoltGameAccount("Max");
            GameAccount David = new GameAccountLightLose("David");
            GameAccount Roman = new GameAccountWinStreak("Roman");
            Max.WinGame(factory.createNormalGame(Max, David, 7));
            David.LoseGame(factory.createTrainingGame(David, Max));
            Roman.WinGame(factory.createSafeLoseGame(Roman, Max, 100));
            David.LoseGame(factory.createNormalGame(Max, David, 6));
            Roman.WinGame(factory.createTrainingGame(David, Roman));
            Roman.WinGame(factory.createSafeLoseGame(Max, Roman, 3));
            Max.LoseGame(factory.createNormalGame(Roman, Max, 2));
            Roman.LoseGame(factory.createTrainingGame(Max,Roman));
            David.LoseGame(factory.createNormalGame(David, Roman, 7));
            Max.getStats();
            David.getStats();
            Roman.getStats();
        }
    }
}
