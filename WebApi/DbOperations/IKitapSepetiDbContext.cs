using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace   WebApi.DbOperations
{
    public interface IKitapSepetiDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }
        int SaveChanges();
    }
}