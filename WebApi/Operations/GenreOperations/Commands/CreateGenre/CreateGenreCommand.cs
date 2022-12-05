using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Operations.GenreOperations.Commands.CreatGenre
{
    public class CreateGenreCommand
    {
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreModel Model { get; set; }

        public CreateGenreCommand(IKitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.GenreName == Model.GenreName);
            if (genre is not null)
            { throw new InvalidOperationException("bu kitap türü zaten mevcut"); }

            genre = _mapper.Map<Genre>(Model);

            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
    public class CreateGenreModel
    {
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}