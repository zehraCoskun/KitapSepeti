using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Operations.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }
        public UpdateGenreModel Model { get; set; }

        public UpdateGenreCommand(IKitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.ID == id);
            if (genre is null)
            { throw new InvalidOperationException("bu id'ye ait bir kitap türü yok"); }
            if (_context.Genres.Any(x => x.GenreName.ToLower() == genre.GenreName.ToLower() && x.ID != genre.ID))
            { throw new InvalidOperationException("aynı isimli bir kitap türü zaten mevcut"); }

            genre.GenreName = string.IsNullOrEmpty(Model.GenreName.Trim()) != default ? genre.GenreName : Model.GenreName;
            genre.IsActive = Model.IsActive;

            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string GenreName { get; set; }
        public bool IsActive { get; set; }=true;

    }
}