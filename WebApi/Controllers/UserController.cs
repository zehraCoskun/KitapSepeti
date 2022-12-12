using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Operations.UserOperations.Commands.CreateToken;
using WebApi.Operations.UserOperations.Commands.CreateUserCommand;
using WebApi.Operations.UserOperations.Queries;
using WebApi.TokenOperations.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public UserController(KitapSepetiDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersQuery query = new GetUsersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            command.Handle();
            return Ok();
        }
        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model=login;
            var token = command.Handle();
            return token;
        }


    }
}