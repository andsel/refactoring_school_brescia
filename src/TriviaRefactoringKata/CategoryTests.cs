using System;
using Xunit;

namespace Trivia
{
    class CategoryTests
    {
        //given places then is on place
        //given places then is not on place
        //given qeustions then ask manu questions
        //given questions then go out of questions
        [Fact]
        public void IsOnPlace()
        {
            var category = new Category("anything");
            category.PlaceOn(new[] { 1 });
            Assert.True(category.InOnPlace(1));
        }

        [Fact]
        public void IsNotOnPlace()
        {
            var category = new Category("anything");
            category.PlaceOn(new[] { 1 });
            Assert.False(category.InOnPlace(6));
        }

        [Fact]
        public void ProvideName()
        {
            var category = new Category("something");
            category.PlaceOn(new Int32[0]);
            Assert.Equal("something", category.Name);
        }

        [Fact]
        public void AskManyQuestions()
        {
            var category = new Category("anuthing");
            category.AddQuestion("first");
            category.AddQuestion("second");

            Assert.Equal("first", category.NextQuestion());
            Assert.Equal("second", category.NextQuestion());
        }

        [Fact]
        public void RunOutOfQuestions()
        {
            var category = new Category("anuthing");
            category.AddQuestion("first");
            category.NextQuestion();
            var ex = Record.Exception(() => category.NextQuestion());
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Contains("out of questions", ex.Message, StringComparison.CurrentCultureIgnoreCase);

        }
    }
}
