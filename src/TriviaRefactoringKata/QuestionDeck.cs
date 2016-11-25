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
            categories = new List<Category>();
        }

        public void PlaceOn(String categoryName, int[] place)
        {
            GetOrAdd(categoryName).PlaceOn(place);
        }

        public void AddQuestion(String categoryName, String question)
        {
            var cat = new Category(categoryName);
            categories.Add(cat);
            cat.AddQuestion(question);
        }

        private Category GetOrAdd(String categoryName)
        {
            var found = categories.SingleOrDefault(x => x.Name == categoryName);
            if (found != null)
            {
                return found;
            }
            var cat = new Category(categoryName);
            categories.Add(cat);
            return cat;
        }

        public String CategoryForPlace(int playerPlace)
        {
            var found = categories.SingleOrDefault(x => x.InOnPlace(playerPlace));
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