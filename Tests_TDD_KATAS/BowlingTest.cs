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
        public void ShouldReturn0PointsIfAllGutterBalls()
        {
            game.RollFrames(0, 0, 10);
            Assert.AreEqual(0, game.Score);
        }

        [Test]
        public void ShouldReturn40PointsIfAll2s()
        {
            game.RollFrames(2, 2, 10);
            Assert.AreEqual(40, game.Score);
        }

        //In bowling, you score a spare by knocking down all remaining pins during your second roll of a frame. To score it, you get 10 points, plus whatever your next roll is.
        [Test]
        public void FirstFrameSpareRest2sShouldScore48()
        {
            game.RollSpare(2, 8); // spare
            game.RollFrames(2, 2, 9);
            Assert.AreEqual(48, game.Score);
            //Why 48? Well, because our first frame is a spare, and the first roll of the next frame is a 2, the score for frame 1 is 12. We then add that to the remaining 9 frames which are each 4 points (2 for each roll).
        }

        [Test]
        public void TwoFrameSpareRest2sShouldScore48()
        {
            game.RollSpare(2, 8); // spare
            game.RollSpare(3, 7); // spare
            game.RollFrames(2, 2, 8);
            Assert.AreEqual(54, game.Score);
            //Why 48? Well, because our first frame is a spare, and the first roll of the next frame is a 2, the score for frame 1 is 12. We then add that to the remaining 9 frames which are each 4 points (2 for each roll).
        }
    }
}
