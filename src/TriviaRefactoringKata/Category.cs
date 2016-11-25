using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Category
    {
        private readonly LinkedList<String> questions;
        private readonly  String name;
        private readonly List<int> categoryPlaces;

        public Category(string name)
        {
            this.name = name;
            this.questions = new LinkedList<String>();
            categoryPlaces = new List<int>();
        }

        public String Name { get; private set; }

        public void AddQuestion(String question)
        {
            this.questions.AddLast(question);
        }

        public bool InOnPlace(int playerPlace)
        {
            return categoryPlaces.Contains(playerPlace);
        }

        public String NextQuestion()
        {
            if (questions.Count == 0)
                throw new InvalidOperationException("out of questions");
            var result = questions.First();
            questions.RemoveFirst();
            return result;
        }

        public void PlaceOn(int[] places)
        {
            categoryPlaces.AddRange(places);
        }
    }
}