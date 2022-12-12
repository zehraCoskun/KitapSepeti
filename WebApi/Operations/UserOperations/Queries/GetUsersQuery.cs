using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Operations.UserOperations.Queries
{
    public class GetUsersQuery
    {
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersQuery(IKitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<UsersViewModel> Handle()
        {
            var userList = _context.Users.OrderBy(x => x.ID).ToList();
            List<UsersViewModel> vm = _mapper.Map<List<UsersViewModel>>(userList);
            return vm;
        }
    }

    public class UsersViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
    }
}