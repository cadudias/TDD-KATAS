using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    // bowling game consists of 10 frames with up to 2 tries for each frame, 
    //except for the last frame when you can roll 3 times if the first roll was a strike or the second was a spare
    public class BowlingGame
    {
        public bool hasSpare = false;

        public int Score
        {
            get;
            set;
        }

        public bool HasSpare
        {
            get { return hasSpare; }
        }

        public void RollFrames(int roll1, int roll2, int totalFrames)
        {
            for (int frame = 0; frame < totalFrames; frame++)
            {
                Score += roll1 + roll2;
            }

            if (HasSpare)
            {
                Score += roll1;
            }
        }

        public void RollSpare(int roll1, int roll2)
        {
            Score += roll1 + roll2;
            hasSpare = true;
        }
    }
}
