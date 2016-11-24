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
        public void CurrentCategoryPlaceTest(int currentPlayerPlace, string expected)
        {
            var deck = new QuestionDeck();
            var category = deck.CurrentCategoryPlace(currentPlayerPlace);
            Assert.Equal(expected, category);
        }
    }
}