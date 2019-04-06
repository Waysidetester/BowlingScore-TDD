using Xunit;
using System.Linq;

namespace Bowling.Test
{
    public class ScoreChecker
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(4, 4, 8)]
        [InlineData(9, 0, 9)]
        [InlineData(0, 9, 9)]
        [InlineData(3, 4, 7)]
        public void Check_Single_Frame_Works(int firstBowl, int secondBowl, int expectedOutput)
        {
            var scoreEngine = new Scorer();

            var result = scoreEngine.FrameScore(firstBowl, secondBowl);

            Assert.Equal(result, expectedOutput);
        }

        [Fact]
        public void Check_Strike_Works()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(1, 3);
            scoreEngine.FrameScore(4, 3);

            var result = scoreEngine.FrameScores[0].TotalFrame;

            var expectedResult = 14;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Strike_Works_again()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(10, 0);

            var result = scoreEngine.FrameScores[0].TotalFrame;

            var expectedResult = 30;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Second_Strike_Works()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);

            var result = scoreEngine.FrameScores[1].TotalFrame;

            var expectedResult = 28;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Spare_Works()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);

            var result = scoreEngine.FrameScores[1].TotalFrame;

            var expectedResult = 20;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Spare_Works_Alt()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);

            var result = scoreEngine.FrameScores[0].TotalFrame;

            var expectedResult = 18;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Bonus_Frame_Works()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 2, 10);


            var result = scoreEngine.FrameScores[9].TotalFrame;

            var expectedResult = 20;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Bonus_Frame_Works_Alt()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(10, 10, 10);


            var result = scoreEngine.FrameScores[9].TotalFrame;

            var expectedResult = 30;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Bonus_Frame_Skips_On_No_Strike_or_Spare()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(2, 7, 4);


            var result = scoreEngine.FrameScores[9].TotalFrame;

            var expectedResult = 9;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Game_Total_Is_Correct()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(2, 7, 4);

            var r = scoreEngine.FrameScores;

            var result = scoreEngine.FrameScores.Sum(x => x.TotalFrame);

            var expectedResult = 145;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Check_Game_Total_Is_Correct_Alt()
        {
            var scoreEngine = new Scorer();

            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(3, 6);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(0, 10);
            scoreEngine.FrameScore(8, 2);
            scoreEngine.FrameScore(10, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(8, 0);
            scoreEngine.FrameScore(10, 7, 2);

            var r = scoreEngine.FrameScores;

            var result = scoreEngine.FrameScores.Sum(x => x.TotalFrame);

            var expectedResult = 139;

            Assert.Equal(expectedResult, result);
        }

    }

}
