using System;
using System.Linq;
using UglyTrivia;

namespace Trivia
{
    public class QuestionDeck
    {
        private readonly Game game;

        public QuestionDeck(Game game)
        {
            this.game = game;
        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void FillQuestions()
        {
            for (int i = 0; i < 50; i++)
            {
                this.game.PopQuestions.AddLast("Pop Question " + i);
                this.game.ScienceQuestions.AddLast(("Science Question " + i));
                this.game.SportsQuestions.AddLast(("Sports Question " + i));
                this.game.RockQuestions.AddLast(this.createRockQuestion(i));
            }
        }

        public String CurrentCategoryPlace(int currentPlayerPlace)
        {
            if (currentPlayerPlace == 0) return "Pop";
            if (currentPlayerPlace == 4) return "Pop";
            if (currentPlayerPlace == 8) return "Pop";
            if (currentPlayerPlace == 1) return "Science";
            if (currentPlayerPlace == 5) return "Science";
            if (currentPlayerPlace == 9) return "Science";
            if (currentPlayerPlace == 2) return "Sports";
            if (currentPlayerPlace == 6) return "Sports";
            if (currentPlayerPlace == 10) return "Sports";
            return "Rock";
        }

        public void AskQuestionCategory(String category)
        {
            if (category == "Pop")
            {
                Console.WriteLine(game.PopQuestions.First());
                game.PopQuestions.RemoveFirst();
            }
            if (category == "Science")
            {
                Console.WriteLine(game.ScienceQuestions.First());
                game.ScienceQuestions.RemoveFirst();
            }
            if (category == "Sports")
            {
                Console.WriteLine(game.SportsQuestions.First());
                game.SportsQuestions.RemoveFirst();
            }
            if (category == "Rock")
            {
                Console.WriteLine(game.RockQuestions.First());
                game.RockQuestions.RemoveFirst();
            }
        }
    }
}