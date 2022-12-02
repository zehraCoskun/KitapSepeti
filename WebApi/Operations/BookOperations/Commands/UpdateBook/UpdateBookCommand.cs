using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Operations.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public int id;
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(KitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.ID == id);
            if (book is null)
            { throw new InvalidOperationException("bu id'ye kayıtlı bir kitap yok"); }

            _mapper.Map<UpdateBookModel , Book>(Model , book);

            book.Title = string.IsNullOrEmpty(Model.Title) != default ? book.Title : Model.Title;
            book.GenreID = (Model.GenreID) != default ? book.GenreID : Model.GenreID;
            book.AuthorID = (Model.AuthorID) != default ? book.AuthorID : Model.AuthorID;
            book.PageCount = (Model.PageCount) != default ? book.PageCount : Model.PageCount;

            // book = _mapper.Map<Book>(Model);

            _context.SaveChangesAsync();
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreID { get; set; }
        public int AuthorID { get; set; }
    }
}