using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_KATAS;

namespace Tests_TDD_KATAS
{
    [TestFixture]
    public class BowlingTest
    {
        BowlingGame game;

        [SetUp]
        public void SetUp()
        {
            game = new BowlingGame();
        }

        [Test]
        public void TestAllGutterBalls()
        {
            RollMany(20, 0);

            Assert.AreEqual(0, game.Score());
        }

        [Test]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.AreEqual(20, game.Score());
        }

        [Test]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(2);
            RollMany(17, 0);

            Assert.AreEqual(14, game.Score());
        }

        [Test]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(2);
            game.Roll(3);
            RollMany(17, 0);

            Assert.AreEqual(20, game.Score());
        }

        [Test]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
