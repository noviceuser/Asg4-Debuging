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
    public class PlayerTests
    {
        Player p1 = new Player("Fred", 100);
        Player p2 = new Player("Fred", 1000);

        [TestMethod()]
        public void balanceExceedsLimitTestUnder()
        {
            p1.Limit = 99;
            Assert.IsTrue(p1.balanceExceedsLimit());
        }

        [TestMethod()]
        public void balanceExceedsLimitTestEqual()
        {
            p1.Limit = 100;
            Assert.IsFalse(p1.balanceExceedsLimit());
        }

        [TestMethod()]
        public void balanceExceedsLimitByTestDecreaseby1()
        {
            p1.Limit = 100;
            Assert.IsFalse(p1.balanceExceedsLimitBy(1));
        }

        [TestMethod()]
        public void balanceExceedsLimitByTestIncreaseby1()
        {
            p1.Limit = 100;
            Assert.IsTrue(p1.balanceExceedsLimitBy(-1));
        }
    }
}