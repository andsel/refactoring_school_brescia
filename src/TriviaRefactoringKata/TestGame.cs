using System;
using System.IO;
using Trivia;
using Xunit;

namespace UglyTrivia
{
    public class GoldenMasterTests
    {
        [Fact]
        public void TriviaGameTest()
        {
            RunGame();
            //var actual = ReadLastOutput();
            //var expected = ReadGoldenMaster();

            //Assert.Equal(expected, actual);

            //var stdOut = File.CreateText("output.txt");
            //Console.SetOut(stdOut);
            //GameRunner.Run(new Random(10));

            //Assert.Equal("", stdOut.ToString());
        }

        private void RunGame()
        {
            using (var stdout = File.CreateText("actual.txt"))
            {
                Console.SetOut(stdout);
                for (int i = 0; i < 1000; i++)
                {
                    var seed = 765456 + 42 * i;
                    GameRunner.Run(new Random(seed));
                }
            }
        }
    }
}