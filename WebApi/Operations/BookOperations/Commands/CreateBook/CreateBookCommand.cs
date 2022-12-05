using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Operations.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommand(IKitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x=> x.Title==Model.Title);
            if(book is not null)
            {throw new InvalidOperationException("bu isimde bir kitap zaten mevcut");}

            book = _mapper.Map<Book>(Model);

            _context.Books.Add(book);
            _context.SaveChanges();
        }
        
    }
    public class CreateBookModel
        {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreID { get; set; }
        public int AuthorID { get; set; }
        }
}