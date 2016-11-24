using System;
using System.Collections.Generic;
using System.Linq;
using UglyTrivia;

namespace Trivia
{
    public class QuestionDeck
    {
        private readonly Game game;
        private readonly LinkedList<string> popQuestions;
        private readonly LinkedList<string> scienceQuestions;
        private readonly LinkedList<string> sportsQuestions;
        private readonly LinkedList<string> rockQuestions;

        public QuestionDeck(Game game)
        {
            this.game = game;
            popQuestions = game.PopQuestions;
            scienceQuestions = game.ScienceQuestions;
            sportsQuestions = game.SportsQuestions;
            rockQuestions = game.RockQuestions;
        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void FillQuestions()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(this.createRockQuestion(i));
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
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (category == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (category == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (category == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }
    }
}