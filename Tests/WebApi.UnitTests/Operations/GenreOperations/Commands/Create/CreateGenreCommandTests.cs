using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Operations.GenreOperations.Commands.CreatGenre;

namespace Operations.GenreOperations.Command.Create
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper=testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var genre = new Genre(){GenreName="test", IsActive=true};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
            command.Model = new CreateGenreModel(){GenreName=genre.GenreName};

            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("bu kitap türü zaten mevcut");
        }
        [Fact]
        public void WhenValidInputAreGiven_Genre_ShouldBeCreated()
        {
            CreateGenreCommand command=new CreateGenreCommand(_context,_mapper);
            command.Model=new CreateGenreModel(){GenreName="test",IsActive=true};

            FluentActions.Invoking(()=> command.Handle()).Invoke();
            var genre =_context.Genres.SingleOrDefault(genre=> genre.GenreName==command.Model.GenreName);
            genre.Should().NotBeNull();
            genre.IsActive.Should().Be(command.Model.IsActive);
            
        }
    }
}