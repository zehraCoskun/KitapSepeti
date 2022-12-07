using FluentAssertions;
using TestSetup;
using WebApi.Operations.GenreOperations.Commands.CreatGenre;

namespace Operations.GenreOperations.Command.Create
{
    public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("")]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(string genreName)
        {
            CreateGenreCommand command = new CreateGenreCommand(null,null);
            command.Model=new CreateGenreModel(){GenreName=genreName, IsActive=true};
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }
        
    }
}