using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {
        int unplaced = 12;
        int onBoard = 0;
        string name;
        string state;
        char place;
        List<string[]> playerMills = new List<string[]>();
        List<string> positionsHeld = new List<string>();

        public string getState()
        {
            return state; 
        }
        public string getName()
        {
            return name;
        }
        public List<string> getPositionsHeld()
        {
            return positionsHeld;
        }
        public char getPlace()
        {
            return place;
        }
        public List<string[]> getPlayerMills()
        {
            return playerMills; 
        }
        public string checkPlayerState()
        {
            if (unplaced > 0)
            {
                state = "Placing";
                return "Placing";
            }
            else if (unplaced == 0)
            {
                state = "Moving"; 
                return "Moving";
            }
            else if (onBoard < 4 && unplaced == 0)
            {
                state = "Flying"; 
                return "Flying";
            }
            else
            {
                return " "; 
            }
        }
        public string getInput()
        {
            checkPlayerState(); 
            if (state == "Placing")
            {
                Console.WriteLine(string.Format("Unplaced Cows: {0} Cows on Board: {1}", unplaced.ToString(), onBoard.ToString()));
                Console.WriteLine(string.Format("State: {0}", state));
                Console.WriteLine(string.Format("Player {0} enter a position to place cow.", name));

                string ans = Console.ReadLine().ToUpper();
                return ans; 
            }
            else if (state == "Moving")
            {
                Console.WriteLine(string.Format("Unplaced Cows: {0} Cows on Board: {1}", unplaced.ToString(), onBoard.ToString()));
                Console.WriteLine(string.Format("State: {0}", state));
                Console.WriteLine(string.Format("Player {0} enter the position of the cow you would like to move and the position you would like to move your cow to, separated by a space.", name));

                string ans = Console.ReadLine().ToUpper();
                return ans; 
            }
            else if (state == "Flying")
            {
                Console.WriteLine(string.Format("Unplaced Cows: {0} Cows on Board: {1}", unplaced.ToString(), onBoard.ToString()));
                Console.WriteLine(string.Format("State: {0}", state));
                Console.WriteLine(string.Format("Player {0} enter the position of the cow you would like to move and the position you would like to move your cow to, separated by a space.", name));

                string ans = Console.ReadLine().ToUpper();
                return ans; 
            }
            else { return " "; }
        }
        public void updateMills(List<string[]> updated)
        {
            playerMills = updated; 
        }
        public void updatePositionsHeld(List<string> updated)
        {
            positionsHeld = updated; 
        }
        public void updatePieces(int onB, int unP)
        {
            onBoard += onB;
            unplaced += unP; 
        }
        public int getOnBoard()
        {
            return onBoard;
        }
        public int getUnplaced()
        {
            return unplaced; 
        }

        //public void updateUnplaced(int updated)
        //{
        //    unplaced = updated; 
        //}

        public Player(string Name, char Place)
        {
            state = checkPlayerState();
            name = Name;
            place = Place; 
        }
    }
}
