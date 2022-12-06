using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Operations.BookOperations.Commands.CreateBook;
using Xunit;

namespace Operations.BookOperations.Commands.Create
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var book = new Book(){Title="WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount=23,PublishDate=new DateTime(1980,02,05),AuthorID=1,GenreID=2};
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model=new CreateBookModel(){Title=book.Title};

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu isimde bir kitap zaten mevcut");
        }
        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeCreated()
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model= new CreateBookModel(){Title="Tests",PageCount=1,GenreID=1,AuthorID=1,PublishDate=DateTime.Now.Date.AddYears(-2)};
            
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(book=> book.Title==command.Model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(command.Model.PageCount);
            book.PublishDate.Should().Be(command.Model.PublishDate);
            book.GenreID.Should().Be(command.Model.GenreID);
            book.AuthorID.Should().Be(command.Model.AuthorID);
        }

    }
}
