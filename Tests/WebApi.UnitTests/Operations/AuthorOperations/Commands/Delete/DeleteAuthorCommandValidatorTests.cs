using FluentAssertions;
using TestSetup;
using WebApi.Operations.AuthorOperations.Commands.DeleteAuthor;

namespace Operations.AuthorOperations.Commands.Delete
{
    public class DeleteAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null!);
            command.id=id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }
    }
}