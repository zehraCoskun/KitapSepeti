using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Operations.BookOperations.Queries;

namespace Operations.BookOperations.Queries
{
    public class GetBookByIdQueryTests :IClassFixture<CommonTestFixture>
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;

        public GetBookByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
            query.id=id;

            FluentActions
                .Invoking(()=> query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu id'ye kayıtlı bir kitap yok");
        }
    }
}