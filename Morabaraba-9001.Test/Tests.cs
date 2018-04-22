using System;
using System.Linq;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;
using Morabaraba;

namespace Morabaraba_9001.Test 
{
    [TestFixture]
    public class Test
    {
        //Placement testing 
        /*
         * When the game starts, the board is empty
         * The player with dark cows is given the first chance to move
         * Cows can only be placed on empty spaces
         * A maximum of 12 placements per player are allowed
         * Cows cannot be moved during placement
        */

        [Test]
        public void gameStart()
        {
            //arrange
            bool empty = false; 
            List<string> Positions = new List<string> { "A1", "A4", "A7", "B2", "B4", "B6", "C3", "C4", "C5", "D1", "D2", "D3", "D5", "D6", "D7", "E3", "E4", "E5", "F2", "F4", "F6", "G1", "G4", "G7" };
            IBoard mockBoard = Substitute.For<Board>();
            //act 
            foreach(string pos in Positions)
            {
                empty = mockBoard.isAvailable(pos); 
                if(empty == false) { break; }
            }
            //assert
            Assert.That(empty == true); 
        }

        [Test]
        public void blackPlayerStarts()
        {
            //arrange
            IPlayer mockBlack = Substitute.For<Player>("Black", 'B');
            IPlayer mockWhite = Substitute.For<Player>("White", 'W');
            IBoard mockBoard = Substitute.For<Board>();
            IGame mockGame = Substitute.For<Game>(mockBlack, mockWhite, mockBoard);
            //act
            IPlayer currentPLayer = mockGame.getCurrentPlayer();
            //assert
            Assert.That(currentPLayer == mockBlack); 
        }


        [Test]
        public void cowPlacementOnEmptySpace()
        {
            //arrange
            List<string> board1 = new List<string>()
            {
                "  1  2  3   4   5  6  7  \n",
                "A B ------- O ------- O  \n",  //A1 =[1][2]    A4=[1][12]      A7=[1][22]
                "  | '       |       ' |  \n",
                "B |  O ---- O ---- O  |  \n",  //B2 =[3][5]    B4=[3][12]      B6=[3][19]
                "  |  | '    |   '  |  |  \n",
                "C |  |  O - W - O  |  |  \n",  //C3 =[5][8]    C4 =[5][12]     C5=[5][16]
                "  |  |  |       |  |  |  \n",
                "D O -W- O       O -B- O  \n",  //D1=[7][2]     D2=[7][5]       D3=[7][8]     D5=[7][16]     D6=[7][19]    D7=[7][22]
                "  |  |  |       |  |  |  \n",
                "E |  |  O - B - O  |  |  \n",  //E3=[9][8]     E4=[9][12]      E5=[9][16]
                "  |  | '    |    ' |  |  \n",
                "F |  O ---- W ---- O  |  \n",  //F2=[11][5]    F4=[11][12]     F6=[11][19]    
                "  | '       |       ' |  \n",
                "G O ------- O ------- O  \n\n"  //G1=[13][2]   G4=[13][12]     G7=[13][22]
            };
            IPlayer mockBlack = Substitute.For<Player>("Black", 'B');
            IPlayer mockWhite = Substitute.For<Player>("White", 'W');
            IBoard mockBoard = Substitute.For<Board>();
            IGame mockGame = Substitute.For<Game>(mockBlack, mockWhite, mockBoard);
            mockBoard.updateBoard(board1);
            //act
            bool check1 = mockGame.validateInput("A1");
            //assert
            Assert.That(check1 == false);
        }

        [Test]
        public void twelveCowsPerPlayer()
        {
            //arrange
            IPlayer mockBlack = Substitute.For<Player>("Black", 'B');
            IPlayer mockWhite = Substitute.For<Player>("White", 'W');
            //act
            int bows = mockBlack.getUnplaced();
            int wows = mockWhite.getUnplaced();
            //assert
            Assert.That(bows == 12);
            Assert.That(wows == 12); 
        }

        [Test]
        public void cantMovePlacedCows()
        {
            bool f = false;
            Assert.That(f = false);
        }

        /*
         * During moving,
         * ■ A cow can only move to another connected space
         * ■ A cow can only move to an empty space
         * ■ Moving does not increase or decrease the number of cows on theboard
         * 
         */

        //static object[] adjacentPlace =
        //{

        //}



        [Test]
        public void canOnlyMoveToAdjacentPlace()
        {

            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void canOnlyMoveToEmptySpace()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void numberOfCowsOnBoardDoesntChange()
        {
            bool f = false;
            Assert.That(f = false);
        }

        //During flying,
        //■ Cows can move to any empty space if only three cows of that colorremain
        [Test]
        public void canFly()
        {
            bool f = false;
            Assert.That(f = false);
        }

        /*In general,
         * ■ A mill is formed by three cows of the same color in a line
         * ■ A mill is not formed when
         *      ● Cows in a line are of different colors
         *      ● Connected spaces containing cows do not form a line
         * ■ Shooting is only possible on the turn that a mill is completed, despitethe mill persisting for another turn
         * ■ A cow in a mill, when non-mill cows exist, cannot be shot
         * ■ A cow in a mill, when all cows are in mills, can be shot
         * ■ A player cannot shoot their own cows
           ■ A player cannot shoot an empty space
           ■ Shot cows are removed from the board
           ■ A win occurs if an opponent cannot move
           ■ A win occurs if an opponent has two or fewer cows, and placement isfinished 
           */

        [Test]
        public void millsFormed()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void millNotFormed()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void onlyKillWhenMillFormed()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void cannotKillMillCows()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void canKillMIllCows()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void cantKillOwnCow()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void cannotShootEmptySpace()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void deadCowsRemoved()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void winCantMove()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void winLessThanTwoCows()
        {
            bool f = false;
            Assert.That(f = false);
        }
    }
}
