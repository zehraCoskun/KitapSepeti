using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Operations.UserOperations.Commands.CreateUserCommand
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IKitapSepetiDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommand(IKitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x=> x.Email==Model.Email);
            if (user is not null)
            { throw new InvalidOperationException("bu mail adresi ile bir kullanıcı zaten mevcut"); }

            user = _mapper.Map<User>(Model);
            
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}