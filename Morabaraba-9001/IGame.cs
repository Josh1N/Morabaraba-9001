using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface IGame
    {
        void printInstructions();
        void Run();
        IPlayer getCurrentPlayer();
        bool validateInput(string ans);
        bool validateKill(string kill, IPlayer otherPlayer);
    }
}
