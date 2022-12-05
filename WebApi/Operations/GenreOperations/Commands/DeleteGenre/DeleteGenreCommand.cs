using WebApi.DbOperations;

namespace WebApi.Operations.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IKitapSepetiDbContext _context;
        public int id { get; set; }

        public DeleteGenreCommand(IKitapSepetiDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.ID==id);
            if(genre is null)
            {throw new InvalidOperationException("bu id'ye ait bir tür yok");}

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}