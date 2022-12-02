using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Operations.GenreOperations.Queries
{
    public class GetGenresQuery
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(KitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenresViewModel> Handle()
        {
            var genreList = _context.Genres.Where(x=> x.IsActive).OrderBy(x=> x.ID).ToList();
            List<GenresViewModel> vm = _mapper.Map<List<GenresViewModel>>(genreList);
            return vm;
        }
    }
    public class GenresViewModel
    {
        public string GenreName { get; set; }
        public bool  IsActive { get; set; }
    }
}