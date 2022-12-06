using FluentAssertions;
using TestSetup;
using WebApi.Operations.AuthorOperations.Commands.CreateAuthor;

namespace Operations.AuthorOperations.Commands.Create
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","")]
        [InlineData("First","")]
        [InlineData("","Last")]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(string firstName, string lastName)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model= new CreateAuthorModel()
            {
                FirstName=firstName, LastName=lastName,DateOfBirth=DateTime.Now.Date.AddYears(-20)
            };

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenMoreThan10YearsIsGiven_Validator_ShouldBeReturnError()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null,null);
            command.Model= new CreateAuthorModel()
            {
                FirstName="first",
                LastName="last",
                DateOfBirth=DateTime.Now.Date.AddYears(-14)
            };
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
