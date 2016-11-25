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

        String CreateQuestion(String category, int index)
        {
            return category + " Question " + index;
        }

        public void FillQuestions()
        {
            Category pop = new Category("Pop");
            pop.PlaceOn(new[] { 0, 4, 6 });
            categories.Add(pop);

            Category science = new Category("Science");
            science.PlaceOn(new[] { 1, 5, 9 });
            categories.Add(science);

            Category sports = new Category("Sports");
            sports.PlaceOn(new[] { 2, 6, 10 });
            categories.Add(sports);

            Category rock = new Category("Rock");
            rock.PlaceOn(new[] { 3, 7, 11 });
            categories.Add(rock);

            for (int i = 0; i < 50; i++)
            {
                foreach (var category in categories)
                {
                    category.AddQuestion(CreateQuestion(category.Name, i));
                }
            }
        }

        public void PlaceOn(String categoryName, int[] place)
        {
            var cat = GetOrAdd(categoryName);
            cat.PlaceOn(place);
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