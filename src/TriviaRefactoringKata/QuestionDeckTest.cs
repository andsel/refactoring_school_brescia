using System;
using Xunit;
using Xunit.Extensions;

namespace Trivia
{
    public class QuestionDeckTest
    {
        [Theory]
        [InlineData(0, "Pop")]
        [InlineData(4, "Pop")]
        [InlineData(8, "Pop")]
        [InlineData(1, "Science")]
        [InlineData(5, "Science")]
        [InlineData(9, "Science")]
        [InlineData(2, "Sports")]
        [InlineData(6, "Sports")]
        [InlineData(10, "Sports")]
        [InlineData(3, "Rock")]
        [InlineData(7, "Rock")]
        [InlineData(11, "Rock")]
        public void CurrentCategoryPlaceTest(int currentPlayerPlace, String expected)
        {
            var deck = new QuestionDeck();
            var category = deck.CurrentCategoryPlace(currentPlayerPlace);
            Assert.Equal(expected, category);
        }

        [Theory]
        [InlineData(-1, "Rock")]
        [InlineData(12, "Rock")]
        [InlineData(1234, "Rock")]
        public void OutOfBoardTest(int currentPlayerPlace, String expected)
        {
            var deck = new QuestionDeck();
            var category = deck.CurrentCategoryPlace(currentPlayerPlace);
            Assert.Equal(expected, category);
        }

        [Theory]
        [InlineData("Pop")]
        public void AskQuestionCategory(String category)
        {
            var deck = new QuestionDeck();
            deck.FillQuestions();
            var question = deck.AskQuestionCategory(category);
            Assert.Equal(category + "Question 0", question);
        }

        [Theory]
        public void ManyAskQuestionCategoryTest()
        {
            var category = "Rock";
            var deck = new QuestionDeck();
            deck.FillQuestions();
            Assert.Equal(category + "Question 0", deck.AskQuestionCategory(category));
            Assert.Equal(category + "Question 1", deck.AskQuestionCategory(category));
            Assert.Equal(category + "Question 2", deck.AskQuestionCategory(category));
            Assert.Equal(category + "Question 3", deck.AskQuestionCategory(category));
        }
    }
}