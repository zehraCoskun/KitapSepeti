using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this KitapSepetiDbContext context)
        {
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

        }
    }
}