using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Mapping;

namespace TestSetup
{
    public class CommonTestFixture
    {
        public KitapSepetiDbContext Context { get; set; }
        public IMapper Mapper { get; set; }


        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<KitapSepetiDbContext>().UseInMemoryDatabase(databaseName: "KitapSepetiTestDbContext").Options;
            Context = new KitapSepetiDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddAuthors();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg=> {cfg.AddProfile<MappingProfile>();}).CreateMapper();
            
        }
    }

}