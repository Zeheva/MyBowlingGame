﻿using Xunit;


namespace BowlingGame.Tests
{
    public class GameTests
    {
         Game g;

        public GameTests()
        {
                g = new Game();
        }

        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, g.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
           RollMany(20,1);
            Assert.Equal(20, g.Score());
        }
        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, g.Score());
        }


        [Fact]
        public void TestPerfectGame()
        {
           
            RollMany(12, 10);
            Assert.Equal(300, g.Score());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.Score());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }

    }
}