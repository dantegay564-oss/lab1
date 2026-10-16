using System;

namespace CatAndMouse
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 3; i++)
            {
                Game.InputFile = i + ".ChaseData.txt";
                Game.OutFile = i + ".PursuitLog.txt";
                Game game = new Game(1); 
                game.Run();
                Console.WriteLine(i + ".PursuitLog.txt создан");
            }
            Console.ReadKey();
        }
    }
}