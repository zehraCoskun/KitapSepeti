using FluentAssertions;
using TestSetup;
using WebApi.Operations.BookOperations.Commands.DeleteBook;

namespace Operations.BookOperations.Commands.Delete
{
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(null!);
            command.id=id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}