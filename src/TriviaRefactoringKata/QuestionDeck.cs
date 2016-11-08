﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly LinkedList<String> popQuestions;
        readonly LinkedList<String> scienceQuestions;
        readonly LinkedList<String> sportsQuestions;
        readonly LinkedList<String> rockQuestions;

        public QuestionDeck()
        {
            popQuestions = new LinkedList<string>();
            scienceQuestions = new LinkedList<string>();
            sportsQuestions = new LinkedList<string>();
            rockQuestions = new LinkedList<string>();
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

        public String CurrentCategoryPlace(Int32 currentPlace)
        {
            if (currentPlace == 0) return "Pop";
            if (currentPlace == 4) return "Pop";
            if (currentPlace == 8) return "Pop";
            if (currentPlace == 1) return "Science";
            if (currentPlace == 5) return "Science";
            if (currentPlace == 9) return "Science";
            if (currentPlace == 2) return "Sports";
            if (currentPlace == 6) return "Sports";
            if (currentPlace == 10) return "Sports";
            if (currentPlace == 3) return "Rock";
            if (currentPlace == 7) return "Rock";
            if (currentPlace == 11) return "Rock";
            return "Rock";
        }

        public String AskCategoryQuestion(String category)
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
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (category == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
            return "";
        }
    }
}