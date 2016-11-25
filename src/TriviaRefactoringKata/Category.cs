using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Category
    {
        private readonly LinkedList<String> questions;
        private String name;
        private readonly int[] places;

        public Category(string name, int[] places)
        {
            this.name = name;
            this.places = places;
            this.questions = new LinkedList<String>();
        }

        public String Name { get; private set; }

        public void AddQuestion(String question)
        {
            this.questions.AddLast(question);
        }

        public bool Contains(int playerPlace)
        {
            return places.Contains(playerPlace);
        }

        public String NextQuestion()
        {
            var result = questions.First();
            questions.RemoveFirst();
            return result;
        }
    }
}