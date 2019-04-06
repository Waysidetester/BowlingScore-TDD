using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class Frame
    {
        public int FirstFrame { get; }
        public int SecondFrame { get; }
        public int BonusFrame { get; set; }
        public int TotalFrame { get; set; }

        public Frame(int firstFrame, int secondFrame)
        {
            FirstFrame = firstFrame;
            SecondFrame = secondFrame;
            TotalFrame = FirstFrame + SecondFrame;
        }
    }
}
