using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Commands.CreateAuthor;

namespace Operations.AuthorOperations.Commands.Create
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommandTests (CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper=testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var author = new Author(){FirstName="testF", LastName="testL",DateOfBirth= new DateTime(1980,01,02)};
            _context.Authors.Add(author);
            _context.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            command.Model= new CreateAuthorModel(){FirstName=author.FirstName,LastName=author.LastName};

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu isim-soyisimde bir yazar zaten mevcut");
        }
        [Fact]
        public void WhenValidInputAreGiven_Author_ShouldBeCreated()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            command.Model = new CreateAuthorModel(){FirstName="first",LastName="last",DateOfBirth= new DateTime(1980,12,04)};

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var author = _context.Authors.SingleOrDefault(author=> author.FirstName==command.Model.FirstName &&author.LastName==command.Model.LastName);
            author.Should().NotBeNull();
            author.DateOfBirth.Should().Be(command.Model.DateOfBirth);

        }
    }
}