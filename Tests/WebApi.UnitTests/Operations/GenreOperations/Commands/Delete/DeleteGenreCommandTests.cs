using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Operations.GenreOperations.Commands.DeleteGenre;

namespace Operations.GenreOperations.Command.Delete
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly KitapSepetiDbContext _context;
        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }
        [Fact]
        public void WhenAlreadyNonExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.id=1000;

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu id'ye ait bir tür yok");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.id=1;

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

                var genre= _context.Genres.SingleOrDefault(x=> x.ID==command.id);
                genre.Should().BeNull();
        }

    }
}