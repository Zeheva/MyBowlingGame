using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class Game
    {
       
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        public void Roll(int pins)
        {
        
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
                if (IsStrike(frameIndex)) 
                {
                    score += StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }

            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsSpare(int FrameIndex)
        {
            return rolls[FrameIndex] + rolls[FrameIndex + 1] == 10;
        }
    }
}