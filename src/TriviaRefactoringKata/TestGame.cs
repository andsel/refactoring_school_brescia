using System;
using System.IO;
using Trivia;
using Xunit;

namespace UglyTrivia
{
    public class GoldenMasterTests
    {
        [Fact]
        public void MainTest()
        {
            var stdOut = File.CreateText("output.txt");
            Console.SetOut(stdOut);
            var game = new TestableGameRunner(10);
            game.Run();

            //Assert.Equal("", stdOut.ToString());
        }
    }

    public class TestableGameRunner : GameRunner
    {
        private readonly int seed;

        public TestableGameRunner(Int32 seed)
        {
            this.seed = seed;
        }

        protected override Random createRandom()
        {
            return new Random(10);
        }
    }
}