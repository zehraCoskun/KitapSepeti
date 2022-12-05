using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this KitapSepetiDbContext context)
        {
            context.Genres.AddRange
                (
                    new Genre
                    {
                        GenreName = "Şiir",
                    },
                    new Genre
                    {
                        GenreName = "Roman",
                    },
                    new Genre
                    {
                        GenreName = "Hikaye",
                    }
                );
            context.SaveChanges();
        }
    }
}