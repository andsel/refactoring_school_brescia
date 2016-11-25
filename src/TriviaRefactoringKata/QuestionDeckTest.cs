using System;
using Xunit;
using Xunit.Extensions;

namespace Trivia
{
    public class QuestionDeckTest
    {
        [Fact]
        public void IsCategoryOnPlace()
        {
            var deck = new QuestionDeck();
            deck.FillQuestions();
            deck.PlaceOn("Foo", new int[] {0, 1});
            Assert.Equal("Foo", deck.CategoryForPlace(0));
            Assert.Equal("Foo", deck.CategoryForPlace(1));
        }

        [Fact]
        public void NoCategoryOnPlace()
        {
            var deck = new QuestionDeck();
            deck.PlaceOn("Foo", new []{1, 2, 3});

            var ex = Record.Exception(() => deck.CategoryForPlace(42));
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Contains("out of board", ex.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Theory]
        [InlineData("Pop")]
        [InlineData("Science")]
        public void FirstQuestion_(String category)
        {
            var deck = new QuestionDeck();
            deck.FillQuestions();
            var question = deck.AskQuestionCategory(category);
            Assert.Equal(category + "Question 0", question);
        }

        [Fact]
        public void AskQuestionForDifferentCategory()
        {
            var deck = new QuestionDeck();
            deck.AddQuestion("bar", "first");
            deck.AddQuestion("yo", "one");

            Assert.Equal("one", deck.AskQuestionCategory("yo"));
            Assert.Equal("first", deck.AskQuestionCategory("bar"));
        }

        [Fact]
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

        [Fact]
        public void AskQuestionUnknownCategoryTest()
        {
            var deck = new QuestionDeck();

            var ex = Record.Exception(() => deck.AskQuestionCategory("Unknown"));
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Contains("Missing category", ex.Message, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}