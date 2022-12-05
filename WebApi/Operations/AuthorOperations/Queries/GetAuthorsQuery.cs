using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Operations.AuthorOperations.Queries
{
    public class GetAuthorsQuery
    {
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IKitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AuthorsViewModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(x => x.ID).ToList();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authorList);
            return vm;
        }
    }

    public class AuthorsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}