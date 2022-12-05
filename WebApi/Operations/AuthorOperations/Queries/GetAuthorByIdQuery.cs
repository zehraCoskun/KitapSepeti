using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Operations.AuthorOperations.Queries
{
    public class GetAuthorByIdQuery
    {
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }
        public GetAuthorByIdQuery(IKitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetAuthorByIdModel Handle()
        {
            var author = _context.Authors.Where(x=> x.ID==id).SingleOrDefault();
            if(author is null)
            {throw new InvalidOperationException("bu id'ye kayıtlı bir kitap yok");}

            GetAuthorByIdModel vm = _mapper.Map<GetAuthorByIdModel>(author);
            
            return vm;
        }
    }
    public class GetAuthorByIdModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }


    }
}