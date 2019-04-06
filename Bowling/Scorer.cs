using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bowling
{
    public class Scorer
    {
        public Frame[] FrameScores { get; set; }
        int iterator = 0;

        public Scorer()
        {
            FrameScores = new Frame[10];
        }

        public int FisrtTurn(int pinsKnocked)
        {
            return pinsKnocked;
        }

        public int SecondTurn(int currentPinsKnocked, int newPinsKnocked)
        {
            if(10 >= (newPinsKnocked+currentPinsKnocked) || iterator == 9)
            {
                return newPinsKnocked;
            }
            else
            {
                throw new Exception();
            }
        }

        public int FrameScore(int firstFrame, int secondFrame)
        {
            var x = FisrtTurn(firstFrame);
            var y = SecondTurn(x, secondFrame);

            var currentFrame = new Frame(x, y);
            var result = x+y;

            FrameScores[iterator] = currentFrame;

            CheckPrevFrames(currentFrame);
            return result;
        }

        public void CheckPrevFrames(Frame frameScore)
        {
            if(iterator > 0)
            {
                if(FrameScores[iterator-1].TotalFrame == 10)
                {
                    FrameScores[iterator - 1].TotalFrame = FrameScores[iterator - 1].TotalFrame + frameScore.FirstFrame;
                    if(FrameScores[iterator - 1].FirstFrame == 10
                        && FrameScores[iterator - 1].TotalFrame < 20)
                    {
                        FrameScores[iterator - 1].TotalFrame = FrameScores[iterator - 1].TotalFrame + frameScore.SecondFrame;
                    }
                }
            }

            if(iterator > 1)
            {
                if(FrameScores[iterator-2].TotalFrame == 20 && FrameScores[iterator - 2].FirstFrame == 10)
                {
                    FrameScores[iterator - 2].TotalFrame = FrameScores[iterator - 2].TotalFrame + frameScore.FirstFrame;
                }
            }
            iterator++;
        }


        public int FrameScore(int firstFrame, int secondFrame, int thirdFrame)
        {
            var x = FisrtTurn(firstFrame);
            var y = SecondTurn(x, secondFrame);

            var currentFrame = new Frame(x, y);
            var result = x + y;

            if(currentFrame.TotalFrame >= 10)
            {
                currentFrame.TotalFrame = currentFrame.TotalFrame + thirdFrame;
            }

            FrameScores[iterator] = currentFrame;

            CheckPrevFrames(currentFrame);
            return result;
        }
    }
}
