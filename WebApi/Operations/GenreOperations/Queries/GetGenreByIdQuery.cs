using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Operations.GenreOperations.Queries
{
    public class GetGenreByIdQuery
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }

        public GetGenreByIdQuery(KitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetGenreByIdModel Handle()
        {
            var genre = _context.Genres.Where(x => x.ID == id).SingleOrDefault();
            if (genre is null)
            { throw new InvalidOperationException("bu id'ye kayıtlı bir tür yok"); }
            
            GetGenreByIdModel vm = _mapper.Map<GetGenreByIdModel>(genre);

            return vm;
        }
    }

    public class GetGenreByIdModel
    {
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}