using System;
using System.IO;
using Trivia;
using Xunit;

namespace UglyTrivia
{
    public class GoldenMasterTests
    {
        private static readonly string ACTUAL_FILENAME = "actual.txt";
        private static readonly string GOLDEN_MASTER = "../../golden_master.txt";

        [Fact]
        public void TriviaGameTest()
        {
            RunGame();
            var actual = ReadLastOutput();
            var expected = ReadGoldenMaster();

            Assert.Equal(expected, actual);
        }

        private String ReadLastOutput()
        {
            return File.ReadAllText(ACTUAL_FILENAME);
        }

        private String ReadGoldenMaster()
        {
            
            return File.ReadAllText(GOLDEN_MASTER);
        }

        private void RunGame()
        {
            using (var stdout = File.CreateText(ACTUAL_FILENAME))
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