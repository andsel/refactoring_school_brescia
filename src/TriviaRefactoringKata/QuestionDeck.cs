using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        private readonly Category pop;
        private Category science;
        private Category sports;
        private Category rock;

        public QuestionDeck()
        {
            pop = new Category("Pop", new[] { 0, 4, 6 });
            science = new Category("Science", new[] { 1, 5, 9 });
            sports = new Category("Sports", new[] { 2, 6, 10 });
            rock = new Category("Rock", new[] { 3, 7, 11 });
        }

        String CreateQuestion(String category, int index)
        {
            return category + " Question " + index;
        }

        public void FillQuestions()
        {
            for (int i = 0; i < 50; i++)
            {
                pop.AddQuestion(CreateQuestion(pop.Name, i));
                science.AddQuestion(CreateQuestion(science.Name, i));
                sports.AddQuestion(CreateQuestion(sports.Name, i));
                rock.AddQuestion(CreateQuestion(rock.Name, i));
            }
        }

        public String CategoryForPlace(int playerPlace)
        {
            if (pop.Contains(playerPlace)) return pop.Name;
            if (science.Contains(playerPlace)) return science.Name;
            if (sports.Contains(playerPlace)) return sports.Name;
            if (rock.Contains(playerPlace)) return rock.Name;

            throw new InvalidOperationException("out of board");
        }

        public String AskQuestionCategory(String category)
        {
            if (pop.Name == category) return pop.NextQuestion();
            if (science.Name == category) return science.NextQuestion();
            if (sports.Name == category) return sports.NextQuestion();
            if (rock.Name == category) return rock.NextQuestion();

            throw new InvalidOperationException($"Missing category {category}");
        }
    }
}