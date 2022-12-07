using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Operations.AuthorOperations.Commands.DeleteAuthor;

namespace Operations.AuthorOperations.Commands.Delete
{
    public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly KitapSepetiDbContext _context;
        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }
        [Fact]
        public void WhenAlreadyNonExistAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.id=1000;

            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu id'ye ait bir yazar yok");

        }
        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.id=1;

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

                var author= _context.Authors.SingleOrDefault(x=> x.ID==command.id);
                author.Should().BeNull();
        }
    }
}