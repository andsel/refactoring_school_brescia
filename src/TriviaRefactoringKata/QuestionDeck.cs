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

        public String CategoryForPlace(int playerPlace)
        {
            if (popPlaces.Contains(playerPlace)) return "Pop";
            if (sciencePlaces.Contains(playerPlace)) return "Science";
            if (sportPlaces.Contains(playerPlace)) return "Sports";
            if (rockPlaces.Contains(playerPlace)) return "Rock";

            throw new InvalidOperationException("out of board");
        }

        public String AskQuestionCategory(String category)
        {
            LinkedList<String> categoryQuestions = null;
            if (category == "Pop") categoryQuestions = popQuestions;
            if (category == "Science") categoryQuestions = scienceQuestions;
            if (category == "Sports") categoryQuestions = sportsQuestions;
            if (category == "Rock") categoryQuestions = rockQuestions;
            if (categoryQuestions == null)
                throw new InvalidOperationException($"Missing category {category}");
            
            return NextQuestion(categoryQuestions);
        }

        private string NextQuestion(LinkedList<string> questions)
        {
            var result = questions.First();
            questions.RemoveFirst();
            return result;
        }
    }
}