using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Morabaraba
{
    public class Game : IGame
    {
        public void printInstructions()
        {
            Console.Write("Morabaraba Game Instructions\n\nHOW TO START\n1. 	To start you need the Morabaraba game board. \n	The board starts empty, each player holding all his pieces (or 'cows') \n	in hand.\n2. 	Each player has 12 cows. One player plays white, \n	the other black.\n\nRULES\n1. 	The gameboard for Morabaraba.\n2. 	When a player is reduced to 3 pieces, his pieces are free \n	to move to any unoccupied point (or 'fly'), instead of being restricted \n	to adjacent points as earlier in the game.\n\nGAMEPLAY\n1. 	At first, each player in turn puts one piece on the board, \n	at any vacant point.\n2. 	Once all pieces are on the board, a player now moves one of \n	his pieces along a marked line to an adjacent empty point.\n3. 	If a piece placed or moved forms a row of three along a marked\n 	line (This is called a mill), he can take one of his opponent's \n	pieces (ie. kill an oponents 'cow'), as long as that piece is not itself part of a mill.\n4. 	If when capturing, all opposing pieces have formed mills, then\n 	any of the pieces may be captured.\n\nHOW TO WIN\n1. 	The goal of the game is to reduce your opponent's pieces to as\n 	little as possible.\n2. 	A player wins the game when his opponent is reduced to 2 pieces \n	and is thus unable to form a mill or make any further captures.\n3. 	If the board is filled in the first phase, and no pieces taken, \n	the second phase will be gridlocked with neither player able to move.\n 	In this case the game is draw.\n\n");
            Console.WriteLine("Press Enter to begin the game:");
            Console.ReadLine();
        }

        public bool validateInput(string ans)
        {
            string state = currentPlayer.getState();
            List<string> positionsHeld = currentPlayer.getPositionsHeld();
            string name = currentPlayer.getName();

            if(ans != " ")
            {
                if (state == "Placing")
                {
                    if (Board.isAvailable(ans))
                    {
                        return true;
                    }
                    else { return false; }
                }
                else if (state == "Moving")
                {
                    string[] answers = ans.Split(' ');
                    string ans1 = answers[0];
                    string ans2 = answers[1];

                    if (positionsHeld.Contains(ans1)) // it's their cow
                    {

                        if (Board.isAvailable(ans2)) // pos is empty
                        {
                            if(Board.checkAdjacency(ans1, ans2)) // pos is adjacent to their cow pos
                            {
                                return true;
                            }
                            else { return false; }
                        }
                        else { return false; }
                    
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (state == "Flying")
                {
                    string[] answers = ans.Split(' ');
                    string ans1 = answers[0];
                    string ans2 = answers[1];

                    if (positionsHeld.Contains(ans1)) // is their cow 
                    {
                        if (Board.isAvailable(ans2)) // pos is empty
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }
                else { return false; }
            }
            else { return false; }
        }

        public void SwitchPlayer()
        {

            if (currentPlayer == Black)
            {
                currentPlayer = White;
                otherPlayer = Black; 
            }
            else
            {
                currentPlayer = Black;
                otherPlayer = White; 
            }
        }

        public void validateKill(string kill)
        {
            List<string> positionsHeld = otherPlayer.getPositionsHeld();
            if (positionsHeld.Contains(kill))
            {
                // could've used a bool here but that would have cancelled out this being able to be 
                // a recursive function -> so I can leave this 'true' case empty because the method 
                // will repeat until a valid kill is given by the user -> the game will only continue
                // once a valid position has been given 
            }
            else
            {
                Console.WriteLine("The position is not valid. Please enter a valid position to place a cow on the board.");
                kill = Console.ReadLine().ToUpper();
                validateKill(kill);
            }

        }

        public string checkForWinner()
        {
            if(currentPlayer.getState() == "Flying" && currentPlayer.getOnBoard() < 3)
            {
                return otherPlayer.getName(); 
            }
            else if(otherPlayer.getState() == "Flying" && otherPlayer.getOnBoard() < 3)
            {
                return currentPlayer.getName();
            }
            else { return null; }
        }

        public void Run()
        {
            printInstructions();
            Board.printGameBoard();
            string ans = currentPlayer.getInput();
            if (validateInput(ans))
            {
                // place piece
                Board.Placing(ans, currentPlayer);
                // add position to player's positionsHeld
                List<string> positionsHeld = currentPlayer.getPositionsHeld();
                positionsHeld.Add(ans);
                currentPlayer.updatePositionsHeld(positionsHeld);
                // and check player state
                currentPlayer.checkPlayerState(); 
                // if in placing -> increment player's onBoard by 1
                // and decrement unplaced
                if (currentPlayer.getState() == "Placing")
                {
                    currentPlayer.updatePieces(1, -1); 
                }
                // and print board
                Board.printGameBoard(); 
                // then we need to check for mills
                if (Board.checkMills(currentPlayer)) 
                {
                    // possibly do a kill
                    Console.WriteLine("You've made a mill! choose one of the other player's cows to kill:");
                    string kill = Console.ReadLine().ToUpper();
                    validateKill(kill);

                    if(Board.check(kill, otherPlayer) != null)
                    {
                        string[] playerMill = Board.check(kill, otherPlayer);
                        List<string[]> playerMills = otherPlayer.getPlayerMills();
                        playerMills.Add(playerMill);
                        otherPlayer.updateMills(playerMills); 
                    }
                    // here's the kill
                    Board.Killing(kill);
                    // remove kill from otherPlayer's positionsHeld --> create updatePositionsHeld method
                    List<string> positionsHeld1 = otherPlayer.getPositionsHeld();
                    positionsHeld1.Remove(ans);
                    otherPlayer.updatePositionsHeld(positionsHeld1);
                    // decrement otherPlayer's onBoard count by 1 --> create updateOnBoard method
                    otherPlayer.updatePieces(-1, 0); 
                }
                // print the board
                Board.printGameBoard();
                // check the player's states
                currentPlayer.checkPlayerState();
                otherPlayer.checkPlayerState();
                // check for winner
                if(checkForWinner() != null)
                {
                    Console.WriteLine("Player {0} has won!!", checkForWinner());
                    Console.ReadLine();
                }
                else
                {
                    // switch players
                    SwitchPlayer();
                    // and run the game again
                    Run();
                }
            }
            else
            {
                Console.WriteLine("The position is not valid. Press enter to try again...");
                Console.ReadLine();
                Run(); 
            }
        }

        IPlayer Black;
        IPlayer White;
        IBoard Board;
        IPlayer currentPlayer;
        IPlayer otherPlayer; 

        public Game(IPlayer black, IPlayer white, IBoard board)
        {
            Black = black;
            White = white;
            Board = board;
            currentPlayer = black;
            otherPlayer = white; 
        }
    }
}
