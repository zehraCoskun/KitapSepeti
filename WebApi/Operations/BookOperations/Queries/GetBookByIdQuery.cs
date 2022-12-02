using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Operations.BookOperations.Queries
{
    public class GetBookByIdQuery
    {
        private readonly KitapSepetiDbContext _context;
        public int id { get; set; }
        public IMapper _mapper{get; set;}
        public GetBookByIdQuery(KitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetBookByIdModel Handle()
        {
            var book = _context.Books.Include(x=> x.Genre).Include(x=> x.Author).Where(x => x.ID == id).SingleOrDefault();
            if(book is null)
            {throw new InvalidOperationException("bu id'ye kayıtlı bir kitap yok");}

            GetBookByIdModel vm = _mapper.Map<GetBookByIdModel>(book);

            return vm;
        }

    }
    public class GetBookByIdModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}