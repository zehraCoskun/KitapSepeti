using WebApi.DbOperations;

namespace WebApi.Operations.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly KitapSepetiDbContext _context;
        public int id { get; set; }

        public DeleteAuthorCommand(KitapSepetiDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.ID == id);
            if(author is null)
            {throw new InvalidOperationException("bu id'ye ait bir yazar yok");}

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}