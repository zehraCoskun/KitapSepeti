using WebApi.DbOperations;

namespace WebApi.Operations.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IKitapSepetiDbContext _context;
        public int id { get; set; }

        public DeleteBookCommand(IKitapSepetiDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.ID == id);
            if(book is null)
            {throw new InvalidOperationException("bu id'ye kayıtlı bir kitap yok");}

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}