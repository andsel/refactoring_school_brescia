using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        private readonly LinkedList<string> popQuestions;
        private readonly LinkedList<string> scienceQuestions;
        private readonly LinkedList<string> sportsQuestions;
        private readonly LinkedList<string> rockQuestions;

        public QuestionDeck()
        {
            popQuestions = new LinkedList<string>();
            scienceQuestions = new LinkedList<string>();
            sportsQuestions = new LinkedList<string>();
            rockQuestions = new LinkedList<string>();
        }

        private String createRockQuestion(int index)
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
            if (currentPlayerPlace == 3) return "Sports";
            if (currentPlayerPlace == 7) return "Sports";
            if (currentPlayerPlace == 11) return "Sports";
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
            return null;
        }
    }
}