using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            Random rand = new Random();
            Run(rand);
        }

        internal static void Run(Random rand)
        {
            Game aGame = new Game();
            AddFiftyQuestions(aGame, "Pop", new[] { 0, 4, 8 });
            AddFiftyQuestions(aGame, "History", new[] { 1, 5, 9 });
            AddFiftyQuestions(aGame, "Sports", new[] { 2, 6, 10 });
            AddFiftyQuestions(aGame, "Rock", new[] { 3, 7, 11 });

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");


            do
            {
                aGame.roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }
            } while (notAWinner);
        }


        static void AddFiftyQuestions(Game game, String categoryName, int[] categoryPlaces)
        {
            game.PlaceCategory(categoryName, categoryPlaces);
            for (int i = 0; i < 50; i++)
                game.AddCategoryQuestion(categoryName, categoryName + " Question " + i);
        }
    }

}