using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba
{
    public class Board : IBoard
    {
        public List<string> board = new List<string>()
        {
            "  1  2  3   4   5  6  7  \n",
            "A O ------- O ------- O  \n",  //A1 =[1][2]    A4=[1][12]      A7=[1][22]
            "  | '       |       ' |  \n",
            "B |  O ---- O ---- O  |  \n",  //B2 =[3][5]    B4=[3][12]      B6=[3][19]
            "  |  | '    |   '  |  |  \n",
            "C |  |  O - O - O  |  |  \n",  //C3 =[5][8]    C4 =[5][12]     C5=[5][16]
            "  |  |  |       |  |  |  \n",
            "D O -O- O       O -O- O  \n",  //D1=[7][2]     D2=[7][5]       D3=[7][8]     D5=[7][16]     D6=[7][19]    D7=[7][22]
            "  |  |  |       |  |  |  \n",
            "E |  |  O - O - O  |  |  \n",  //E3=[9][8]     E4=[9][12]      E5=[9][16]
            "  |  | '    |    ' |  |  \n",
            "F |  O ---- O ---- O  |  \n",  //F2=[11][5]    F4=[11][12]     F6=[11][19]    
            "  | '       |       ' |  \n",
            "G O ------- O ------- O  \n\n"  //G1=[13][2]   G4=[13][12]     G7=[13][22]
        };
        public List<string> gameBoard { get => board; }

        public List<string> Positions = new List<string> { "A1", "A4", "A7", "B2", "B4", "B6", "C3", "C4", "C5", "D1", "D2", "D3", "D5", "D6", "D7", "E3", "E4", "E5", "F2", "F4", "F6", "G1", "G4", "G7" };
        public List<string> availablePositions = new List<string> { "A1", "A4", "A7", "B2", "B4", "B6", "C3", "C4", "C5", "D1", "D2", "D3", "D5", "D6", "D7", "E3", "E4", "E5", "F2", "F4", "F6", "G1", "G4", "G7" };

        // have a named array for each possible mill
        string[] m0 = new string[] { "A1", "A4", "A7" };
        string[] m1 = new string[] { "B2", "B4", "B6" };
        string[] m2 = new string[] { "C3", "C4", "C5" };
        string[] m3 = new string[] { "D1", "D2", "D3" };
        string[] m4 = new string[] { "D5", "D6", "D7" };
        string[] m5 = new string[] { "E3", "E4", "E5" };
        string[] m6 = new string[] { "F2", "F4", "F6" };
        string[] m7 = new string[] { "G1", "G4", "G7" };
        string[] m8 = new string[] { "A1", "D1", "G1" };
        string[] m9 = new string[] { "B2", "D2", "F2" };
        string[] m10 = new string[] { "C3", "D3", "E3" };
        string[] m11 = new string[] { "A4", "B4", "C4" };
        string[] m12 = new string[] { "E4", "F4", "G4" };
        string[] m13 = new string[] { "C5", "D5", "E5" };
        string[] m14 = new string[] { "B6", "D6", "F6" };
        string[] m15 = new string[] { "A7", "D7", "G7" };
        string[] m16 = new string[] { "A1", "B2", "C3" };
        string[] m17 = new string[] { "A7", "B6", "C5" };
        string[] m18 = new string[] { "G1", "F2", "E3" };
        string[] m19 = new string[] { "G7", "F6", "E5" };

        List<string[]> availableMills;

        public void Placing(string pos, IPlayer currentPlayer)
        {
            availablePositions.Remove(pos); 

            char place = currentPlayer.getPlace(); 

            string rowA = board[1];
            char posA1 = rowA[2];
            char posA4 = rowA[12];
            char posA7 = rowA[22];

            string rowB = board[3];
            char posB2 = rowB[5];
            char posB4 = rowB[12];
            char posB6 = rowB[19];

            string rowC = board[5];
            char posC3 = rowC[8];
            char posC4 = rowC[12];
            char posC5 = rowC[16];

            string rowD = board[6];
            char posD1 = rowD[2];
            char posD2 = rowD[5];
            char posD3 = rowD[8];
            char posD5 = rowD[16];
            char posD6 = rowD[19];
            char posD7 = rowD[22];

            string rowE = board[7];
            char posE3 = rowE[8];
            char posE4 = rowE[12];
            char posE5 = rowE[16];

            string rowF = board[8];
            char posF2 = rowF[5];
            char posF4 = rowF[12];
            char posF6 = rowF[19];

            string rowG = board[9];
            char posG1 = rowG[2];
            char posG4 = rowG[12];
            char posG7 = rowG[22];


            switch (pos)
            {
                //A
                case "A1":
                    posA1 = place;
                    string updateLine = board[1].Remove(2, 1);
                    updateLine = updateLine.Insert(2, posA1.ToString());
                    board[1] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "A4":
                    posA4 = place;
                    updateLine = board[1].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posA4.ToString());
                    board[1] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "A7":
                    posA7 = place;
                    updateLine = board[1].Remove(22, 1);
                    updateLine = updateLine.Insert(22, posA7.ToString());
                    board[1] = updateLine;
                    Positions.Remove(pos);
                    break;

                //B
                case "B2":
                    posB2 = place;
                    updateLine = board[3].Remove(5, 1);
                    updateLine = updateLine.Insert(5, posB2.ToString());
                    board[3] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "B4":
                    posB4 = place;
                    updateLine = board[3].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posB4.ToString());
                    board[3] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "B6":
                    posB6 = place;
                    updateLine = board[3].Remove(19, 1);
                    updateLine = updateLine.Insert(19, posB6.ToString());
                    board[3] = updateLine;
                    Positions.Remove(pos);
                    break;
                case "C3":
                    posC3 = place;
                    updateLine = board[5].Remove(8, 1);
                    updateLine = updateLine.Insert(8, posC3.ToString());
                    board[5] = updateLine;
                    Positions.Remove(pos);
                    break;
                case "C4":
                    posC4 = place;
                    updateLine = board[5].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posC4.ToString());
                    board[5] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "C5":
                    posC5 = place;
                    updateLine = board[5].Remove(16, 1);
                    updateLine = updateLine.Insert(16, posC5.ToString());
                    board[5] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "D1":
                    posD1 = place;
                    updateLine = board[7].Remove(2, 1);
                    updateLine = updateLine.Insert(2, posD1.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;


                case "D2":
                    posD2 = place;
                    updateLine = board[7].Remove(5, 1);
                    updateLine = updateLine.Insert(5, posD2.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "D3":
                    posD3 = place;
                    updateLine = board[7].Remove(8, 1);
                    updateLine = updateLine.Insert(8, posD3.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "D5":
                    posD5 = place;
                    updateLine = board[7].Remove(16, 1);
                    updateLine = updateLine.Insert(16, posD5.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "D6":
                    posD6 = place;
                    updateLine = board[7].Remove(19, 1);
                    updateLine = updateLine.Insert(19, posD6.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;
                case "D7":
                    posD7 = place;
                    updateLine = board[7].Remove(22, 1);
                    updateLine = updateLine.Insert(22, posD7.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;

                //E
                case "E3":
                    posE3 = place;
                    updateLine = board[9].Remove(8, 1);
                    updateLine = updateLine.Insert(8, posE3.ToString());
                    board[9] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "E4":
                    posE4 = place;
                    updateLine = board[9].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posE4.ToString());
                    board[9] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "E5":
                    posE5 = place;
                    updateLine = board[9].Remove(16, 1);
                    updateLine = updateLine.Insert(16, posE5.ToString());
                    board[9] = updateLine;
                    Positions.Remove(pos);
                    break;

                //F
                case "F2":
                    posF2 = place;
                    updateLine = board[11].Remove(5, 1);
                    updateLine = updateLine.Insert(5, posF2.ToString());
                    board[11] = updateLine;
                    Positions.Remove(pos);
                    break;


                case "F4":
                    posF4 = place;
                    updateLine = board[11].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posF4.ToString());
                    board[11] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "F6":
                    posF6 = place;
                    updateLine = board[11].Remove(19, 1);
                    updateLine = updateLine.Insert(19, posF6.ToString());
                    board[11] = updateLine;
                    Positions.Remove(pos);
                    break;
                //G
                case "G1":
                    posG1 = place;
                    updateLine = board[13].Remove(2, 1);
                    updateLine = updateLine.Insert(2, posG1.ToString());
                    board[13] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "G4":
                    posG4 = place;
                    updateLine = board[13].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posG4.ToString());
                    board[13] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "G7":
                    posG7 = place;
                    updateLine = board[13].Remove(22, 1);
                    updateLine = updateLine.Insert(22, posG7.ToString());
                    board[13] = updateLine;
                    Positions.Remove(pos);
                    break;
            }
        }

        public bool isAvailable(string pos)
        {
            if (availablePositions.Contains(pos))
            {
                return true;
            }
            return false;
        }

        public bool checkAdjacency(string ans, string ans1)
        {
            bool adjacent = false;

            foreach (string[] mill in availableMills)
            {
                if (ans == mill[0] && ans1 == mill[1])
                {
                    adjacent = true;
                }
                else if (ans == mill[1] && ans1 == mill[2])
                {
                    adjacent = true;
                }
            }

            if (adjacent == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void printGameBoard()
        {
            foreach (string r in board)
            {
                Console.WriteLine(r);
            }
        }

        public bool checkMills(IPlayer currentPlayer)
        {
            // go through player's positionsHeld list to see if they have any of the mills
            // if they do, remove mill from list and add to player's personal mill list 
            bool gotMills = false;
            List<string> positionsHeld = currentPlayer.getPositionsHeld();
            List<string[]> playerMills = currentPlayer.getPlayerMills(); // need to send updated playerMills back to player object
            // puts new mills into a players list and removes them from availableMills
            foreach (string[] mill in availableMills)
            {
                if (positionsHeld.Contains(mill[0]) && positionsHeld.Contains(mill[1]) && positionsHeld.Contains(mill[2]))
                {
                    gotMills = true;
                    playerMills.Add(mill);
                }
            }
            foreach (string[] mill in playerMills)
            {
                availableMills.Remove(mill);
            }

            // removes broken mills from players list and puts them back in availableMills

            // this mechanism prevents mills from being used twice beacause the mill, once made and used, will remain on the player's list,
            // and therefor not available, until broken and reformed. 
            foreach (string[] mill in playerMills)
            {
                if (mill != null)
                {
                    if (!(positionsHeld.Contains(mill[0]) && positionsHeld.Contains(mill[1]) && positionsHeld.Contains(mill[2])))
                    {
                        availableMills.Add(mill);
                    }
                }

            }
            foreach (string[] mill in availableMills)
            {
                playerMills.Remove(mill);
            }

            // player must then be presented with option to kill
            // must design killing mechanism 
            currentPlayer.updateMills(playerMills); 
            return gotMills;
        }

        public void Killing(string pos)
        {
            availablePositions.Add(pos); 

            string rowA = board[1];
            char posA1 = rowA[2];
            char posA4 = rowA[12];
            char posA7 = rowA[22];

            string rowB = board[3];
            char posB2 = rowB[5];
            char posB4 = rowB[12];
            char posB6 = rowB[19];

            string rowC = board[5];
            char posC3 = rowC[8];
            char posC4 = rowC[12];
            char posC5 = rowC[16];

            string rowD = board[6];
            char posD1 = rowD[2];
            char posD2 = rowD[5];
            char posD3 = rowD[8];
            char posD5 = rowD[16];
            char posD6 = rowD[19];
            char posD7 = rowD[22];

            string rowE = board[7];
            char posE3 = rowE[8];
            char posE4 = rowE[12];
            char posE5 = rowE[16];

            string rowF = board[8];
            char posF2 = rowF[5];
            char posF4 = rowF[12];
            char posF6 = rowF[19];

            string rowG = board[9];
            char posG1 = rowG[2];
            char posG4 = rowG[12];
            char posG7 = rowG[22];


            switch (pos)
            {
                //A
                case "A1":
                    posA1 = 'O';
                    string updateLine = board[1].Remove(2, 1);
                    updateLine = updateLine.Insert(2, posA1.ToString());
                    board[1] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "A4":
                    posA4 = 'O';
                    updateLine = board[1].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posA4.ToString());
                    board[1] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "A7":
                    posA7 = 'O';
                    updateLine = board[1].Remove(22, 1);
                    updateLine = updateLine.Insert(22, posA7.ToString());
                    board[1] = updateLine;
                    Positions.Remove(pos);
                    break;

                //B
                case "B2":
                    posB2 = 'O';
                    updateLine = board[3].Remove(5, 1);
                    updateLine = updateLine.Insert(5, posB2.ToString());
                    board[3] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "B4":
                    posB4 = 'O';
                    updateLine = board[3].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posB4.ToString());
                    board[3] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "B6":
                    posB6 = 'O';
                    updateLine = board[3].Remove(19, 1);
                    updateLine = updateLine.Insert(19, posB6.ToString());
                    board[3] = updateLine;
                    Positions.Remove(pos);
                    break;
                case "C3":
                    posC3 = 'O';
                    updateLine = board[5].Remove(8, 1);
                    updateLine = updateLine.Insert(8, posC3.ToString());
                    board[5] = updateLine;
                    Positions.Remove(pos);
                    break;
                case "C4":
                    posC4 = 'O';
                    updateLine = board[5].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posC4.ToString());
                    board[5] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "C5":
                    posC5 = 'O';
                    updateLine = board[5].Remove(16, 1);
                    updateLine = updateLine.Insert(16, posC5.ToString());
                    board[5] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "D1":
                    posD1 = 'O';
                    updateLine = board[7].Remove(2, 1);
                    updateLine = updateLine.Insert(2, posD1.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;


                case "D2":
                    posD2 = 'O';
                    updateLine = board[7].Remove(5, 1);
                    updateLine = updateLine.Insert(5, posD2.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "D3":
                    posD3 = 'O';
                    updateLine = board[7].Remove(8, 1);
                    updateLine = updateLine.Insert(8, posD3.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "D5":
                    posD5 = 'O';
                    updateLine = board[7].Remove(16, 1);
                    updateLine = updateLine.Insert(16, posD5.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "D6":
                    posD6 = 'O';
                    updateLine = board[7].Remove(19, 1);
                    updateLine = updateLine.Insert(19, posD6.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;
                case "D7":
                    posD7 = 'O';
                    updateLine = board[7].Remove(22, 1);
                    updateLine = updateLine.Insert(22, posD7.ToString());
                    board[7] = updateLine;
                    Positions.Remove(pos);
                    break;

                //E
                case "E3":
                    posE3 = 'O';
                    updateLine = board[9].Remove(8, 1);
                    updateLine = updateLine.Insert(8, posE3.ToString());
                    board[9] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "E4":
                    posE4 = 'O';
                    updateLine = board[9].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posE4.ToString());
                    board[9] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "E5":
                    posE5 = 'O';
                    updateLine = board[9].Remove(16, 1);
                    updateLine = updateLine.Insert(16, posE5.ToString());
                    board[9] = updateLine;
                    Positions.Remove(pos);
                    break;

                //F
                case "F2":
                    posF2 = 'O';
                    updateLine = board[11].Remove(5, 1);
                    updateLine = updateLine.Insert(5, posF2.ToString());
                    board[11] = updateLine;
                    Positions.Remove(pos);
                    break;


                case "F4":
                    posF4 = 'O';
                    updateLine = board[11].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posF4.ToString());
                    board[11] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "F6":
                    posF6 = 'O';
                    updateLine = board[11].Remove(19, 1);
                    updateLine = updateLine.Insert(19, posF6.ToString());
                    board[11] = updateLine;
                    Positions.Remove(pos);
                    break;
                //G
                case "G1":
                    posG1 = 'O';
                    updateLine = board[13].Remove(2, 1);
                    updateLine = updateLine.Insert(2, posG1.ToString());
                    board[13] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "G4":
                    posG4 = 'O';
                    updateLine = board[13].Remove(12, 1);
                    updateLine = updateLine.Insert(12, posG4.ToString());
                    board[13] = updateLine;
                    Positions.Remove(pos);
                    break;

                case "G7":
                    posG7 = 'O';
                    updateLine = board[13].Remove(22, 1);
                    updateLine = updateLine.Insert(22, posG7.ToString());
                    board[13] = updateLine;
                    Positions.Remove(pos);
                    break;
            }
        }

        public string[] check(string ans, IPlayer player)
        {
            List<string[]> playerMills = player.getPlayerMills(); 
            foreach (string[] mill in playerMills)
            {
                List<string> check = new List<string>();
                check = mill.ToList();
                if (check.Contains(ans))
                {
                    return mill;
                }
            }
            return null;
        }

        public Board()
        {
            availableMills = new List<string[]> { m0, m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16, m17, m18, m19 };
        }
    }
}
