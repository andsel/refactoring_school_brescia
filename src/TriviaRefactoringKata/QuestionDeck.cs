﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly List<CategoryQuestions> categories;

        public QuestionDeck()
        {
            categories = new List<CategoryQuestions>();
        }

        static String CreateSimpleQuestion(String categoryName, Int32 index)
        {
            return categoryName + " Question " + index;
        }

        void AddSimpleQuestions(String categoryName)
        {
            for (var i = 0; i < 50; i++) AddQuestion(categoryName, CreateSimpleQuestion(categoryName, i));
        }

        void PlaceSimpleQuestions(String categoryName, Int32[] places)
        {
            PlaceOn(categoryName, places);
            AddSimpleQuestions(categoryName);
        }

        public void FillQuestions()
        {
            PlaceSimpleQuestions("Pop", new[] { 0, 4, 8 });

            var science = FindOrAddCategoryQuestions("Science");
            science.PlacedOn(new[] { 1, 5, 9 });
            for (var i = 0; i < 50; i++) science.AddQuestion(CreateSimpleQuestion(science.Name, i));

            var sports = FindOrAddCategoryQuestions("Sports");
            sports.PlacedOn(new[] { 2, 6, 10 });
            for (var i = 0; i < 50; i++) sports.AddQuestion(CreateSimpleQuestion(sports.Name, i));

            var rock = FindOrAddCategoryQuestions("Rock");
            rock.PlacedOn(new[] { 3, 7, 11 });
            for (var i = 0; i < 50; i++) rock.AddQuestion(CreateSimpleQuestion(rock.Name, i));
        }

        public void PlaceOn(String categoryName, Int32[] places)
        {
            var categoryQuestions = FindOrAddCategoryQuestions(categoryName);
            categoryQuestions.PlacedOn(places);
        }

        public String CategoryForPlace(Int32 place)
        {
            var found = categories.SingleOrDefault(x => x.IsPlacedOn(place));
            if (found == null) throw new InvalidOperationException($"No category on place {place}.");
            return found.Name;
        }

        public void AddQuestion(String categoryName, String question)
        {
            var categoryQuestions = FindOrAddCategoryQuestions(categoryName);
            categoryQuestions.AddQuestion(question);
        }

        public String AskCategoryQuestion(String category)
        {
            var found = FindCategoryQuestions(category);
            if (found == null) throw new InvalidOperationException($"Missing category {category}");
            return found.NextQuestion();
        }

        CategoryQuestions FindCategoryQuestions(String category)
        {
            return categories.SingleOrDefault(x => x.Name == category);
        }

        CategoryQuestions FindOrAddCategoryQuestions(String categoryName)
        {
            var categoryQuestions = FindCategoryQuestions(categoryName);
            return categoryQuestions ?? AddCategoryQuestions(categoryName);
        }

        CategoryQuestions AddCategoryQuestions(String categoryName)
        {
            var categoryQuestions = new CategoryQuestions(categoryName);
            categories.Add(categoryQuestions);
            return categoryQuestions;
        }
    }
}