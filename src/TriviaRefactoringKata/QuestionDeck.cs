using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        private readonly LinkedList<string> popQuestions;
        private readonly int[] popPlaces;

        private readonly LinkedList<string> scienceQuestions;
        private readonly int[] sciencePlaces;

        private readonly LinkedList<string> sportsQuestions;
        private readonly int[] sportPlaces;

        private readonly LinkedList<string> rockQuestions;
        private readonly int[] rockPlaces;

        public QuestionDeck()
        {
            popQuestions = new LinkedList<string>();
            scienceQuestions = new LinkedList<string>();
            sportsQuestions = new LinkedList<string>();
            rockQuestions = new LinkedList<string>();
            popPlaces = new[] {0, 4, 6};
            sciencePlaces = new[] { 1, 5, 9 };
            sportPlaces = new[] { 2, 6, 10 };
            rockPlaces = new[] { 3, 7, 11 };
        }

        String CreateQuestion(String category, int index)
        {
            return category + " Question " + index;
        }

        public void FillQuestions()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast(CreateQuestion("Pop", i));
                scienceQuestions.AddLast(CreateQuestion("Science", i));
                sportsQuestions.AddLast(CreateQuestion("Sports", i));
                rockQuestions.AddLast(CreateQuestion("Rock", i));
            }
        }

        public String CurrentCategoryPlace(int currentPlayerPlace)
        {
            if (popPlaces.Contains(currentPlayerPlace)) return "Pop";
            if (sciencePlaces.Contains(currentPlayerPlace)) return "Science";
            if (sportPlaces.Contains(currentPlayerPlace)) return "Sports";
            if (rockPlaces.Contains(currentPlayerPlace)) return "Rock";

            throw new InvalidOperationException("out of board");
        }

        public String AskQuestionCategory(String category)
        {
            if (category == "Pop")
            {
                var question = popQuestions.First();
                Console.WriteLine(question);
                popQuestions.RemoveFirst();
                return question;
            }
            if (category == "Science")
            {
                var question = scienceQuestions.First();
                Console.WriteLine(question);
                scienceQuestions.RemoveFirst();
                return question;
            }
            if (category == "Sports")
            {
                var question = sportsQuestions.First();
                Console.WriteLine(question);
                sportsQuestions.RemoveFirst();
                return question;
            }
            if (category == "Rock")
            {
                var question = rockQuestions.First();
                Console.WriteLine(question);
                rockQuestions.RemoveFirst();
                return question;
            }
            throw new InvalidOperationException($"Missing category {category}");
        }
    }
}