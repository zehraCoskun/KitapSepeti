using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Operations.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly KitapSepetiDbContext _context;
        private readonly IMapper _mapper;
        public int id;
        public UpdateAuthorModel Model { get; set; }
        public UpdateAuthorCommand(KitapSepetiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.ID == id);
            if (author is null)
            { throw new InvalidOperationException("bu id'ye kayıtlı bir yazar yok"); }

            author.FirstName = string.IsNullOrEmpty(Model.FirstName)  != default ? author.FirstName : Model.FirstName;
            author.LastName = string.IsNullOrEmpty(Model.LastName) != default ? author.LastName : Model.LastName;

            _context.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}