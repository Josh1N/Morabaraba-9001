using System.Collections.Generic;

namespace Morabaraba
{
    public interface IBoard
    {
        void printGameBoard();
        bool isAvailable(string pos);
        bool checkAdjacency(string ans, string ans1);
        void Killing(string pos);
        void Placing(string pos, IPlayer currentPlayer);
        bool checkMills(IPlayer currentPlayer);
        string[] check(string ans, IPlayer player);
    }
}