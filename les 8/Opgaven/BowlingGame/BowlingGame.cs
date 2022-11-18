using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameScore
{
    public class BowlingGame
    {
        private int[] pins = new int[21];  // het aantal omgeworpen kegels per worp (maximaal 21 worpen laatste frame een spare + 1 of strike + 2;
        private int currentRoll = 0;       // teller van het aantal worpen die de gebruiker heeft gedaan

        public int Score
        {
            get
            {
                int score = 0;
                int rollIndex = 0;
                for (int frame = 0; frame < 10; frame++) // loop over het aantal worpen
                {

                    if (isStrike(rollIndex))
                    {
                        score += pins[rollIndex] + pins[rollIndex + 1] + pins[rollIndex + 2];
                        rollIndex++;
                    }
                    else if (isSpare(rollIndex))
                    {
                        score += getSpareScore(rollIndex);
                        rollIndex += 2;
                    }
                    else
                    {
                        score += GetStandardScore(rollIndex);
                        rollIndex += 2;
                    }
                }

                return score;
            }
        }

        private bool isStrike(int rollIndex)
        {
            return pins[rollIndex] == 10;
        }

        private int getSpareScore(int rollIndex)
        {
            return pins[rollIndex] + pins[rollIndex + 1] + pins[rollIndex + 2];
        }

        private bool isSpare(int rollIndex)
        {
            return pins[rollIndex] + pins[rollIndex + 1] == 10;
        }

        private int GetStandardScore(int rollIndex)
        {
            return pins[rollIndex] + pins[rollIndex + 1];
        }

        public void Roll(int pinsThisRoll)
        {
            pins[currentRoll++] = pinsThisRoll;
        }
    }
}
