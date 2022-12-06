using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Operations.BookOperations.Queries;

namespace Operations.BookOperations.Queries
{
    public class GetBookByIdQueryValidatorTests :IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(null, null);
            query.id=id;
            
            GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}