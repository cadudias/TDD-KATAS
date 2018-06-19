using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    // bowling game consists of 10 frames with up to 2 tries for each frame, 
    //except for the last frame when you can roll 3 times if the first roll was a strike or the second was a spare

    // in case of a spare, 2 rolls hitting all 10 pins, add bonus equal to the total pins on the next roll
    public class BowlingGame
    {
        private readonly int[] rolls = new int[21];
        private int currentRoll = 0;
        
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public double Score()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll++; // no caso de strike incrementa só uma jogada já que no strike só fazemos uma jogada no frame
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2; // no caso do spare incrementa duas rodadas já que foram jogadas duas bolas no mesmo frame
                }
                else
                {
                    score += SumRollsInFrame(roll);
                    roll += 2; // no caso da jogada normal incrementa duas rodadas já que foram jogadas duas bolas no mesmo frame
                }
            }

            return score;
        }

        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }

        private int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }

        private int SumRollsInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }
    }
}
