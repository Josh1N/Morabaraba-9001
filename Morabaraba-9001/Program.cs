
using System;
using System.Collections.Generic;

namespace Morabaraba
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPlayer black = new Player("Black", 'B');
            IPlayer white = new Player("White", 'W');
            IBoard b = new Board();
            b.printGameBoard(); 
            IGame myGame = new Game(black, white, b);
            myGame.Run(); 
        }
    }
}
