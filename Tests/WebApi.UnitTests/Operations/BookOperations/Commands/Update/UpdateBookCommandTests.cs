using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Operations.BookOperations.Commands.UpdateBook;

namespace Operations.BookOperations.Commands.Update
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyNonExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu id'ye kayıtlı bir kitap yok");

        }
        [Fact]
        public void WhenInvalidInputAreGiven_ShouldBeReturnErrors()
        {
            UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
            command.Model= new UpdateBookModel(){Title="Test",PageCount=1,GenreID=1,AuthorID=1,PublishDate=DateTime.Now.Date.AddYears(-2)};
            command.id=1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(book=> book.ID==command.id);
            book.Should().NotBeNull();

        }
    }
}