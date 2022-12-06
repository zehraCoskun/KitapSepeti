using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Operations.AuthorOperations.Commands.UpdateAuthor;

namespace Operations.AuthorOperations.Commands.Update
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorCommandTests (CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper=testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyNonExistAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
            
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu id'ye kayıtlı bir yazar yok");
        }
        [Fact]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
            command.Model= new UpdateAuthorModel(){FirstName="first",LastName="Last",DateOfBirth=DateTime.Now.Date.AddYears(-15)};
            command.id=1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();
            var author = _context.Authors.SingleOrDefault(author=> author.ID==command.id);
            author.Should().NotBeNull();

        }
    }
}