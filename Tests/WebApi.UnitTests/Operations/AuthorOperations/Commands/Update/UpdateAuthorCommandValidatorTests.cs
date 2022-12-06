using FluentAssertions;
using TestSetup;
using WebApi.Operations.AuthorOperations.Commands.UpdateAuthor;

namespace Operations.AuthorOperations.Commands.Update
{
    public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","")]
        [InlineData("first","")]
        [InlineData("","last")]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(string firstName, string lastName)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            command.Model= new UpdateAuthorModel()
            {FirstName=firstName,LastName=lastName,DateOfBirth=DateTime.Now.AddYears(-15)};

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
           UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            command.Model= new UpdateAuthorModel()
            {
                FirstName="first", LastName="last" ,DateOfBirth=DateTime.Now.Date
            };
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0); 
        }
    }
}