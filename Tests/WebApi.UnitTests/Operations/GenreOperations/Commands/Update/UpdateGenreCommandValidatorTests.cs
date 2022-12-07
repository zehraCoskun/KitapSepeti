using FluentAssertions;
using TestSetup;
using WebApi.Operations.GenreOperations.Commands.UpdateGenre;

namespace Operations.GenreOperations.Command.Update
{
    public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(string name)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null,null);
            command.Model=new UpdateGenreModel(){GenreName=name, IsActive=true};

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result =  validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }
    }
}