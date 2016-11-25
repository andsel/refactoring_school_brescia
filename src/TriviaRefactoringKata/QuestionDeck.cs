using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        
        private readonly List<Category> categories;

        public QuestionDeck()
        {
            Category pop = new Category("Pop", new[] { 0, 4, 6 });
            Category science = new Category("Science", new[] { 1, 5, 9 });
            Category sports = new Category("Sports", new[] { 2, 6, 10 });
            Category rock = new Category("Rock", new[] { 3, 7, 11 });
            categories = new List<Category> {pop, science, sports, rock};
        }

        String CreateQuestion(String category, int index)
        {
            return category + " Question " + index;
        }

        public void FillQuestions()
        {
            for (int i = 0; i < 50; i++)
            {
                foreach (var catergory in categories)
                {
                    catergory.AddQuestion(CreateQuestion(catergory.Name, i));
                }
            }
        }

        public String CategoryForPlace(int playerPlace)
        {
            var found = categories.SingleOrDefault(x => x.Contains(playerPlace));
            if (found == null)
                throw new InvalidOperationException("out of board");
            return found.Name;
        }

        public String AskQuestionCategory(String category)
        {
            var found = categories.SingleOrDefault(x => x.Name == category);
            if (found == null)
                throw new InvalidOperationException($"Missing category {category}");
            return found.Name;
        }
    }
}