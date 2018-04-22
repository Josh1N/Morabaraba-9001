using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface IPlayer
    {
        string checkPlayerState();
        string getInput();
        string getState();
        string getName();
        char getPlace(); 
        List<string> getPositionsHeld();
        List<string[]> getPlayerMills();
        void updateMills(List<string[]> updated);
        void updatePositionsHeld(List<string> updated);
        void updatePieces(int onB, int unP);
        int getOnBoard();
        int getUnplaced();
    }
}