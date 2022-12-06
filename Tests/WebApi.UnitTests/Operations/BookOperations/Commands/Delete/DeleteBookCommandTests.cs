using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Operations.BookOperations.Commands.DeleteBook;

namespace Operations.BookOperations.Commands.Delete
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly KitapSepetiDbContext _context;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenAlreadyNonExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu id'ye kayıtlı bir kitap yok");

        }

    }
}