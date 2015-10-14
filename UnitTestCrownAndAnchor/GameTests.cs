using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrownAndAnchorGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CrownAndAnchorGame.Tests
{
    [TestClass()]
    public class Bug1_Tests
    {
        [TestMethod()]
        public void Three_Matched_Dice_Test()
        {

            Dice d1 = new Dice();

            DiceValue pick = d1.CurrentValue;


            Player p = new Player("Fred", 100);

            //Set all 3 dice to same value
            // Note have to comment out dice.Roll() method call in game.playround()
            Game Gamemock = new Game(d1, d1, d1);

            int bet = 5;
            int winnings = Gamemock.playRound(p, pick, bet);

            Assert.AreEqual(20, winnings);
        }

        [TestMethod()]
        public void Two_Matched_Dice_Test()
        {
            Dice d1 = new Dice();
            Dice d2 = new Dice();

            while (d1.CurrentValue == d2.CurrentValue)
            {
                d2.roll();
            }

            DiceValue pick = d1.CurrentValue;

            Player p = new Player("Fred", 100);
            Game Gamemock = new Game(d1, d2, d1);

            int bet = 5;
            int winnings = Gamemock.playRound(p, pick, bet);

            Assert.AreEqual(15, winnings);
        }

        [TestMethod()]
        public void One_Matched_Dice_Test()
        {
            Dice d1 = new Dice();
            Dice d2 = new Dice();
            Dice d3 = new Dice();

            while ((d1.CurrentValue == d2.CurrentValue) || (d2.CurrentValue == d3.CurrentValue))
            {
                d2.roll();
                d3.roll();
            }

            DiceValue pick = d1.CurrentValue;

            Player p = new Player("Fred", 100);
            Game Gamemock = new Game(d1, d2, d3);

            int bet = 5;
            int winnings = Gamemock.playRound(p, pick, bet);

            Assert.AreEqual(10, winnings);
        }

        [TestMethod()]
        public void No_Matched_Dice_Test()
        {
            Dice d1 = new Dice();
            Dice d2 = new Dice();
            Dice d3 = new Dice();
            DiceValue pick = Dice.RandomValue;

            while ((d1.CurrentValue == d2.CurrentValue) && (d2.CurrentValue == d3.CurrentValue))
            {
                d2.roll();
                d3.roll();
            }

            bool pickunique = false;

            while (pickunique == false)
            {
                pick = Dice.RandomValue;
                if (pick != d1.CurrentValue)
                {
                    if (pick != d1.CurrentValue)
                    {
                        if (pick != d1.CurrentValue)
                        {
                            if (pick != d1.CurrentValue)
                            {
                                pickunique = true;
                            }
                            else
                            {
                                pickunique = false;
                                pick = Dice.RandomValue;
                            }
                        }
                        else
                        {
                            pickunique = false;
                            pick = Dice.RandomValue;
                        }
                    }
                    else
                    {
                        pickunique = false;
                        pick = Dice.RandomValue;
                    }
                }
                else
                {
                    pickunique = false;
                    pick = Dice.RandomValue;
                }
            }


            Player p = new Player("Fred", 100);
            Game Gamemock = new Game(d1, d2, d3);

            int bet = 5;
            int winnings = Gamemock.playRound(p, pick, bet);

            Assert.AreEqual(-5, winnings);
        }
    }
}