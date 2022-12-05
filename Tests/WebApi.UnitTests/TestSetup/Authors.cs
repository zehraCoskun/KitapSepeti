using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this KitapSepetiDbContext context)
        {
            context.Authors.AddRange
                (
                    new Author
                    {
                        FirstName = "Ziya Osman",
                        LastName = "Saba",
                        DateOfBirth = new DateTime(1910, 03, 30)
                    },
                    new Author
                    {
                        FirstName = "Didem",
                        LastName = "Madak",
                        DateOfBirth = new DateTime(1970, 04, 08)
                    },
                    new Author
                    {
                        FirstName = "Ayfer",
                        LastName = "Tunç",
                        DateOfBirth = new DateTime(1964, 03, 02)
                    }
                );
            context.SaveChanges();
        }
    }
}