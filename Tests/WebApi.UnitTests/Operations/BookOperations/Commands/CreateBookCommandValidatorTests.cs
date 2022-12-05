using FluentAssertions;
using TestSetup;
using WebApi.Operations.BookOperations.Commands.CreateBook;

namespace Operations.BookOperations.Commands
{
    public class CreateBookCommandValidatorTests :IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("",0,0,0)]
        [InlineData("",1,1,1)]
        [InlineData("a",1,1,1)]
        [InlineData("title",0,1,1)]
        [InlineData("title",1,0,1)]
        [InlineData("title",1,1,0)]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title=title,
                PageCount=pageCount,
                GenreID=genreId,
                AuthorID=authorId,
                PublishDate=DateTime.Now.Date.AddYears(-1)
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title="Title",
                PageCount=1,
                GenreID=1,
                AuthorID=1,
                PublishDate=DateTime.Now.Date
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title="Title",
                PageCount=1,
                GenreID=1,
                AuthorID=1,
                PublishDate=DateTime.Now.Date.AddYears(-2)
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
        

    }
}