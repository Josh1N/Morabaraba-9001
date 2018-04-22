using System;
using System.Linq;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

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

            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void blackPlayerStarts()
        {
            bool f = false;
            Assert.That(f = false);
        }


        [Test]
        public void cowPlacementOnEmptySpace()
        {
            bool f = false;
            Assert.That(f = false);
        }

        [Test]
        public void twelveCowsPerPlayer()
        {
            bool f = false;
            Assert.That(f = false);
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

        static object[] adjacentPlace =
        {
             bool f = false;
        Assert.That(f = false);
        };



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
