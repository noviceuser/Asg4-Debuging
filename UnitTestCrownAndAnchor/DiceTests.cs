using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrownAndAnchorGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownAndAnchorGame.Tests
{
    [TestClass()]
    public class DiceTests
    {
        [TestMethod()]
        public void rollTestANCHOR()
        {
            Dice d1 = new Dice();
            while (DiceValue.ANCHOR != d1.CurrentValue)
            {
                d1.roll();
            }

            Assert.AreEqual(DiceValue.ANCHOR, d1.CurrentValue);
        }
        [TestMethod()]
        public void rollTestCLUB()
        {
            Dice d1 = new Dice();
            while (DiceValue.CLUB != d1.CurrentValue)
            {
                d1.roll();
            }

            Assert.AreEqual(DiceValue.CLUB, d1.CurrentValue);
        }
        [TestMethod()]
        public void rollTestCROWN()
        {
            Dice d1 = new Dice();
            while (DiceValue.CROWN != d1.CurrentValue)
            {
                d1.roll();
            }

            Assert.AreEqual(DiceValue.CROWN, d1.CurrentValue);
        }
        [TestMethod()]
        public void rollTestDIAMOND()
        {
            Dice d1 = new Dice();
            while (DiceValue.DIAMOND != d1.CurrentValue)
            {
                d1.roll();
            }

            Assert.AreEqual(DiceValue.DIAMOND, d1.CurrentValue);
        }
        [TestMethod()]
        public void rollTestHEART()
        {
            Dice d1 = new Dice();
            while (DiceValue.HEART != d1.CurrentValue)
            {
                d1.roll();
            }

            Assert.AreEqual(DiceValue.HEART, d1.CurrentValue);
        }
        [TestMethod()]
        public void rollTestSPADE()
        {
            Dice d1 = new Dice();
            while (DiceValue.SPADE != d1.CurrentValue)
            {
                d1.roll();
            }

            Assert.AreEqual(DiceValue.SPADE, d1.CurrentValue);
        }
    }
}