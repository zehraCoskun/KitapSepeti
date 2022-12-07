using FluentAssertions;
using TestSetup;
using WebApi.Operations.GenreOperations.Commands.DeleteGenre;

namespace Operations.GenreOperations.Command.Delete
{
    public class DeleteGenreCommandValidatorTests :IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.id=id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }
    }
}