using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Operations.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(KitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.FirstName + x.LastName == Model.FirstName + Model.LastName);
            if (author is not null)
            { throw new InvalidOperationException("bu isim-soyisimde bir yazar zaten mevcut"); }

            author = _mapper.Map<Author>(Model);
            
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

    }
    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }


}