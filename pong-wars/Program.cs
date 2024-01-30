using System;
using DIKUArcade.GUI;

namespace pong_wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var windowArgs = new WindowArgs() { Title = "pong_wars v0.1" };
            var game = new Game(windowArgs);
            game.Run();
        }
    }
}
