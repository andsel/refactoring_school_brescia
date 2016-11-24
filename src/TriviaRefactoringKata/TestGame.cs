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
            GameRunner.Run(new Random(10));

            //Assert.Equal("", stdOut.ToString());
        }
    }
}