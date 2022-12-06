using FluentAssertions;
using TestSetup;
using WebApi.Operations.BookOperations.Commands.UpdateBook;

namespace Operations.BookOperations.Commands.Update
{
    public class UpdateBookCommandValidatorTests :IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("",0,0,0)]
        [InlineData("",1,1,1)]
        [InlineData("test",1,1,0)]
        [InlineData("test",1,0,1)]
        [InlineData("test",0,1,1)]
        [InlineData("t",1,1,1)]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(string title,int pageCount,int genreID,int authorID)
        {
            UpdateBookCommand command = new UpdateBookCommand(null, null);
            command.Model= new UpdateBookModel()
            {
                Title=title,PageCount=pageCount,GenreID=genreID,AuthorID=authorID,PublishDate=DateTime.Now.Date.AddYears(-1)
            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result=validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
           UpdateBookCommand command = new UpdateBookCommand(null, null);
            command.Model= new UpdateBookModel()
            {
                Title="title",PageCount=1,GenreID=1,AuthorID=1,PublishDate=DateTime.Now.Date
            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0); 
        }
    }
}