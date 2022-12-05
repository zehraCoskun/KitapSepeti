using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Operations.BookOperations.Queries
{
    public class GetBooksQuery
    {
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(IKitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.Include(x=> x.Genre).Include(x=> x.Author).OrderBy(x => x.ID).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            return vm;
        }
        public class BooksViewModel
        { 
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        }
    }
}