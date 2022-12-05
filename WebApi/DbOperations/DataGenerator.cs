using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KitapSepetiDbContext(serviceProvider.GetRequiredService<DbContextOptions<KitapSepetiDbContext>>()))
            {
                if (context.Books.Any())
                { return; }

                context.Books.AddRange
                (
                    new Book
                    {
                        Title = "Pulbiber Mahallesi",
                        PageCount = 98,
                        PublishDate = new DateTime(2007, 03, 21),
                        GenreID = 1, //şiir
                        AuthorID = 2
                    },
                    new Book
                    {
                        Title = "Mesut İnsanlar Fotoğrafhanesi",
                        PageCount = 340,
                        PublishDate = new DateTime(1952, 12, 02),
                        GenreID = 3, //hikaye
                        AuthorID = 1
                    },
                    new Book
                    {
                        Title = "Yeşil Peri Gecesi",
                        PageCount = 170,
                        PublishDate = new DateTime(2010, 07, 15),
                        GenreID = 2, //roman
                        AuthorID = 3
                    }
                );
                context.SaveChanges();

                if (context.Genres.Any())
                { return; }

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

                if(context.Authors.Any())
                {return;}

                context.Authors.AddRange
                (
                    new Author
                    {
                        FirstName ="Ziya Osman",
                        LastName ="Saba",
                        DateOfBirth = new DateTime(1910,03,30)
                    },
                    new Author
                    {
                        FirstName ="Didem",
                        LastName ="Madak",
                        DateOfBirth = new DateTime(1970,04,08)
                    },
                    new Author
                    {
                        FirstName ="Ayfer",
                        LastName ="Tunç",
                        DateOfBirth = new DateTime(1964,03,02)
                    }
                );
                context.SaveChanges();

            }
        }
    }
}